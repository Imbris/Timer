using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using timer;


namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private bool status;
        private object locker = new object();

        [TestInitialize]
        public void Init()
        {
            status = true;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Thread thread = new Thread(() =>
            {
                lock (locker)
                {
                    Form1 form = new Form1();
                    try
                    {
                        form.Show();
                        Assert.IsTrue(form.Visible);
                        form.Close();
                        Assert.IsFalse(form.Visible);
                    }
                    catch (Exception exc)
                    {
                        status = false;
                    }
                }
            });
        }
    }
}
