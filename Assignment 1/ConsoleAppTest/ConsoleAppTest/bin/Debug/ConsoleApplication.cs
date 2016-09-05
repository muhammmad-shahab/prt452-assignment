using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppTest
{
    class ConsoleApplication
    {
       

        //dictionalry holds the number of apparances in each word
        Dictionary<string, int> dictionary =
        new Dictionary<string, int>();

        Dictionary<string, string> dictionaryWordHolder =
        new Dictionary<string, string>();

        // will hold original data
        string[] wordArr = new string[] { "how", "who", "here", "paw", "wap", "awp" };

        internal int Getcountof(string p)
        {
            if (dictionary.ContainsKey(p))
                return dictionary[p];
            else
                return 0;
        }

        internal bool Insert(string key)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, 1);
            else
                dictionary[key]++;

  
                return true;
        }

        //this method returns alphabeticaly sorted string
        internal string GetAlphabaticalString(string p)
        {
            return String.Concat(p.OrderBy(c => c));

        }

        internal void AddToDictionaryWordHolder(string p)
        {
            string key = GetAlphabaticalString(p);

            if (!dictionaryWordHolder.ContainsKey(key))
                dictionaryWordHolder.Add(key, p);

            else
            {   
                string newString = dictionaryWordHolder[key] + ", "  + p;

                dictionaryWordHolder.Remove(key);

                dictionaryWordHolder.Add(key, newString);

            }
        }

        internal string GetfromDictionaryWordHolder(string p) 
        {
            string key = GetAlphabaticalString(p);

            //System.Console.WriteLine("Hello World" + dictionaryWordHolder[key]);
            return dictionaryWordHolder[key];
        }

        public void GroupWordsAndCount()
        {
            foreach (string t in wordArr)
            {
                AddToDictionaryWordHolder(t);

                Insert(GetAlphabaticalString(t));
            }
        }

        public string Run() {

            GroupWordsAndCount();

            Dictionary<string,int> tempDic = dictionary;

            string last = "";

            string tempKey;

            foreach (var item in dictionary.OrderByDescending(key => key.Value))
            {

                tempKey = GetMaxKey();

                last += dictionary[tempKey] + ": " + dictionaryWordHolder[tempKey] + "\n";

                dictionary.Remove(tempKey);
            }

            dictionary = tempDic; //restoring original dictionary


            return last;
            
        }

        public string GetMaxKey() {

            return dictionary.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        public string GetMaxWords() {

            return dictionaryWordHolder[GetMaxKey()];
        }


        public int GetCount(string p) {

            string key = GetAlphabaticalString(p);

            if (dictionary.ContainsKey(key))
                return dictionary[key];

            else
                return 0;
        }
        
    }
}
