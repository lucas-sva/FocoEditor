using System;

namespace FocoEditor
{
    public partial class Form1
    {
        #region Métodos

        private void Excluir()
        {
            int pos = richTextBox.SelectionStart;
            richTextBox.Text = richTextBox.Text.Remove(richTextBox.SelectionStart, richTextBox.SelectedText.Length);
            richTextBox.SelectionStart = pos;
        }

        private void HoraData()
        {
            int index = richTextBox.SelectionStart;
            string dataHora = DateTime.Now.ToString();

            if (richTextBox.SelectionStart == richTextBox.Text.Length)
            {
                richTextBox.Text += dataHora;
                richTextBox.SelectionStart = index + dataHora.Length;
                return;
            }

            string temp = string.Empty;

            for (int i = 0; i < richTextBox.Text.Length; i++)
            {
                if (i == richTextBox.SelectionStart)
                {
                    temp += dataHora;
                    temp += richTextBox.Text[i];
                }
                else
                {
                    temp += richTextBox.Text[i];
                }
            }

            richTextBox.Text = temp;
            richTextBox.SelectionStart = index + dataHora.Length;
        }

        #endregion

        #region Eventos

        private void undoMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void redoMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Redo();
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }

        private void horaDataMenuItem_Click(object sender, EventArgs e)
        {
            HoraData();
        }

        private void DelMenuItem_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        #endregion
    }
}
