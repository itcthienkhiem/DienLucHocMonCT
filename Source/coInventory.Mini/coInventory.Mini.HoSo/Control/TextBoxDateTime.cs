using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace coInventory.Mini.HoSo.Control
{
    class TextBoxDateTime : TextBox
    {
        public TextBoxDateTime()
        {
            this.Validated += this_Validated;
            this.Click += this_Click;
        }
        bool allowSpace = false;

        public DateTime? GetDate
        {
            get
            {
                try
                {
                    if (this.Text.Length > 0)
                    {
                        string str = this.Text.Replace("/", "");
                        string d = str.Substring(0, 2);
                        string m = str.Substring(2, 2);
                        string y = str.Substring(4, str.Length - 4);

                        DateTime? tmp = null; ;
                        if (y.Length == 4)
                        {
                            tmp = DateTime.ParseExact(d + "/" + m + "/" + y, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }
                        else if (y.Length == 2)
                        {
                            tmp = DateTime.ParseExact(d + "/" + m + "/" + y, "dd/MM/yy", CultureInfo.InvariantCulture);
                        }
                        return tmp.Value;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }

        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            string groupSeparator = numberFormatInfo.NumberGroupSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;

            string keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
             keyInput.Equals(negativeSign))
            {
                // Decimal separator is OK
            }
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }

            else if (this.allowSpace && e.KeyChar == ' ')
            {

            }
            else
            {
                e.Handled = true;
            }
        }
        private void this_Click(object sender, EventArgs e)
        {
            TextBox m = (TextBox)sender;
            this.BeginInvoke((MethodInvoker)delegate()
            {
                m.SelectAll();
            });
        }

        private void this_Validated(object sender, EventArgs e)
        {
            try
            {
                if (this.Text.Length > 0)
                {
                    string str= this.Text.Replace("/", "");
                    string d = str.Substring(0, 2);
                    string m = str.Substring(2, 2);
                    string y = str.Substring(4, str.Length - 4);

                    DateTime? tmp = null; ;
                    if (y.Length == 4)
                    {
                        tmp = DateTime.ParseExact(d + "/" + m + "/" + y, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    else if (y.Length == 2)
                    {
                        tmp = DateTime.ParseExact(d + "/" + m + "/" + y, "dd/MM/yy", CultureInfo.InvariantCulture);
                    }
                    this.Text = string.Format("{0:dd/MM/yyyy}", tmp.Value);
                }
            }
            catch
            {
                this.Text = string.Empty;
                this.Focus();
            }
        }


        public bool AllowSpace
        {
            set
            {
                this.allowSpace = value;
            }

            get
            {
                return this.allowSpace;
            }
        }
    }
}
