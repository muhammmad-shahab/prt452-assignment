using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleAppTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InsertFirstWordTest()
        {
            //check for the functionalaty of the get count method
            ConsoleApplication application = new ConsoleApplication();

            application.Insert("abc");
            int expected = 1;
            int actual = application.Getcountof("abc");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertSameWordTest()
        {
            //check for the functionalaty of the get count method if same word inserted
            ConsoleApplication application = new ConsoleApplication();

            application.Insert("abc");
            application.Insert("abc");
            int expected = 2;
            int actual = application.Getcountof("abc");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSortedStringTest()
        {
            //check for the functionalaty of the get count method if same word inserted
            ConsoleApplication application = new ConsoleApplication();

         
            string expected = "apw";
            string actual = application.GetAlphabaticalString("paw");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddStringTest()
        {
            //check for the functionalaty of the get count method if same word inserted
            ConsoleApplication application = new ConsoleApplication();

            string first = "abce";
            string second = "abcd";
            string expected = first;
            application.AddToDictionaryWordHolder(first);
            
            string actual = application.GetfromDictionaryWordHolder(expected);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddMultipleStringTest()
        {
            //check for the functionalaty of the get count method if same word inserted
            ConsoleApplication application = new ConsoleApplication();

            string first = "abce";
            string second = "aebc";
            string expected = first  + ", " + second;
            application.AddToDictionaryWordHolder(first);
            application.AddToDictionaryWordHolder(second);
            string actual = application.GetfromDictionaryWordHolder(first);

            Assert.AreEqual(expected, actual);
            System.Console.WriteLine(first);
        }

        [TestMethod]
        public void CountTest()
        {
            ConsoleApplication application = new ConsoleApplication();

            int expected = 3;

            application.GroupWordsAndCount();

            int actual = application.GetCount("apw");

            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void GetMaxTest()
        {
            ConsoleApplication application = new ConsoleApplication();

            string expected = "apw";

            application.GroupWordsAndCount();

            string actual = application.GetMaxKey();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetMaxWordsTest()
        {
            ConsoleApplication application = new ConsoleApplication();

            string expected = "paw, wap, awp";

            application.GroupWordsAndCount();

            string actual = application.GetMaxWords();

            Assert.AreEqual(expected, actual);

        }

       


       
        


    }


}
