using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWords
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadTheme();
        }
        private void LoadTheme()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Вы не ввели название распоряжения!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не ввели преамбулу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Вы не ввели основной текст распоряжения!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Вы не выбрали ФИО подписанта!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Вы не выбрали ФИО визирующего!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var helper = new WordHelper("РАСПОРЯЖЕНИЕ.docx");
        
            var items = new Dictionary<string, string>
            {
         
                {"<НАЗВАНИЕ ДОКУМЕНТА>", textBox7.Text},
                { "<ПРЕАМБУЛА>", textBox1.Text},
                { "<ОСНОВНОЙ ТЕКСТ>", textBox4.Text},
                { "<ОСНОВНОЙ ТЕКСТ1>", textBox5.Text},
                { "<ОСНОВНОЙ ТЕКСТ2>", textBox9.Text},
                { "<ОСНОВНОЙ ТЕКСТ3>", textBox10.Text},
                { "<ОСНОВНОЙ ТЕКСТ4>", textBox8.Text},
                {"<ФИО ПОДПИСАНТА>", comboBox3.Text },
                {"<ДОЛЖНОСТЬ ПОДПИСАНТА>", textBox3.Text },
                { "<ДОЛЖНОСТЬ ПЕРВОГО ВИЗИРУЮЩЕГО>", textBox2.Text },
                { "<ФИО ПЕРВОГО>", comboBox2.Text },
       

            };
            helper.Process(items);

            textBox7.Text = "";
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox8.Text = "";


            textBox4.Visible = true;
            label1.Visible = true;
            textBox5.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox8.Visible = false;

            label2.Visible = false;
            label16.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void должностиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "wordShablonDataSet1.Персонал". При необходимости она может быть перемещена или удалена.
            this.персоналTableAdapter1.Fill(this.wordShablonDataSet1.Персонал);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "wordShablonDataSet.Персонал". При необходимости она может быть перемещена или удалена.
            this.персоналTableAdapter.Fill(this.wordShablonDataSet.Персонал);



        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxStyle2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if ((textBox9.TextLength >= 229) || (e.KeyCode == Keys.Enter))
            {
                textBox10.Visible = true;
                this.textBox10.Select();
                e.SuppressKeyPress = true;

                //Смищение
                label1.Visible = false;
                textBox5.Location = new Point(27, 285);
                label2.Location = new Point(6, 304);
                textBox9.Location = new Point(27, 336);
                label16.Location = new Point(6, 348);

                textBox4.Visible = false;




                label14.Visible = true;

                label17.Visible = true;
                check2.Visible = true;

            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if ((textBox4.TextLength >= 229) || (e.KeyCode == Keys.Enter))
            {
                textBox5.Visible = true;
                this.textBox5.Select();
                e.SuppressKeyPress = true;
                label2.Visible = true;
                //check2.Visible = false;
                //label17.Visible = false;
                //check1.Visible = true;
                //label3.Visible = true;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if ((textBox5.TextLength >= 229) || (e.KeyCode == Keys.Enter))
            {
                textBox9.Visible = true;
                this.textBox9.Select();
                e.SuppressKeyPress = true;
               // label6.Visible = false;
                label16.Visible = true;
                //check2.Visible = false;
                //label17.Visible = false;
                //check1.Visible = true;
                //label3.Visible = true;
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if ((textBox10.TextLength >= 229) || (e.KeyCode == Keys.Enter))
            {
                textBox8.Visible = true;
                this.textBox8.Select();
                e.SuppressKeyPress = true;

                label2.Visible = false;
                textBox5.Visible = false;
                label15.Visible = true;
                textBox9.Location = new Point(27, 285);
                label16.Location = new Point(6, 304);
                textBox10.Location = new Point(27, 336);
                label14.Location = new Point(6, 348);



                check2.Visible = false;
                label17.Visible = false;
                check1.Visible = true;
                label8.Visible = true;
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox10.TextLength >= 229)
            {
                MessageBox.Show("Сохранение не выполнено. Перепроверьте внесенные данные и попробуйте снова!");
            }
        }

        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            if (check1.Checked == false)
            {
                textBox8.Visible = true;
                textBox10.Visible = true;

                label15.Visible = true;
                label1.Visible = false;
                textBox4.Visible = false;
                label14.Visible = true;
                label2.Visible = false;
                textBox5.Visible = false;

                //Смещение
                textBox9.Location = new Point(27, 285);
                label16.Location = new Point(6, 304);
                textBox10.Location = new Point(27, 336);
                label14.Location = new Point(6, 348);



            }
            if (check1.Checked == true)
            {
                textBox8.Visible = false;
                textBox10.Visible = false;
                label1.Visible = true;
                textBox4.Visible = true;
                label14.Visible = false;
                label2.Visible = true;
                textBox5.Visible = true;
                label15.Visible = false;

                textBox4.Location = new Point(27, 285);
                label1.Location = new Point(6, 304);
                textBox5.Location = new Point(27, 336);
                label2.Location = new Point(6, 348);
                textBox9.Location = new Point(27, 387);
                label16.Location = new Point(6, 396);
            }
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            if (check2.Checked == false)
            {
                textBox10.Visible = true;
                label1.Visible = false;
                textBox4.Visible = false;
                label14.Visible = true;

                //Смеение

                textBox5.Location = new Point(27, 285);
                label2.Location = new Point(6, 304);
                textBox9.Location = new Point(27, 336);
                label16.Location = new Point(6, 348);




            }
            if (check2.Checked == true)
            {
                textBox10.Visible = false;
                label1.Visible = true;
                textBox4.Visible = true;
                label14.Visible = false;

                //Смеение

                textBox4.Location = new Point(27, 285);
                label1.Location = new Point(6, 304);
                textBox5.Location = new Point(27, 336);
                label2.Location = new Point(6, 348);
                textBox9.Location = new Point(27, 387);
                label16.Location = new Point(6, 396);


            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
