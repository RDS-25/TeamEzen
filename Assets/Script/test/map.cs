using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    enum Test {
        Default, // �ƹ��͵� ���� ����� ��
        NoMonster, // �Ϲݸ��� ���� �� ( �Ӽ� �� �� 3����, 2�������� ���� ���� ���� �� �� �� �������� )
        EpMonster, // ���ȸ��� ���� �� ( �Ӽ� �� �� 3����, 2�������� ���� ���� ���� �� �� �� �������� )
        DeTrap, // ����� Ʈ�� �� ( ���� ���� ���� ���� )
        Trap, // ���� �ִ� Ʈ�� �� ( ���� ���� ���� ���� )
        Puzzle // ���� �� ( ���� ���� ���� ���� )
        //Store // ���� �� ( ������ ������(?) or ��ȭ ����(?) ����)
    }

    // ��ųʸ��� ���� ( Json�� ����� ���� )
    private Dictionary<Test, int> m_Cards = new Dictionary<Test, int>();
    // m_Card��� ���� ���� ( Test�� �տ� ���̴°� enum���� ����� �� ���� ���)
    private Test m_Card;

    void Start()
    {
        // m_cards ��ųʸ��� �׸�� �߰� 
        m_Cards.Add(Test.Default, 20);
        m_Cards.Add(Test.NoMonster, 30);
        m_Cards.Add(Test.EpMonster, 15);
        m_Cards.Add(Test.DeTrap, 15);
        m_Cards.Add(Test.Trap, 10);
        m_Cards.Add(Test.Puzzle, 10);
        //m_Cards.Add(Test.Store, 5); // ������ Ȯ�� 1������ �� ���� �ֱ� ������

        for (int i = 0; i < 16; i++)
        {
            //���� �κ� mCard�� m_Cards���� ���� ���� �� �ϳ��� �ֱ�
            // ���� public static class WeightedRandomizer�� �̵�
            m_Card = WeightedRandomizer.From(m_Cards).TakeOne();
            //��� ���
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
