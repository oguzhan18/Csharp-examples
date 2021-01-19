using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void altdizinarama(String yol)
        {
            string[] dosya;
            dosya = Directory.GetFiles(yol, "*.mp3");
            for (int i = 0; i < 1; i++)
            {
                listBox1.Items.AddRange(dosya);
                listBox2.Items.AddRange(dosya);
                string[] dizin;
                dizin = Directory.GetDirectories(yol);
                for (int s = 0; s < dizin.Length; s++)
                {
                    altdizinarama(dizin[s]);
                }
            }
        }
        void dosya_oku()
        {
            FileStream fs = new FileStream("dosyalar.txt", FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string yazi = sw.ReadLine();
            while (yazi != null)
            {
                listBox2.Items.Add(yazi.ToString());
                listBox1.Items.Add(yazi.ToString());
                yazi = sw.ReadLine();
            }
            sw.Close();
            fs.Close();
            for (int a = 0; a < listBox1.Items.Count; a++)
            {
                listBox1.Items[a] = listBox1.Items[a].ToString().Split('\\').Last();
                listBox1.Items[a] = listBox1.Items[a].ToString().Replace(".mp3", "");
            }
        }
        void dosyayi_yaz(string yazilacak)
        {
            FileStream fs = new FileStream(@"dosyalar.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(yazilacak.ToString());
            sw.Flush();
            fs.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            string[] dosya;
            folderBrowserDialog1.ShowDialog();
            try
            {
                String yol = folderBrowserDialog1.SelectedPath;
                dosya = Directory.GetFiles(yol, "*.mp3");
                for (int i = 0; i < 1; i++)
                {
                    listBox1.Items.AddRange(dosya);
                    listBox2.Items.AddRange(dosya);
                    string[] dizin;
                    dizin = Directory.GetDirectories(yol);
                    for (int s = 0; s < dizin.Length; s++)
                    {
                        altdizinarama(dizin[s]);
                    }
                    if (listBox1.Items.Count == 0)
                    {
                        listBox1.Items.Add("Müzik Bulunamadı!");
                        break;
                    }
                    else
                    {
                        for (int a = 0; a < listBox1.Items.Count; a++)
                        {
                            listBox1.Items[a] = listBox1.Items[a].ToString().Split('\\').Last();
                            listBox1.Items[a] = listBox1.Items[a].ToString().Replace(".mp3", "");
                        }
                        string yazdir;
                        for (int x = 0; x <= listBox2.Items.Count; x++)
                        {
                            yazdir = listBox2.Items[x].ToString();
                            dosyayi_yaz(yazdir.ToString());
                        }
                    }
                }
            }
            catch { }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            for (int b = 0; b <= listBox1.Items.Count; b++)
            {
                if (listBox1.Items[b] == listBox1.SelectedItem)
                {
                    axWindowsMediaPlayer1.URL = listBox2.Items[b].ToString();
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    break;
                }
            }
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("dosyalar.txt"))
            {
                dosya_oku();
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            File.Delete("dosyalar.txt");
            button2.Enabled = false;
            button1.Enabled = true;
            button1.PerformClick();
        }
    }
}