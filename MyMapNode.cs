using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{
    public class MyMapNode<K, V>
    {
        public int size;
        public LinkedList<KeyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }

        public int CountFrequency(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> list = items[position];
            int count = 1;
            bool DoubleWord = false;
            KeyValue<K, V> NewSentence = default(KeyValue<K, V>);
            if (list != null)
            {
                foreach (KeyValue<K, V> pair in list)
                {
                    if (pair.key.Equals(key))
                    {
                        DoubleWord = true;
                        NewSentence = pair;
                        count = Convert.ToInt32(pair.value) + 1;
                    }
                }
                if (DoubleWord == true)
                {
                    list.Remove(NewSentence);
                }
            }
            return count;
        }

        public int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);

        }

        public LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;

        }

        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.key.Equals(key))
                {
                    return item.value;
                }
            }
            return default(V);
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V> { key = key, value = value };
            linkedList.AddLast(item);
        }

        public void Display(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> LinkedListofPosition = GetLinkedList(position);
            foreach (KeyValue<K, V> keyValue in LinkedListofPosition)
            {
                if (keyValue.key.Equals(key))
                {
                    Console.WriteLine($"{ keyValue.key} : { keyValue.value}");
                }
            }
        }
    }



    public struct KeyValue<K, V>
    {
        public K key { get; set; }
        public V value { get; set; }
    }
}
