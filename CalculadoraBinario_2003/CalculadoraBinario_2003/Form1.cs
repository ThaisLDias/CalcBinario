using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraBinario_2003
{
    public partial class Form1 : Form
    {
        string f;
        string operation;
        List<int> list = new List<int>();
        string l1;
        string ta = "";


        public Form1()
        {
            InitializeComponent();
         

         
        }


        public void digito(Object sender, EventArgs e)
        {
            Button digito = sender as Button;
            Resultado.Text += digito.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Resultado.Text = Convert.ToInt32(Resultado.Text, 2).ToString();
        }

        private void hexa(object sender, EventArgs e)
        {
            Resultado.Text = Convert.ToInt32(Resultado.Text, 2).ToString("X");
        }

        private void setaapagar(object sender, EventArgs e)
        {
            Resultado.Text = Resultado.Text.Remove(Resultado.Text.Length - 1);
            f = Resultado.Text;
        }

        private void soma(object sender, EventArgs e)
        {
            if (Resultado.Text != "")
            {
                l1 = Resultado.Text;
                Resultado.Text = null;

                operation = "soma";
            }

        }

        private void sub(object sender, EventArgs e)
        {

        }

        private void multi(object sender, EventArgs e)
        {
            if (Resultado.Text != "")
            {
                Resultado.Text = null;
                operation = "mult";
            }

        }

        private void divi(object sender, EventArgs e)
        {

        }

        private void igual(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "soma":
                    f = "00" + Resultado.Text;
                    l1 = "00" + l1;

                    ta = some(l1, f);
                    if (ta.First().ToString() == "0")
                    {
                        ta.Remove(ta.Count() - 1);
                    }
                    Resultado.Text = ta;

                    break;

                case "mult":
                    for (int q = 0; q < Convert.ToInt32(f, 2); q++)
                    {
                        Resultado.Text = some("0" + f, f);
                    }
                    break;
            }
        }


        public string some(string a, string b)
        {
            char[] charaa = a.ToCharArray();
            char[] charbb = b.ToCharArray();
            string result = "";
            int[] cc = new int[charaa.Count() + 1];


            for (int i = charaa.Count() - 1; i >= 0; i--)
            {

                int t = int.Parse(charaa[i].ToString()) + int.Parse(charbb[i].ToString());
                if (t <= 1 && cc[i] == 0)
                {
                    cc[i] = t;
                }
                else if (t > 1)
                {
                    cc[i] = 0;
                    cc[i - 1] = 1;
                }
            }
            for (int r = 0; r < cc.Count(); r++)
            {
                result += cc[r].ToString();
            }
            return result.Remove(result.Count() - 1);
        }







    }


}
