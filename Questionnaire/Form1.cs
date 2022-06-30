using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Questionnaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<ancet> ac = new List<ancet>();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                ac.Add(new ancet(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text));
                UpdateList();
            }
            textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
        }
        private void UpdateList()
        {
            listBox1.DataSource = null;
            listBox1.DisplayMember = nameof(ancet);
            listBox1.DataSource = ac;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int a = listBox1.SelectedIndex;
                ac.RemoveAt(a);
                UpdateList();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int a = listBox1.SelectedIndex;
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    ac[a].Name = textBox1.Text; ac[a].Famil = textBox2.Text; ac[a].Email = textBox3.Text; ac[a].Tel = textBox4.Text;
                    UpdateList();
                }
                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream fs = File.Create("testB.bin"))
            {
                bin.Serialize(fs, ac);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (Stream fs = File.OpenRead("testB.bin"))
            {
                ac = bin.Deserialize(fs) as List<ancet>;
            }
            UpdateList();
        }
    }
}
