using System;
using System.IO;
using System.Windows.Forms;

namespace FocoEditor
{
     public partial class Form1
    {

        #region Métodos

        private void Fonte()
        {
            fontDialog.Font = richTextBox.Font;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Font = fontDialog.Font;

            }
        }

        #endregion

        #region Eventos

        private void QuebraLinhaMenuItem_Click(object sender, EventArgs e)
        {
            if (QuebraLinhaMenuItem.Checked == true)
            {
                richTextBox.WordWrap = true;
            }
            else
            {
                richTextBox.WordWrap = false;
            }
        }

        private void fontMenuItem_Click(object sender, EventArgs e)
        {
            Fonte();
        }

        #endregion

    }

}
