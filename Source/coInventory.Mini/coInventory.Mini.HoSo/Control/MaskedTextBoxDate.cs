using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace coInventory.Mini.HoSo
{
    public class MaskedTextBoxDate : MaskedTextBox
    {
        private bool _BatBuocNhap = false;

        public bool BatBuocNhap
        {
            get { return _BatBuocNhap; }
            set { _BatBuocNhap = value; }
        }

        public DateTime? GetDate
        {
            get
            {
                try
                {
                    return DateTime.ParseExact(this.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                catch
                {
                    return null;
                }
            }

        }
        public MaskedTextBoxDate()
        {
            //this.Mask = "00/00/0000";
            this.PromptChar = ' ';
            this.Validated += this_Validated;
            this.Enter += new EventHandler(MaskedDateTextBox_SelectAllOnEnter);
        }

        void MaskedDateTextBox_SelectAllOnEnter(object sender, EventArgs e)
        {
            MaskedTextBox m = (MaskedTextBox)sender;
            this.BeginInvoke((MethodInvoker)delegate()
            {
                m.SelectAll();
            });
        }

        private void this_Validated(object sender, EventArgs e)
        {
            try
            {
                if (BatBuocNhap)
                {
                    DateTime dt = DateTime.ParseExact(this.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    string[] array = this.Text.Split(' ');
                    if (this.Text.Replace("/", "").Trim().Length > 0)
                    {
                        DateTime dt = DateTime.ParseExact(this.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                }
            }
            catch
            {
                //this.Text = "";
                //this.Invalidate();
                this.Focus();
            }
        }
    }
}
