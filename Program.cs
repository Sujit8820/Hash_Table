// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using Hash_Table;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hash Table");
            String[] Sentence = { "TO", "BE", "OR", "NOT", "TO", "BE" };
            WordFrequency(Sentence);
        }


        public static void WordFrequency(string[] Sentence)
        {
            MyMapNode<string, int> MyMapNode = new MyMapNode<string, int>(5);
            foreach (string word in Sentence)
            {
                int count = MyMapNode.CountFrequency(word);
                MyMapNode.Add(word, count);
            }
            IEnumerable<string> DistinctSentence = Sentence.Distinct<string>();
            foreach (string word in DistinctSentence)
            {
                MyMapNode.Display(word);
            }
        }
    }
}
