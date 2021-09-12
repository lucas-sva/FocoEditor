using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FocoEditor
{
    public partial class Form1
    {
        #region Métodos

        private void StatusZoom(float zoom)
        {
            statusZoom.Text = $"{Math.Round(zoom * 100)}%";
        }
        #endregion

        #region Eventos

        private void ampliarMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.ZoomFactor += 0.1f;
            StatusZoom(richTextBox.ZoomFactor);
        }

        private void reduzirMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.ZoomFactor -= 0.1f;
            StatusZoom(richTextBox.ZoomFactor);
        }

        private void restaurarMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.ZoomFactor = 1f;
            StatusZoom(richTextBox.ZoomFactor);
        }

        private void toolBarMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (toolBarMenuItem.Checked == true)
            {
                statusStrip.Visible = true;
            }
            else
            {
                statusStrip.Visible = false;
            }
        }

        #endregion
    }
}
