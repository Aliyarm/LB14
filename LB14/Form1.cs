using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] array = new int[100];
        Random rand = new();
        int findValue, count;

        private void button1_Click(object sender, EventArgs e)
        {
            findValue = Convert.ToInt32(textBox1.Text);
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            count = 0;
            listBox1.Items.Add("Исходный массив:");
            for (int i = 0; i < 100; i++)
            {
                array[i] = rand.Next(-100, 100);
                listBox1.Items.Add("array[" + i + "] = " + array[i].ToString());
            }
            for (int i = 0; i < array.Length; i++)
            {
                count++;
                if (array[i] == findValue)
                {
                    MessageBox.Show("Индекс элемета: " + i + "; Количество итераций: " + count + ".");
                    break;
                }
                else if (i == array.Length - 1)
                {
                    MessageBox.Show("Нет нужного элемента.");
                }
            }
        }

        private int IndexOf(ref int[] array, int findValue, int Left, int Right)
        {
            int x = (Left + Right) / 2;
            count++;
            if (array[x] == findValue)
                return x;
            if ((x == Left) || (x == Right))
                return -1;
            if (array[x] < findValue)
                return IndexOf(ref array, findValue, x, Right);
            else
                return IndexOf(ref array, findValue, Left, x);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            count = 0;
            listBox2.Items.Add("Отсортированный массив:");
            for (int i = 0; i < 100; i++)
            {
                for (int j = i + 1; j < 100; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
                listBox2.Items.Add("array[" + i + "] = " + array[i].ToString());
            }
            MessageBox.Show("Индекс элемента: " + IndexOf(ref array, findValue, 0, array.Length - 1).ToString() + "; Количество итераций: " + count + ".");
        }
    }
}