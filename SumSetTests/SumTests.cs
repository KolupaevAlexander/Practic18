using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Practic18;
using System.IO;
using System.Collections.Generic;

namespace SumSetTests
{
    [TestClass]
    public class SumTests
    {
        [TestMethod]
        public void Test1()
        {
            short m = 10;
            List<string> expected = new List<string>() { "11000", "11011"};
            short[] data = new short[] { 1, 9, 4, -32767, 32767 };

            var actual = Practic18.Program.Count(data, m);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2()
        {
            short m = 32767;
            List<string> expected = new List<string>() {  };
            short[] data = new short[] { 1 };

            var actual = Program.Count(data, m);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test3()
        {
            short m = -32767;
            List<string> expected = new List<string>() {};
            
            short[] data = new short[25];
            for (int i=0;i<25;i++)
                data[i] = 1;

            var actual = Program.Count(data, m);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test4()
        {
            short[] set = new short[] { 1 , 2 , 3};
            var code0 = "000";
            var code1 = "001";
            var code2 = "010";
            var code3 = "011";
            var code4 = "100";
            var code5 = "101";
            var code6 = "110";
            var code7 = "111";

            var actual0 = Program.SetSum(set, code0);
            var actual1 = Program.SetSum(set, code1);
            var actual2 = Program.SetSum(set, code2);
            var actual3 = Program.SetSum(set, code3);
            var actual4 = Program.SetSum(set, code4);
            var actual5 = Program.SetSum(set, code5);
            var actual6 = Program.SetSum(set, code6);
            var actual7 = Program.SetSum(set, code7);

            Assert.AreEqual(0, actual0);
            Assert.AreEqual(3, actual1);
            Assert.AreEqual(2, actual2);
            Assert.AreEqual(5, actual3);
            Assert.AreEqual(1, actual4);
            Assert.AreEqual(4, actual5);
            Assert.AreEqual(3, actual6);
            Assert.AreEqual(6, actual7);
        }

        [TestMethod]
        public void Test5()
        {
            short[] set = new short[] { 1, 2, 3 };
            var code0 = 0;
            var code1 = 1;
            var code2 = 2;
            var code3 = 3;
            var code4 = 4;
            var code5 = 5;
            var code6 = 6;
            var code7 = 7;

            var actual0 = Program.GenerateCode(code0, 3);
            var actual1 = Program.GenerateCode(code1, 3);
            var actual2 = Program.GenerateCode(code2, 3);
            var actual3 = Program.GenerateCode(code3, 3);
            var actual4 = Program.GenerateCode(code4, 3);
            var actual5 = Program.GenerateCode(code5, 3);
            var actual6 = Program.GenerateCode(code6, 3);
            var actual7 = Program.GenerateCode(code7, 3);

            Assert.AreEqual("000", actual0);
            Assert.AreEqual("001", actual1);
            Assert.AreEqual("010", actual2);
            Assert.AreEqual("011", actual3);
            Assert.AreEqual("100", actual4);
            Assert.AreEqual("101", actual5);
            Assert.AreEqual("110", actual6);
            Assert.AreEqual("111", actual7);
        }

        [TestMethod]
        public void Test6()
        {
            short[] set = new short[] { 1, 2, 3 };
            var code0 = "000";
            var code1 = "001";
            var code2 = "010";
            var code3 = "011";
            var code4 = "100";
            var code5 = "101";
            var code6 = "110";
            var code7 = "111";

            var actual0 = Program.SetFromCode(set, code0);
            var actual1 = Program.SetFromCode(set, code1);
            var actual2 = Program.SetFromCode(set, code2);
            var actual3 = Program.SetFromCode(set, code3);
            var actual4 = Program.SetFromCode(set, code4);
            var actual5 = Program.SetFromCode(set, code5);
            var actual6 = Program.SetFromCode(set, code6);
            var actual7 = Program.SetFromCode(set, code7);

            CollectionAssert.AreEqual(new List<int> {}, actual0);
            CollectionAssert.AreEqual(new List<int> {3}, actual1);
            CollectionAssert.AreEqual(new List<int> {2}, actual2);
            CollectionAssert.AreEqual(new List<int> {2, 3}, actual3);
            CollectionAssert.AreEqual(new List<int> {1}, actual4);
            CollectionAssert.AreEqual(new List<int> {1,3}, actual5);
            CollectionAssert.AreEqual(new List<int> {1,2}, actual6);
            CollectionAssert.AreEqual(new List<int> { 1,2,3}, actual7);
        }

        [TestMethod]
        public void Test7()
        {
            string m = "test";
            string path = "data.txt";

            var expected = "Ввод неверен";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test8()
        {
            string m = "40000";
            string path = "data.txt";

            var expected = "Ввод неверен";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test9()
        {
            string m = "-40000";
            string path = "data.txt";

            var expected = "Ввод неверен";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test10()
        {
            string m = "10";
            
            File.WriteAllText("test.txt", "");
            string path = "test.txt";

            var expected = "Файл пуст";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test11()
        {
            string m = "10";

            string path = "non_existing_file.txt";

            var expected = "Файл не найден";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test12()
        {
            string m = "10";

            File.WriteAllText("test.txt", "test");
            string path = "test.txt";

            var expected = "Информация записана в файле неверно";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test13()
        {
            string m = "10";

            File.WriteAllText("test.txt", "1 9 4 40000");
            string path = "test.txt";

            var expected = "Информация записана в файле неверно";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test14()
        {
            string m = "10";

            File.WriteAllText("test.txt", "1 9 4 -40000");
            string path = "test.txt";

            var expected = "Информация записана в файле неверно";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test15()
        {
            string m = "10";

            File.WriteAllText("test.txt", "тест 1 9 4 -40000");
            string path = "test.txt";

            var expected = "Информация записана в файле неверно";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test16()
        {
            string m = "10";
            string path = "";

            var expected = "Файл не найден";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test17()
        {
            string m = "10";
            string str="";
            for (int i = 0; i < 100; i++)
                str += "1 ";

            File.WriteAllText("test.txt", str);
            string path = "test.txt";

            var expected = "Большой объём входных данных";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test18()
        {
            string m = "10";
            string str = "";
            for (int i = 0; i < 100000; i++)
                str += "1 ";

            File.WriteAllText("test.txt", str);
            string path = "test.txt";

            var expected = "Большой объём входных данных";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test19()
        {
            string m = "10";

            File.WriteAllText("test.txt", "                           ");
            string path = "test.txt";

            var expected = "Файл пуст";
            var actual = Program.SumSetFinder(m, path);

            Assert.AreEqual(expected, actual);
        }
    }
}
