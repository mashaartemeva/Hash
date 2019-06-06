using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTest
{
    [TestClass]
    public class HashTests
    {
        [TestMethod]
        public void Test1()
        {
            string firstName = "Миша", secondName = "Нигер", thirdName = "Гриша";
            var hashTable = new HashTable.HashTable(3);
            hashTable.PutPair(0, firstName);
            hashTable.PutPair(1, secondName);
            hashTable.PutPair(2, thirdName);
            Assert.AreEqual(firstName, hashTable.GetValueByKey(0));
            Assert.AreEqual(secondName, hashTable.GetValueByKey(1));
            Assert.AreEqual(thirdName, hashTable.GetValueByKey(2));
        }
        [TestMethod]
        public void Test2()
        {
            string firstName = "Миша", secondName = "Нигер";
            var hashTable = new HashTable.HashTable(2);
            hashTable.PutPair(0, firstName);
            hashTable.PutPair(0, secondName);
            Assert.AreEqual(secondName, hashTable.GetValueByKey(0));
        }
        [TestMethod]
        public void Test3()
        {
            var j = -1;
            var hashTable = new HashTable.HashTable(10000);
            var rand = new Random();
            var massiveOfValue = new char[10000];
            for(int i = 0; i < 10000; i++)
                massiveOfValue[i] = (char)rand.Next(0x00A1, 0x27B2);
            foreach(var e in massiveOfValue)
            {
                hashTable.PutPair(j++, e);
            }
            hashTable.GetValueByKey(5000);
        }
        [TestMethod]
        public void Test4()
        {
            var j = 1002;
            var hashTable = new HashTable.HashTable(10000);
            var rand = new Random();
            var massiveOfValue = new char[10000];
            for (int i = 0; i < 10000; i++)
                massiveOfValue[i] = (char)rand.Next(0x00A1, 0x27B2);
            foreach (var e in massiveOfValue)
            {
                hashTable.PutPair(j++, e);
            }
            for(int k = 0; k < 1000; k++)
                hashTable.GetValueByKey(k);
        }
    }
}
