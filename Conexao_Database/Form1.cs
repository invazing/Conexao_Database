using System;
using System.Windows.Forms;

namespace Conexao_Database
{
    public partial class Form1 : Form
    {
        readonly Access_Database _access_Database = new Access_Database();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            DGV.DataSource = _access_Database.Consulta("SELECT * FROM CLIENTE");            
        }
        private void button1_Click(object sender, EventArgs e)
        {
             _access_Database.Inserir($"INSERT INTO CLIENTE (Nome,Idade,Info) VALUES ({name_tbx.Text},{idade_tbx.Text},{obs_tbx.Text})");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _access_Database.Deletar($"DELETE FROM CLIENTE WHERE IdCliente=@ID", ((Int32)DGV.CurrentRow.Cells[0].Value));
            MessageBox.Show("");
        }
    }
}
