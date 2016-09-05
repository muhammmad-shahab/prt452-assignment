using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    class Program
    {
        //dictionalry holds the number of apparances in each word
        Dictionary<string, int> dictionary =
        new Dictionary<string, int>();

        Dictionary<string, string> dictionaryWordHolder =
        new Dictionary<string, string>();

        // will hold original data
        string[] wordArr = { "how", "who", "here", "paw", "wap", "awp" };
        
        //runs the program
        public string Run()
        {
            //group the names in to dictionaries
            GroupWordsAndCount();

            Dictionary<string, int> tempDic = dictionary;

            string last = "";

            foreach (var item in dictionary.OrderByDescending(key => key.Value))
            {

                var tempKey = GetMaxKey();

                last += dictionary[tempKey] + ": " + dictionaryWordHolder[tempKey] + "\n";

                dictionary.Remove(tempKey);
            }

            dictionary = tempDic; //restoring original dictionary

            return last;

        }

        internal int Getcountof(string p)
        {
            if (dictionary.ContainsKey(p))
                return dictionary[p];
            else
                return 0;
        }


        //method counts how many occurenses are in the WordArr
        // should Insert by the string alphabatic key 
        //          e.g. "adcb" key -> "abcd"
        internal bool Insert(string key)
        {
            //if this key is a new one
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, 1);

            //the key is already inserted increment count
            else
                dictionary[key]++;

            return true;
        }

        //this method returns alphabeticaly sorted string
        internal string GetAlphabaticalString(string p)
        {
            return String.Concat(p.OrderBy(c => c));
        }

        //word is added according to its key. will be used to print
        internal void AddToDictionaryWordHolder(string p)
        {
            string key = GetAlphabaticalString(p); //getting relevant key

            if (!dictionaryWordHolder.ContainsKey(key))
                dictionaryWordHolder.Add(key, p);

            else
            {
                string newString = dictionaryWordHolder[key] + ", " + p; // this ads srtings in the type who, how

                dictionaryWordHolder.Remove(key);

                dictionaryWordHolder.Add(key, newString);

            }
        }

        //returns corresponding strings list for a key
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

        //returns max key
        public string GetMaxKey()
        {
            return dictionary.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        public string GetMaxWords()
        {
            return dictionaryWordHolder[GetMaxKey()];
        }
        
        public int GetCount(string p)
        {
            string key = GetAlphabaticalString(p);
            if (dictionary.ContainsKey(key))
                return dictionary[key];
            return 0;
        }

        public string[] GetInput(int size)
        {
            string[] input = new string[size];
            for (int i = 0; i < size; i++) {
                Console.WriteLine("Enter Word: " + (i + 1));
                input[i] = Console.ReadLine();
            }
            return input;
        }
        
        public static void Main() {

            Program p = new Program();
            Console.WriteLine("==================== INPUTS ====================");
            Console.WriteLine();
            Console.Write("How many words you want to enter ? | ");

            int limit = Convert.ToInt32(Console.ReadLine());
            p.wordArr = p.GetInput(limit);

            Console.WriteLine();
            Console.WriteLine("==================== OUTPUT ====================");
            Console.WriteLine();
            Console.WriteLine(p.Run());
            Console.ReadLine();
        }
    }
}
