using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory.Utilities
{
    public class AutoConfigFormControls
    {
        List<TextBox> txtBox;
        int i;

        private System.Windows.Forms.ErrorProvider errorProvider1;

        public AutoConfigFormControls(ref System.Windows.Forms.ErrorProvider errorProvider1)
        {
            i = 0;
            txtBox = new List<TextBox>();
            this.errorProvider1 = errorProvider1;
        }

        private bool isNumber(char ch)
        {
            if (ch == '.')
            {
                return true;
            }

            if (Char.IsDigit(ch) || Char.IsControl(ch))
            {
                return true;
            }

            return false;
        }

        public void AddTextBox(ref TextBox txt)
        {
            this.txtBox.Add(txt);

            this.txtBox[i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBox_KeyPress);
            this.txtBox[i].Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_Validating);
            this.txtBox[i].Validated += new System.EventHandler(this.txtBox_Validated);
            i++;
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!isNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string errorMsg = "Giá trị bạn nhập không đúng!\nXin hãy nhập số!";
            double tmp;
            if (!double.TryParse(txt.Text.Trim().ToString(), out tmp) || txt.Text.Equals(String.Empty))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txt.Select(0, txt.Text.Length);

                // Set the ErrorProvider error with the text to display.
                this.errorProvider1.SetError(txt, errorMsg);
            }
        }

        private void txtBox_Validated(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            errorProvider1.SetError(txt, "");
        }
    }
}
