using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private string _badFileName = @"C:\Users\Tytus\Desktop\trial2.txt";

        public TestContext TestContext;

        [TestMethod]
        public void FileNameExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(@"C:\Users\Tytus\Desktop\developer\trial.txt");

            Assert.IsTrue(fromCall);
        }
        [TestMethod]
        public void FileNameDoesNotExist()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine(@"Checking file" + _badFileName);
            fromCall = fp.FileExists(_badFileName);

            Assert.IsFalse(fromCall);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameIsNullOrEmpty_UsingAttribute()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");
        }
        [TestMethod]
        public void FileNameIsNullOrEmpty_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();

            try
            {
                TestContext.WriteLine(@"Checking empty file name");
                fp.FileExists("");
            }
            catch (Exception e)
            {
                return;
            }

            Assert.Fail();
        }
    }
}
