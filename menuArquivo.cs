using System;
using System.Windows.Forms;
using System.IO;

namespace FocoEditor
{
    public partial class Form1
    {
        #region Métodos

        public void Novo()
        {
            richTextBox.Clear();
            Gerenciador.DefaultFile();
        }
        public void Abrir()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        richTextBox.Text = reader.ReadToEnd();
                        Gerenciador.EditFile(openFileDialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao abrir o documento:\n" + ex.Message, "Editor de texto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }
        public void Salvar()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.Write(richTextBox.Text);
                    Gerenciador.EditFile(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o documento:\n" + ex.Message, "Editor de texto", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void SalvarComo()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Salvar();
            }
        }

        #endregion

        #region Eventos
        private void newMenuItem_Click(object sender, EventArgs e)
        {
            Function novo = Novo;
            Metodo(novo);
        }
        private void openMenuItem_Click(object sender, EventArgs e)
        {
            Function abrir = Abrir;
            Metodo(abrir);
        }
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Gerenciador.FilePath))
            {
                Salvar();
            }
            else
            {
                SalvarComo();
            }
        }
        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = Text;
            SalvarComo();
        }
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Function sair = Application.Exit;
            Metodo(sair);
        }
        #endregion

        #region evento dos botões
        private void newButton_Click(object sender, EventArgs e)
        {
            Function novo = Novo;
            Metodo(novo);
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            Function abrir = Abrir;
            Metodo(abrir);
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(Gerenciador.FilePath))
            {
                Salvar();
            }
            else
            {
                SalvarComo();
            }
        }
        private void cutButton_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }
        private void copyButton_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }
        private void pasteButton_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }
        #endregion
    }
}
