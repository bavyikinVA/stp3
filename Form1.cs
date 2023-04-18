using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                string str = Reader1();
                str = str.ToLower();
                string[] s = str.Split('.');
                string s1 = s[0];
                textBox2.Text = s1;
                string s2 = s[1];
                textBox3.Text = s2;
                string[] words1 = s1.Split(' ');
                string[] words2 = s2.Split(' ');
                int Lmax = Math.Max(words1.Length, words2.Length);
                double m = check(words1, words2, Lmax);
                string procent = Convert.ToString((m / words1.Length) * 100);
                label5.Text = procent + "%";
            }
            if (radioButton1.Checked)
            {
                string str1 = textBox2.Text;
                string str2 = textBox3.Text;

                string[] words1 = Strings(str1);
                string[] words2 = Strings(str2);

                int Lmax = Math.Max(words1.Length, words2.Length);
                double m = check(words1, words2, Lmax);
                string procent = Convert.ToString((m / words1.Length) * 100);
                label5.Text = procent + "%";
            }

        }

        public string Reader1()
        {
            bool flag = true;
            StreamReader file = null;
            do
            {
                try
                {
                    string fname;
                    fname = textBox1.Text;
                    file = new StreamReader(fname);
                    flag = true;
                }
                catch (Exception)
                {
                    textBox1.Text = "Ошибка! Данный файл не найден!";
                    Environment.Exit(0); // выход из программы
                    flag = false;
                }
            } while (!flag);

            string text = "";
            while (true)
            {
                string s0 = file.ReadLine();
                if (s0 == null) break;
                text += s0;
                
            }
            return text;
        }

        public static double check(string[] words1, string[] words2, int Lmax)
        {
            int k = 0;
            foreach (var word1 in words1)
            {
                foreach (var word2 in words2)
                {
                    if (word1 == word2)
                    {
                        k++;
                    }
                }
            }
            return k;
        }

        public static string[] Strings(string str)
        {
            str = str.ToLower();
            string[] words = str.Split(' ');
            return words;
        }
    }
}
