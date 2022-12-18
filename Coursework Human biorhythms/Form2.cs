using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_Human_biorhythms
{
    public partial class Form2 : Form
    {
        public Form2(Dictionary<char, int> user1, Dictionary<char, int> user2, string name1, string name2)
        {
            InitializeComponent();
            label1.Text = "Квадрат Піфагора для: " + name1;
            label2.Text = "Квадрат Піфагора для: " + name2;
            label3.Text = Correction(user1['1'], 1);
            label8.Text = Correction(user1['2'], 2);
            label11.Text = Correction(user1['3'], 3);
            label4.Text = Correction(user1['4'], 4);
            label7.Text = Correction(user1['5'], 5);
            label10.Text = Correction(user1['6'], 6);
            label5.Text = Correction(user1['7'], 7);
            label6.Text = Correction(user1['8'], 8);
            label9.Text = Correction(user1['9'], 9);

            label20.Text = Correction(user2['1'], 1);
            label17.Text = Correction(user2['2'], 2);
            label14.Text = Correction(user2['3'], 3);
            label19.Text = Correction(user2['4'], 4);
            label16.Text = Correction(user2['5'], 5);
            label13.Text = Correction(user2['6'], 6);
            label18.Text = Correction(user2['7'], 7);
            label15.Text = Correction(user2['8'], 8);
            label12.Text = Correction(user2['9'], 9);

            int twofiveeight1 = user1['2'] + user1['5'] + user1['8'];
            int threefiveseven1 = user1['3'] + user1['5'] + user1['7'];
            int twofiveeight2 = user2['2'] + user2['5'] + user2['8'];
            int threefiveseven2 = user2['3'] + user2['5'] + user2['7'];
            label21.Text = "Характер:\n" + "    " + user1['1']+ " — " + user2['1'];
            label22.Text = "Сімейність:\n"+"     "+ twofiveeight1 + " — " + twofiveeight2;
            label23.Text = "Темперамент:\n" +"      "+ threefiveseven1+ " — " + threefiveseven2;
        }

        private string Correction(int a, int b)
        {
            string temp = "";
            if (a == 0) temp = "–––";
            for (int i = 0; i < a; i++) temp += b;     
            return temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Close();
        }

      
    }
}
