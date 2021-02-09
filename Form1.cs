using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Klasa_kurs_i_aplikacija
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader f = new StreamReader("kursevi.txt");
                Kurs k = new Kurs();
                k.CitajIzFajla(f);
                Kurs najskuplji = new Kurs(k);

                while (!f.EndOfStream)
                {
                    k.CitajIzFajla(f);
                    if (k.SkupljiOd(najskuplji))
                        najskuplji.Kopiraj(k); // najskuplji=new Kurs(k);
                }
                f.Close();
                textBox1.Text = najskuplji.ToString();
            }
            catch (Exception izuzetak)
            {
                MessageBox.Show(izuzetak.Message, "Greska");
            }
        }
    }
}