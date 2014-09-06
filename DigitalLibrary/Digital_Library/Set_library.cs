using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Digital_Library
{
    public partial class Digital_library : Form
    {


        DataTable table;
        public Digital_library()
        {
            InitializeComponent();
            select_table();
        }


        public void select_table()
        {

            SqlConnection con = Databaseconnection.Get_con();
            SqlCommand cmdd = new SqlCommand("select  * from EntryList ;", con);


            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmdd;
            table = new DataTable();
            sda.Fill(table);
            BindingSource bs = new BindingSource();
            bs.DataSource = table;
            dataGridView1.DataSource = bs;
            dataGridView2.DataSource = bs;
            dataGridView3.DataSource = bs;
            sda.Update(table);


        }






        private void Digital_library(object sender, EventArgs e)
        {

        }

        private void save_button_Click(object sender, EventArgs e)
        {
            SqlConnection con = Databaseconnection.Get_con();
            SqlCommand cmd = new SqlCommand();
            String book_name=book_textBox.Text;
            String author_name=author_textBox.Text;
            String select_term=term_comboBox.Text;
            String select_year = Year_comboBox.Text;
            String path=path_textBox.Text;
            try
            {
                if (book_name != "" && author_name != "" && select_term != "" && select_year != "" && path != "")
                {

                    cmd.CommandText = "insert into EntryList (Book_Name,Author_Name,Term,Year,Path) values ('" + book_textBox.Text + "','" + author_textBox.Text + "','" + term_comboBox.Text + "','" + Year_comboBox.Text + "','" + path_textBox.Text + "')";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Entry saved Successfully");
                    select_table();
                    con.Close();
                    
                }
                else
                {
                    MessageBox.Show("Null is not allowed");
                    con.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Exception occure please handel it");

                con.Close();
            }

        }

        private void browse_button_Click(object sender, EventArgs e)
        {
            if (type_comboBox.Text.ToString().CompareTo("PDF Files") == 0)
            {
                var dlg = new OpenFileDialog();
                dlg.Filter = "PDF Files|*.pdf";

                var res = dlg.ShowDialog();
                if (res == DialogResult.OK)
                {
                    path_textBox.Text = dlg.FileName;
                }
            }

            else
            {
                var dlg = new OpenFileDialog();

                dlg.Filter = "Text Files|*.doc;*.docx;*.txt;*.text";
                var res = dlg.ShowDialog();
                if (res == DialogResult.OK)
                {
                    path_textBox.Text = dlg.FileName;
                }
            }



            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog1.FileName;
                //path_textBox5.Text = filepath;
            }
        }

        private void search(object sender, EventArgs e)
        {

            DataView DV = new DataView(table);
            DV.RowFilter = string.Format("Book_Name LIKE '%{0}%'", search_textBox1.Text);
            dataGridView2.DataSource = DV;

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void showbook(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                delete_textBox2.Text = row.Cells["Book_Name"].Value.ToString();

            }
        }


        string tempvalue;
        private void delete(object sender, EventArgs e)
        {
            SqlConnection con = Databaseconnection.Get_con();
            string query = "SELECT Book_Name FROM EntryList ";

            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader rdr;
            con.Open();
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                tempvalue = rdr["Book_Name"].ToString();

                if (delete_textBox2.Text.ToString().CompareTo(tempvalue) == 0)
                {

                    break;

                }

            }
            con.Close();
            if (delete_textBox2.Text.ToString().CompareTo(tempvalue) == 0)
            {
                con.Open();

                try
                {
                    cmd.CommandText = "delete from EntryList where Book_Name='" + delete_textBox2.Text + "'";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Book Deleted successfilly");
                    con.Close();
                    delete_textBox2.Text = "";

                    select_table();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
            else
                MessageBox.Show("Book Name is not selected");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String filepath = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                MessageBox.Show(filepath);
                Process.Start(filepath);
            }

            catch (Exception)
            {
                MessageBox.Show("Folder Location Is Not Valid", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void year_textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Year_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("http://www.microsoft.com");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void saerchbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.SelectedText != "")
                {
                    Process.Start("http://google.com/search?q" + richTextBox1.SelectedText);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void book_textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void upload(object sender, RoutedEventArgs e)
        {
            try
            {
                LiveConnectClient liveClient = new LiveConnectClient(this.session);
                LiveOperationResult operationResult =
                await liveClient.GetAsync("folder.8c8ce076ca27823f.8C8CE076CA27823F!126");
                dynamic result = operationResult.Result;
                infoTextBlock.Text = "Folder name: " + result.name + ", ID: " + result.id;
            }
            catch (LiveConnectException exception)
            {
                infoTextBlock.Text = "Error getting folder info: " + exception.Message;
            }



        }

        public object session { get; set; }
    }
}       
    

