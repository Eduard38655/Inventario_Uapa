using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {


            InitializeComponent();
            EditClass editItems= new EditClass();
            ShowItems formItems =new ShowItems();
            ShowItems.Validate_text(textBox1.Text, textBox2.Text, button3,button4);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            // Obtener valor del datagrid
            if (e.RowIndex >= 0)
            {
 
                string click = dataGridView1.Rows[e.RowIndex].Cells["ProductosID"].Value.ToString();

                ShowItems.dataValor(textBox2, textBox1, textBox3, textBox4, textBox5, textBox6, click.ToString());

            }





        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
         }

        private void button1_Click(object sender, EventArgs e)
        {
            

            ShowItems.GetItem(textBox2, textBox1,textBox3,textBox4,textBox5,textBox6,dataGridView1,button3,button4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             ShowItems.ScreenItems(dataGridView1,textBox2);
 


        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            EditClass.EditarItems(textBox2, textBox1, textBox3, textBox4, textBox5, textBox6);
            ShowItems.ScreenItems(dataGridView1,textBox2);



        }

        private void button4_Click(object sender, EventArgs e)
        {
            EliminarItem.EliminarValor(textBox1,textBox2);
            ShowItems.ScreenItems(dataGridView1, textBox2);
        }

        private void colorDialog2_HelpRequest(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
