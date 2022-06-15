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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadTheme();
        }
        private void LoadTheme()
        {
            //foreach (Control btns in this.Controls)
            //{
            //    if (btns.GetType() == typeof(Button))
            //    {
            //        Button btn = (Button)btns;
            //        btn.BackColor = ThemeColor.PrimaryColor;
            //        btn.ForeColor = Color.White;
            //        btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox6.Text == "")
            {
                MessageBox.Show("Вы не ввели кому адресовано письмо!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не ввели преамбулу!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Вы не обращение письма!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Вы не ввели освновной текст письма!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("Вы не ввели название письма!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Вы не выбрали подписанта письма!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Вы не выбрали визирующего письма!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

            var helper = new WordHelper2("СопроводительныйДокумент.docx");

            var items = new Dictionary<string, string>
            {
                { "<КОМУ>", textBox6.Text},
                {"<ПРЕАМБУЛА>", textBox1.Text },
                {"<ОБРАЩЕНИЕ>", textBox3.Text },
                { "<ОСНОВНОЙ ТЕКСТ1>", textBox4.Text},
                { "<ОСНОВНОЙ ТЕКСТ2>", textBox7.Text},
                { "<ОСНОВНОЙ ТЕКСТ3>", textBox8.Text},
                { "<ОСНОВНОЙ ТЕКСТ4>", textBox9.Text},
                { "<ОСНОВНОЙ ТЕКСТ5>", textBox10.Text},
                {"<ФИО ПОДПИСАНТА>", comboBox1.Text },
                { "<ДОЛЖНОСТЬ ПОДПИСАНТА>", textBox2.Text},
                {"<ФИО ВИЗИРУЮЩЕГО>", comboBox2.Text },
                { "<ДОЛЖНОСТЬ ВИЗИРУЮЩЕГО>", textBox5.Text},
                

            };
            helper.Process(items);


            textBox1.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";

            textBox4.Visible = true;
            label7.Visible = true;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;

            label9.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "wordShablonDataSet1.Персонал". При необходимости она может быть перемещена или удалена.
            this.персоналTableAdapter1.Fill(this.wordShablonDataSet1.Персонал);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "wordShablonDataSet.Персонал". При необходимости она может быть перемещена или удалена.
            this.персоналTableAdapter.Fill(this.wordShablonDataSet.Персонал);


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void smartWordsDataSet2BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if ((textBox4.TextLength >= 229) || (e.KeyCode == Keys.Enter))
            {
                textBox7.Visible = true;
                this.textBox7.Select();
                e.SuppressKeyPress = true;
                label9.Visible = true;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if ((textBox7.TextLength >= 229) || (e.KeyCode == Keys.Enter))
            {
                textBox8.Visible = true;
                this.textBox8.Select();
                e.SuppressKeyPress = true;
                label14.Visible = true;
             
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if ((textBox8.TextLength >= 229) || (e.KeyCode == Keys.Enter))
            {
                textBox9.Visible = true;
                this.textBox9.Select();
                e.SuppressKeyPress = true;
                label7.Visible = false;
                textBox4.Visible = false;
                label15.Visible = true;


                //Смещение
                textBox7.Location = new Point(20, 324);
                label9.Location = new Point(-1, 340);
                textBox8.Location = new Point(20, 375);
                label14.Location = new Point(-1, 390);



                check2.Visible = true;
                label17.Visible = true;



            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if ((textBox9.TextLength >= 229) || (e.KeyCode == Keys.Enter))
            {
                textBox10.Visible = true;
                this.textBox10.Select();
                e.SuppressKeyPress = true;
                label9.Visible = false;
                textBox7.Visible = false;
                label16.Visible = true;

                //Смещение

                textBox8.Location = new Point(20, 324);
                label14.Location = new Point(-1, 340);
                textBox9.Location = new Point(20, 375);
                label15.Location = new Point(-1, 390);



                check2.Visible = false;
                label17.Visible = false;
                check1.Visible = true;
                label3.Visible = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.TextLength >= 229)
            {
                MessageBox.Show("Сохранение не выполнено. Перепроверьте внесенные данные и попробуйте снова!");
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (check1.Checked == false)
            {
                textBox9.Visible = true;               
                textBox10.Visible = true;
                textBox4.Visible = false;
                textBox7.Visible = false;

                label7.Visible = false;
                label15.Visible = true;
                label9.Visible = false;
                label16.Visible = true;

                //Смещение

                textBox9.Location = new Point(20, 375);
                label15.Location = new Point(-1, 390);
                textBox8.Location = new Point(20, 324);
                label14.Location = new Point(-1, 340);

            }
            if (check1.Checked == true)
            {
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox4.Visible = true;
                textBox7.Visible = true;
                label7.Visible = true;
                label15.Visible = false;
                label9.Visible = true;
                label16.Visible = false;

                //Смещение

                textBox7.Location = new Point(20, 375);
                label9.Location = new Point(-1, 390);
                textBox8.Location = new Point(20, 426);
                label14.Location = new Point(-1, 441);
            }
        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            if (check2.Checked == false)
            {
                textBox9.Visible = true;
                label7.Visible = false;
                textBox4.Visible = false;
                label15.Visible = true;

                //Смещение

                textBox8.Location = new Point(20, 375);
                label14.Location = new Point(-1, 390);
                textBox7.Location = new Point(20, 324);
                label9.Location = new Point(-1, 340);




            }
            if (check2.Checked == true)
            {
                textBox9.Visible = false;
                textBox8.Visible = true;
                label7.Visible = true;
                label15.Visible = false;
                textBox4.Visible = true;
                label7.Visible = true;

                //Смещение

                textBox8.Location = new Point(20, 426);
                label14.Location = new Point(-1, 441);
                textBox7.Location = new Point(20, 375);
                label9.Location = new Point(-1, 390);
            }
        }

        private void check3_CheckedChanged(object sender, EventArgs e)
        {
            if (check3.Checked == false)
            {
                textBox11.Visible = false;
            }
            if (check3.Checked == true)
            {
                textBox11.Visible = true;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
