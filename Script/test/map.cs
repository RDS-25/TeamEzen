using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    enum Test {
        Default, // 아무것도 없는 평범한 땅
        NoMonster, // 일반몬스터 생성 땅 ( 속성 별 총 3가지, 2패턴으로 만들 예정 랜덤 한 번 더 돌려야함 )
        EpMonster, // 에픽몬스터 생성 땅 ( 속성 별 총 3가지, 2패턴으로 만들 예정 랜덤 한 번 더 돌려야함 )
        DeTrap, // 디버프 트랩 방 ( 여러 종류 만들 예정 )
        Trap, // 버프 주는 트랩 방 ( 여러 종류 만들 예정 )
        Puzzle // 퍼즐 방 ( 여러 종류 만들 예정 )
        //Store // 떠상 방 ( 랜덤한 아이템(?) or 강화 버프(?) 생성)
    }

    // 딕셔너리를 생성 ( Json과 비슷한 구조 )
    private Dictionary<Test, int> m_Cards = new Dictionary<Test, int>();
    // m_Card라는 변수 생성 ( Test를 앞에 붙이는건 enum형을 사용할 때 쓰는 방식)
    private Test m_Card;

    void Start()
    {
        // m_cards 딕셔너리에 항목들 추가 
        m_Cards.Add(Test.Default, 20);
        m_Cards.Add(Test.NoMonster, 30);
        m_Cards.Add(Test.EpMonster, 15);
        m_Cards.Add(Test.DeTrap, 15);
        m_Cards.Add(Test.Trap, 10);
        m_Cards.Add(Test.Puzzle, 10);
        //m_Cards.Add(Test.Store, 5); // 상점은 확정 1곳으로 할 수도 있기 때문에

        for (int i = 0; i < 16; i++)
        {
            //실행 부분 mCard에 m_Cards에서 뽑은 랜덤 값 하나를 넣기
            // 밑의 public static class WeightedRandomizer로 이동
            m_Card = WeightedRandomizer.From(m_Cards).TakeOne();
            //결과 출력
            Debug.Log(m_Card.ToString());
        }
    }
    
    public static class WeightedRandomizer
    {
        public static WeightedRandomizer<R> From<R>(Dictionary<R, int> spawnRate)
        {
            return new WeightedRandomizer<R>(spawnRate);
        }
    }


    public class WeightedRandomizer<T>
    {
        private static System.Random _random = new System.Random();
        private Dictionary<T, int> _weights;

        public WeightedRandomizer(Dictionary<T, int> weights)
        {
            _weights = weights;
        }

        public T TakeOne()
        {
            var sortedSpawnRate = Sort(_weights);
            int sum = 0;
            foreach (var spawn in _weights)
            {
                sum += spawn.Value;
            }

            int roll = _random.Next(0, sum);

            T selected = sortedSpawnRate[sortedSpawnRate.Count - 1].Key;
            foreach (var spawn in sortedSpawnRate)
            {
                if (roll < spawn.Value)
                {
                    selected = spawn.Key;
                    break;
                }
                roll -= spawn.Value;
            }
                return selected;
        }

        private List<KeyValuePair<T, int>> Sort(Dictionary<T, int> weights)
        {
            var list = new List<KeyValuePair<T, int>>(weights);

            list.Sort(
                delegate (KeyValuePair<T, int> firstPair,
                            KeyValuePair<T, int> nextPair)
                {
                    return firstPair.Value.CompareTo(nextPair.Value);
                }
                );

            return list;
        }
    }
}
