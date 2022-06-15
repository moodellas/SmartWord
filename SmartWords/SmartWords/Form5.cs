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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void персоналBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.персоналBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.wordShablonDataSet);

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "wordShablonDataSet.Персонал". При необходимости она может быть перемещена или удалена.
            this.персоналTableAdapter.Fill(this.wordShablonDataSet.Персонал);

        }

        private void button1_Click(object sender, EventArgs e)
        {         
                this.персоналBindingSource.AddNew();
                MessageBox.Show("Введите данные в пустые поля и нажмите сохранить!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.инициалыИФамилияTextBox.Select();

            //if (инициалыИФамилияTextBox.Text == "")
            //{
            //    MessageBox.Show("Заполните пустые поля!");
            //    return;
            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно хотите безвозвратно удалить данные?!", "Внимание!?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                персоналBindingSource.RemoveCurrent();
            }
            else if (dialogResult == DialogResult.No)
            {
                return; 
            }

            MessageBox.Show("Вы удалили данные", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.персоналBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.wordShablonDataSet);
                DialogResult dialogResult = MessageBox.Show("Сохранение прошло успешно!","Уведомление" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Сохранение не выполнено. Перепроверьте внесенные данные и попробуйте снова!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.персоналBindingSource.MoveFirst();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.персоналBindingSource.MovePrevious();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.персоналBindingSource.MoveNext();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.персоналBindingSource.MoveLast();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < персоналDataGridView.RowCount; i++)
            {
                персоналDataGridView.Rows[i].Selected = false;
                for (int j = 0; j < персоналDataGridView.ColumnCount; j++)
                    if (персоналDataGridView.Rows[i].Cells[j].Value != null)
                        if (персоналDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            персоналDataGridView.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            персоналDataGridView.ClearSelection();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void button15_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            персоналBindingSource.Filter = "ИнициалыИФамилия LIKE '" + textBox2.Text + "%'";
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void инициалыИФамилияTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.должностьTextBox.Select();
                e.SuppressKeyPress = true;
            }
        }

        private void должностьTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button2.Select();
                e.SuppressKeyPress = true;
            }
        }

        private void инициалыИФамилияTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'Я') && (l < 'а' || l > 'я') && l != '\b' && l != '.')
            {
                e.Handled = true;
            }

        }

        private void должностьTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'Я') && (l < 'а' || l > 'я') && l != '\b' && l != '.' && l != ' ')
            {
                e.Handled = true;
            }
        }
        public string oldText = "";
        public string currText = "";

        private void инициалыИФамилияTextBox_TextChanged(object sender, EventArgs e)
        {
            oldText = currText;
            currText = инициалыИФамилияTextBox.Text;
            if (oldText.Length > currText.Length)
            {
                oldText = currText;
                return;
            }
            if (инициалыИФамилияTextBox.Text.Length == currText.Length)
            {
                if (инициалыИФамилияTextBox.SelectionStart == 1 || инициалыИФамилияTextBox.SelectionStart == 3)
                {
                    инициалыИФамилияTextBox.Text += ".";
                    инициалыИФамилияTextBox.SelectionStart = инициалыИФамилияTextBox.Text.Length;
                }
            }
            if (инициалыИФамилияTextBox.Text.Length == currText.Length)
            {
                if (инициалыИФамилияTextBox.SelectionStart == 4)
                {
                    инициалыИФамилияTextBox.Text += " ";
                    инициалыИФамилияTextBox.SelectionStart = инициалыИФамилияTextBox.Text.Length;
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void персоналDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void должностьTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
