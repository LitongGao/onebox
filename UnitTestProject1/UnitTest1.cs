using SocketClient;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SocketClient.Tests
{
    [TestClass()]
    [DeploymentItem("test2.xml")]
    [DeploymentItem("test1.xml")]
    public class UnitTest1
    {
        #region TextContext
        private TestContext testContext;
        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }
        #endregion
        public string field1;
        public string fields
        {
            get;
            set;
        }
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Console.WriteLine("ClassInitialize from here");
            Console.ReadKey();
        }

        [TestInitialize]
        public static void TestInitialize()
        {
            Console.WriteLine("TestInitialize from here");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Console.WriteLine("TestCleanup from here");
        }
        [ClassCleanup]
        public void Classup()
        {
            Console.WriteLine("Class cleanup from here");
        }

        [TestMethod()]
        [Owner("Peter")]
        [Description("Verify test Send File")]
        public void SendFileTest()
        {
            Assert.IsNull(field1);
        }

        [TestMethod()]
        public void SendMessageTest()
        {
            Assert.Fail();
        }
    }
}

