using System;
namespace HashTable
{
    class Program
    {
        public static void Main()
        {
            var j = 1002;
            var hashTable = new HashTable(10000);
            var rand = new Random();
            var massiveOfValue = new char[10000];
            for (int i = 0; i < 10000; i++)
                massiveOfValue[i] = (char)rand.Next(0x00A1, 0x27B2);
            foreach (var e in massiveOfValue)
            {
                hashTable.PutPair(j++, e);
            }
            for (int k = 0; k < 1000; k++)
                hashTable.GetValueByKey(k);
        }
    }
}
