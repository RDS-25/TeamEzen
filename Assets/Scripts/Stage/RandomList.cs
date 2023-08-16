using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RandomL
{
    public class RandomList
    {
        private static RandomList _instance = null;
        public static RandomList Inistance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new RandomList();
                }

                return _instance;
            }
        }
        public List<int> DuplicateRandomList(int minNum , int maxNum , int maxCount)
        {
            List<int> value = new List<int>();
            for (int i = 0; i < maxCount; i++)
            {
                value.Add(Random.Range(minNum, maxNum));
            }

            return value;
        }

        public List<int> NotDuplicatedRandomList(int minNum, int maxNum, int maxCount)
        {
            List<int> value = new List<int>();
            for (int i = 0; i < maxCount; i++)
            {
                int num = Random.Range(minNum, maxNum);
                if (value.Contains(num) == false)
                {
                    value.Add(num);
                }
                else
                    i--;
            }

            return value;
        }
    }
}
