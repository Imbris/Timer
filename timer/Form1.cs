using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace timer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int h,m,s; //часы, минуты, секунды
        bool stop = true;

        public int get_hours() {
            return h;
        }

        public int get_minutes()
        {
            return m;
        }

        public int get_seconds()
        {
            return s;
        }

        public void set_hourstext(string text)
        {
            textBox1.Text = text;
        }

        public void set_minutestext(string text)
        {
            textBox2.Text = text;
        }

        public void set_secondstext(string text)
        {
            textBox3.Text = text;
        }

        public string get_pause_text() { 
            return button2.Text;
        }



        public int convert_to_int(object value, string text) {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Неверный формат " + text + "! Введите число");
            }
            return 0;

        }

        public void StartTimer(object hours, object minutes, object seconds) {
            //заносим написанные пользователем числа в переменные
            h = convert_to_int(hours, "часов");
            m = convert_to_int(minutes, "минут");
            s = convert_to_int(seconds, "секунд");

            if (h != 0 || m != 0 || s != 0) timer1.Start(); // запускаем таймер

        }

        private void button1_Click(object sender, EventArgs e) 
        {
            StartTimer(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s = s - 1; //каждую секунду счетчик таймера секунд уменьшается на 1
            if (s == -1) //если кончается минута, а секундная переменная становится меньше единицы, значит минута уменьшается на единицу, а секундный счетчик начинает с 59
            {
                m = m - 1;
                s = 59;
            }
            if (m==-1) //то же самое для часов
            {
                h = h - 1;
                m = 59;
            }

            if (h==0 && m==0 && s==0) // если часы, минуты и секунды в таймере будут равны нулю, значит время, указанное пользователе вышло
            {
                timer1.Stop();
                SystemSounds.Beep.Play();
                MessageBox.Show("Время вышло!");
            }

            label1.Text = Convert.ToString(h); //выводим таймер на экран, чтобы пользователь наглядно видел, сколько время осталось.
            label3.Text = Convert.ToString(m);
            label5.Text = Convert.ToString(s);

        }

        public void PauseTimer() {

            if (h != 0 || m != 0 || s != 0)
            {
                if (stop)
                {
                    timer1.Stop(); // при нажатии пользователем на кнопку "Пауза" таймер временно останавливается
                    stop = false;
                    button2.Text = "Продолжить";
                }
                else
                {
                    timer1.Start(); // при нажатии пользователем на кнопку "Продолжить" таймер запускается с места остановки
                    stop = true;
                    button2.Text = "Пауза";
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PauseTimer();
        }

        public void StopTimer() {
            timer1.Stop(); // при нажатии пользователем на кнопку "Сброс" таймер останавливается, а текст в label'ах "сбрасывается" до нуля.
            label1.Text = "0";
            label3.Text = "0";
            label5.Text = "0";
            h = 0;
            m = 0;
            s = 0;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StopTimer();
        }
    }
}
