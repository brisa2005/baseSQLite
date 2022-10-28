using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;//Agregamos esta libreria
using System.Data.SqlClient;

namespace baseSQLite
{
    public partial class Form1 : Form
    {
        //Agregamos la base de datos
        string path = "data_table.db";
        string cs = @"URL=file:" + Application.StartupPath + "\\data_table.db";
        //La base de datos se queda en la carpeta DEBUG

        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Create_db();
            data_show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Create_db()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "Create table test (name varchar(20), id varchar(12))";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("La base de datos no se pudo crear");
                return;
            }
        }
        private void data_show()
        {
            var conn = new SQLiteConnection(cs);
            conn.Open();

            string stm = "SELECT * FROM test";
            var cmd= new SQLiteCommand(stm, conn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                dataGridView1.Rows.Add(0, dr.GetString(0),dr.GetString(1));  
            }

        }

    }
}
