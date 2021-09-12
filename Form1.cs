using System;
using System.Windows.Forms;
using System.IO;

namespace FocoEditor
{
    public partial class Form1 : Form
    {
        public delegate void Function();

        public Form1()
        {
            InitializeComponent();
            Text = Gerenciador.FileName + Gerenciador.FileExt;
            saveFileDialog.FileName = openFileDialog.FileName = Text;
        }

        #region Métodos

        public void Metodo(Function func) // método base para testar se as alterações serão salvas
        {
            if (Gerenciador.FileSaved == false)
            {
                DialogResult mensagem = MessageBox.Show("Deseja salvar as alterações em " + Gerenciador.FileName + Gerenciador.FileExt + "?", "Editor de texto", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (mensagem == DialogResult.Yes)
                {
                    if (File.Exists(Gerenciador.FilePath))
                    {
                        Salvar();
                    }

                    else
                    {
                        SalvarComo();
                    }

                    if (Gerenciador.FileSaved == true)
                    {
                        func();
                    }
                }
                else if (mensagem == DialogResult.No)
                {
                    func();
                }
            }
            else
            {
                func();
            }
        }

        #endregion

        #region Eventos

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            Text = "*" + Gerenciador.FileName + Gerenciador.FileExt;
            Gerenciador.FileSaved = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Gerenciador.FileSaved == false)
            {
                DialogResult mensagem = MessageBox.Show("Deseja salvar as alterações em " + Gerenciador.FileName + Gerenciador.FileExt + "?", "Editor de texto", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (mensagem == DialogResult.Yes)
                {
                    if (File.Exists(Gerenciador.FilePath))
                    {
                        Salvar();
                    }

                    else
                    {
                        SalvarComo();
                    }

                    if (Gerenciador.FileSaved == false)
                    {
                        e.Cancel = true;
                    }
                }
                else if (mensagem == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion


    }
}
