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
        [TestInitialize]
        public void Init()
        {
            status = true;
        }
        
        /*
        [TestMethod]
        public void testWrong()
        {
            Assert.AreEqual(true, false);
            Assert.AreEqual(1, 2);
        }*/


        [TestMethod]
        public void TestConvertToInt()
        {
           
            Form1 form = new Form1();
            form.Show();
            Assert.AreEqual(form.convert_to_int("4", "абракадабра"), 4);
            Assert.AreEqual(form.convert_to_int("ыаыпц", "абракадабра"), 0);
            Assert.AreEqual(form.convert_to_int("634 орлор", "абракадабра"), 0);
            Assert.AreEqual(form.convert_to_int("632", "абракадабра"), 632);
            //Assert.AreEqual(form.convert_to_int("632l2krj34", "абракадабра"), 632);
            form.Close();            
        }

        [TestMethod]
        public void TestStart()
        {

            Form1 form = new Form1();
            form.Show();
            int h, m, s;

            form.set_hourstext("0");
            form.set_minutestext("0");
            form.set_secondstext("0");
            form.StartTimer("0","0","0");
            Assert.AreEqual(form.get_hours(), 0);
            Assert.AreEqual(form.get_minutes(), 0);
            Assert.AreEqual(form.get_seconds(), 0);

            form.StopTimer();



            form.Close();
        }

        [TestMethod]
        public void TestPause()
        {

            Form1 form = new Form1();
            form.Show();

            form.StartTimer("0", "0", "20");
            Assert.AreEqual(form.get_pause_text(), "Пауза");
            form.PauseTimer();
            Assert.AreEqual(form.get_pause_text(), "Продолжить");
            form.PauseTimer();
            Assert.AreEqual(form.get_pause_text(), "Пауза");



            form.Close();
        }

        [TestMethod]
        public void TestErase()
        {

            Form1 form = new Form1();
            form.Show();

            form.StartTimer("3", "24", "20");
            form.StopTimer();
            Assert.AreEqual(0, form.get_hours());
            Assert.AreEqual(0, form.get_minutes());
            Assert.AreEqual(0, form.get_seconds());


            form.Close();
        }


    }
}
