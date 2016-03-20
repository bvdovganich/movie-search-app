using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movie_Search_App;

namespace MakeQueryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string a = QueryControl.MakeQuery(null);
            Assert.AreEqual(a, "http://www.omdbapi.com/?t=&y=&plot=full&r=json");
        }

        [TestMethod]
        public void TestMethod2()
        {
            string a = QueryControl.MakeQuery("");
            Assert.AreEqual(a, "http://www.omdbapi.com/?t=&y=&plot=full&r=json");
        }

        [TestMethod]
        public void TestMethod3()
        {
            string a = QueryControl.MakeQuery("test");
            Assert.AreEqual(a, "http://www.omdbapi.com/?t=test&y=&plot=full&r=json");
        }

        [TestMethod]
        public void TestMethod4()
        {
            string arg = "рус";
            string a = QueryControl.MakeQuery(arg);
            Assert.AreEqual(a, "http://www.omdbapi.com/?t=" + arg + "&y=&plot=full&r=json");
        }

        [TestMethod]
        public void TestMethod5()
        {
            string arg = "Title";
            string a = QueryControl.MakeQuery(arg);
            Assert.AreEqual(a, "http://www.omdbapi.com/?t=" + arg + "&y=&plot=full&r=json");
        }
    }
}

