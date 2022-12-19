using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Coursework_Human_biorhythms
{
    public partial class Form1 : Form
    {
        private bool physicalIsVisible;
        private bool emotionalIsVisible;
        private bool intellectualIsVisible;
        private bool cBox1, cBox2;
        private int i = 0, n = 30;
        private string name;
        Dictionary<string, DateTime> people = new Dictionary<string, DateTime>();





        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Today;
            comboBox3.Items.Add("Неділя");
            comboBox3.Items.Add("Дві неділі");
            comboBox3.Items.Add("Місяць");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            i++;
            //кількість днів до побудови
            string comBox = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);
            if (comBox == "Неділя") n = 7;
            else if (comBox == "Дві неділі") n = 14;
            else n = 30;
            //стирання попередніх графіків
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            if (textBox1.Text != "") name = textBox1.Text;
            else name = "Користувач № " + i;
            DateTime one = dateTimePicker1.Value, two = dateTimePicker2.Value;
            //запам'ятовування імен
            people[name] = one;
            comboBox1.Items.Add(name);
            comboBox2.Items.Add(name);

            //Розрахунок біоритмів на обраний користувачем день
            int differenceInDays = (two - one).Days;
            double actualPhysicalBiorhytm = Math.Sin(2 * Math.PI * differenceInDays / 23) * 100;
            label6.Text = "Your Fhysical Biorhytm: " + Math.Round(actualPhysicalBiorhytm, 0) + "%";
            double actualEmotionalBiorhytm = Math.Sin(2 * Math.PI * differenceInDays / 28) * 100;
            label7.Text = "Your Emotional Biorhytm: " + Math.Round(actualEmotionalBiorhytm, 0) + "%";
            double actualIntellectualBiorhytm = Math.Sin(2 * Math.PI * differenceInDays / 33) * 100;
            label8.Text = "Your Intellectual Biorhytm: " + Math.Round(actualIntellectualBiorhytm, 0) + "%";
            //побудова графіків    
            for (int i = 0; i < n; i++)
            {
                double physical = Math.Sin(2 * Math.PI * differenceInDays / 23);
                double emotional = Math.Sin(2 * Math.PI * differenceInDays / 28);
                double intellectual = Math.Sin(2 * Math.PI * differenceInDays / 33);
                chart1.Series[0].Points.AddXY(two.Day + "." + two.Month + "." + two.Year, physical);
                chart1.Series[1].Points.AddXY(two.Day + "." + two.Month + "." + two.Year, emotional);
                chart1.Series[2].Points.AddXY(two.Day + "." + two.Month + "." + two.Year, intellectual);
                differenceInDays += 1;   //наступний день
                two = two.AddDays(1);    //наступний день
            }
            if (!physicalIsVisible)
            {
                chart1.Series[0].Points.Clear();
                label6.Text = "";
            }
            if (!emotionalIsVisible)
            {
                chart1.Series[1].Points.Clear();
                label7.Text = "";
            }
            if (!intellectualIsVisible)
            {
                chart1.Series[2].Points.Clear();
                label8.Text = "";
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //отримуємо дати днів народження
            string name1 = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            string name2 = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            DateTime one = people[name1];
            DateTime two = people[name2];
            double differenceInDays = Math.Abs((two - one).Days);
            //обрахунок сумісності когожного біоритму та загальної сумісності
            double compatibilityPhysical = Math.Floor((differenceInDays / 23 - Math.Floor(differenceInDays / 23)) * 100);
            double compatibilityEmotional = Math.Floor((differenceInDays / 28 - Math.Floor(differenceInDays / 28)) * 100);
            double compatibilityIntellectual = Math.Floor((differenceInDays / 33 - Math.Floor(differenceInDays / 33)) * 100);
            double compatibilityGeneral = Math.Floor((compatibilityPhysical + compatibilityEmotional + compatibilityIntellectual) / 3);
            if (differenceInDays == 0) //якщо народилися одного дня
            {
                compatibilityPhysical = 100;
                compatibilityEmotional = 100;
                compatibilityIntellectual = 100;
                compatibilityGeneral = 100;
            }
            string a = "Сумісніть " + name1 + " з " + name2 + "\nФізичні біоритми: " + compatibilityPhysical + "%" + "\nЕмоційні біоритми: "
                + compatibilityEmotional + "%" + "\nІнтелектуальні біоритми: " + compatibilityIntellectual + "%" + "\nЗагальна сумісніть: " 
                + compatibilityGeneral + "%";
            MessageBox.Show(a);
        }


        public void squareOfPythagoras(DateTime t, Dictionary<char, int> numbers)
        {
            int temp = 0, temp1 = 0;
            string a = t.ToString("ddMMyyyy");//дата в рядок, для полегшення обрахунку
            for (int i = 0; i < 8; i++) temp1 += Convert.ToInt32(a[i]); //обрахунок першого числа
            int temp2 = temp1 % 10 + temp1 / 10;//обрахунок другого числа
            if (0 != Convert.ToInt32(a[0])) temp = Convert.ToInt32(a[0]);
            else Convert.ToInt32(a[1]);
            int temp3 = temp1 - temp * 2;//обрахунок третього числа
            int temp4 = temp3 % 10 + temp3 / 10;//обрахунок четвертого числа
            string num = "" + temp1 + temp2 + temp3 + temp4 + a;//отримане число і дата
            foreach (char n in num) if (n >= 49 && n<=57) numbers[n]+=1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dictionary<char, int> numbers1 = new Dictionary<char, int>()
        {
            {'1',0 },
            {'2',0 },
            {'3',0 },
            {'4',0 },
            {'5',0 },
            {'6',0 },
            {'7',0 },
            {'8',0 },
            {'9',0 }

        };
            Dictionary<char, int> numbers2 = new Dictionary<char, int>()
        {
            {'1',0 },
            {'2',0 },
            {'3',0 },
            {'4',0 },
            {'5',0 },
            {'6',0 },
            {'7',0 },
            {'8',0 },
            {'9',0 }

        };
            string name1 = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            string name2 = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            DateTime one = people[name1];
            DateTime two = people[name2];
            squareOfPythagoras(one, numbers1);
            squareOfPythagoras(two, numbers2);
            Form2 form2 = new Form2(numbers1, numbers2, name1, name2);
            form2.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            physicalIsVisible = !physicalIsVisible;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            emotionalIsVisible = !emotionalIsVisible;   
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBox1 = true;
            if (cBox2)
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBox2 = true;
            if (cBox1)
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            intellectualIsVisible = !intellectualIsVisible;
        }
    }
}
