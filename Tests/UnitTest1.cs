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
            thread.Start();
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void TestConvertToInt()
        {
            Thread thread = new Thread(() =>
            {
                lock (locker)
                {
                    Form1 form = new Form1();
                    try
                    {
                        form.Show();
                        Assert.AreEqual(form.convert_to_int("4", "абракадабра"), 4);
                        Assert.AreEqual(form.convert_to_int("ыаыпц", "абракадабра"), 0);
                        Assert.AreEqual(form.convert_to_int("634 орлор", "абракадабра"), 0);
                        Assert.AreEqual(form.convert_to_int("632", "абракадабра"), 632);
                        Assert.AreEqual(form.convert_to_int("632l2krj34", "абракадабра"), 632);
                        form.Close();
                   }
                    catch (Exception exc)
                    {
                        status = false;
                    }
                }
            });
            thread.Start();
            Thread.Sleep(5000);
        }
    }
}
