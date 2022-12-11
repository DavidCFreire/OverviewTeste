namespace OverviewTeste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            // SETAR PROPRIEDAES listView
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.LabelEdit = true;

            listView1.Columns.Add("Nome", 650);
            listView1.Columns.Add("Data Nasc", 116);
            
            // SETAR CURSOR PARA INICIAR NO TEXTBOX DO LABEL NOME
            txtNome.Select();          
        }

        // CONTADOR DE REGISTRO
        int countreg = 0;
        private void contador(int countreg)
        {
            label3.Text = "QUANTIDADE DE REGISTRO: ";
            label3.Text = label3.Text + ' ' + countreg;
        }
                
        // METÓDO BOTÃO ADICIONAR
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            // Validar Nome para não ser vazio (trim retirar espaços antes e depois e comparar se é vazia)
            if (txtNome.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("O nome não você ser vazio", Text, MessageBoxButtons.OK, MessageBoxIcon.Error); // Título do formulário
                return;
            }

            ListViewItem item = new ListViewItem();
            item.SubItems.Add(txtNome.Text.Trim());
            item.SubItems.Add(dtpNascimento.Text);
            countreg += 1;
            contador(countreg);
            listView1.Items.Add(item);
        }
        // MÉTODO RIGHT CLICK NA LISTVIEW - ContextMenuStrip
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuStrip1.Show(Cursor.Position);
        }
        // MÉTODO BOTÃO REMOVER - ContextMenuStrip 
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            countreg -= 1;
            contador(countreg);
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            
        }
        // MÉTODO BOTÃO ATUALIZAR - ContextMenuStrip
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems[0].SubItems[0].Text = txtNome.Text;
            listView1.SelectedItems[0].SubItems[1].Text = dtpNascimento.Text;
        }
      
    }
}