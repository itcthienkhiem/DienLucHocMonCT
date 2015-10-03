namespace AddEditDeleteDataGridView
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.userDataGridView = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grpSqlServers = new System.Windows.Forms.GroupBox();
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.btnGetAllTables = new System.Windows.Forms.Button();
            this.cmbAllDataBases = new System.Windows.Forms.ComboBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnGetAllDataBases = new System.Windows.Forms.Button();
            this.btnLoadSqlServers = new System.Windows.Forms.Button();
            this.cmbSqlServers = new System.Windows.Forms.ComboBox();
            this.grpDataManipulate = new System.Windows.Forms.GroupBox();
            this.lblPageNums = new System.Windows.Forms.Label();
            this.lblTotRecords = new System.Windows.Forms.Label();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNoOfPages = new System.Windows.Forms.Button();
            this.lblNoOfPages = new System.Windows.Forms.Label();
            this.cmbNoOfRecords = new System.Windows.Forms.ComboBox();
            this.lblLoadedTable = new System.Windows.Forms.Label();
            this.grpLogo = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).BeginInit();
            this.grpSqlServers.SuspendLayout();
            this.grpDataManipulate.SuspendLayout();
            this.grpLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // userDataGridView
            // 
            this.userDataGridView.AllowUserToOrderColumns = true;
            this.userDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.userDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataGridView.Location = new System.Drawing.Point(6, 99);
            this.userDataGridView.Name = "userDataGridView";
            this.userDataGridView.ReadOnly = true;
            this.userDataGridView.Size = new System.Drawing.Size(391, 349);
            this.userDataGridView.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(10, 41);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "&Load data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 454);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "&Add/Update";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(87, 454);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 16;
            this.btnUpdate.Text = "&Commit";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(168, 454);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grpSqlServers
            // 
            this.grpSqlServers.Controls.Add(this.prgProgress);
            this.grpSqlServers.Controls.Add(this.cmbTables);
            this.grpSqlServers.Controls.Add(this.btnGetAllTables);
            this.grpSqlServers.Controls.Add(this.cmbAllDataBases);
            this.grpSqlServers.Controls.Add(this.lblPassword);
            this.grpSqlServers.Controls.Add(this.lblUserName);
            this.grpSqlServers.Controls.Add(this.txtPassword);
            this.grpSqlServers.Controls.Add(this.txtUserName);
            this.grpSqlServers.Controls.Add(this.btnGetAllDataBases);
            this.grpSqlServers.Controls.Add(this.btnLoadSqlServers);
            this.grpSqlServers.Controls.Add(this.cmbSqlServers);
            this.grpSqlServers.Location = new System.Drawing.Point(12, 14);
            this.grpSqlServers.Name = "grpSqlServers";
            this.grpSqlServers.Size = new System.Drawing.Size(230, 288);
            this.grpSqlServers.TabIndex = 5;
            this.grpSqlServers.TabStop = false;
            this.grpSqlServers.Text = "Load and login to SQL server";
            // 
            // prgProgress
            // 
            this.prgProgress.Location = new System.Drawing.Point(6, 259);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(217, 23);
            this.prgProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgProgress.TabIndex = 8;
            // 
            // cmbTables
            // 
            this.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(6, 232);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(217, 21);
            this.cmbTables.TabIndex = 7;
            // 
            // btnGetAllTables
            // 
            this.btnGetAllTables.Location = new System.Drawing.Point(6, 199);
            this.btnGetAllTables.Name = "btnGetAllTables";
            this.btnGetAllTables.Size = new System.Drawing.Size(217, 23);
            this.btnGetAllTables.TabIndex = 6;
            this.btnGetAllTables.Text = "Get All &Tables";
            this.btnGetAllTables.UseVisualStyleBackColor = true;
            this.btnGetAllTables.Click += new System.EventHandler(this.btnGetAllTables_Click);
            // 
            // cmbAllDataBases
            // 
            this.cmbAllDataBases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAllDataBases.FormattingEnabled = true;
            this.cmbAllDataBases.Location = new System.Drawing.Point(6, 170);
            this.cmbAllDataBases.Name = "cmbAllDataBases";
            this.cmbAllDataBases.Size = new System.Drawing.Size(217, 21);
            this.cmbAllDataBases.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 115);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Password: ";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(6, 89);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(64, 13);
            this.lblUserName.TabIndex = 10;
            this.lblUserName.Text = "User name: ";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(123, 112);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(123, 85);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 2;
            // 
            // btnGetAllDataBases
            // 
            this.btnGetAllDataBases.Location = new System.Drawing.Point(6, 138);
            this.btnGetAllDataBases.Name = "btnGetAllDataBases";
            this.btnGetAllDataBases.Size = new System.Drawing.Size(217, 23);
            this.btnGetAllDataBases.TabIndex = 4;
            this.btnGetAllDataBases.Text = "Get All &Databases";
            this.btnGetAllDataBases.UseVisualStyleBackColor = true;
            this.btnGetAllDataBases.Click += new System.EventHandler(this.btnGetAllDataBases_Click);
            // 
            // btnLoadSqlServers
            // 
            this.btnLoadSqlServers.Location = new System.Drawing.Point(6, 29);
            this.btnLoadSqlServers.Name = "btnLoadSqlServers";
            this.btnLoadSqlServers.Size = new System.Drawing.Size(217, 23);
            this.btnLoadSqlServers.TabIndex = 0;
            this.btnLoadSqlServers.Text = "Get all &Sql servers  on network";
            this.btnLoadSqlServers.UseVisualStyleBackColor = true;
            this.btnLoadSqlServers.Click += new System.EventHandler(this.btnLoadSqlServers_Click);
            // 
            // cmbSqlServers
            // 
            this.cmbSqlServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSqlServers.FormattingEnabled = true;
            this.cmbSqlServers.Location = new System.Drawing.Point(6, 58);
            this.cmbSqlServers.Name = "cmbSqlServers";
            this.cmbSqlServers.Size = new System.Drawing.Size(217, 21);
            this.cmbSqlServers.TabIndex = 1;
            // 
            // grpDataManipulate
            // 
            this.grpDataManipulate.Controls.Add(this.lblPageNums);
            this.grpDataManipulate.Controls.Add(this.lblTotRecords);
            this.grpDataManipulate.Controls.Add(this.btnLast);
            this.grpDataManipulate.Controls.Add(this.btnNext);
            this.grpDataManipulate.Controls.Add(this.btnPrevious);
            this.grpDataManipulate.Controls.Add(this.btnFirst);
            this.grpDataManipulate.Controls.Add(this.btnNoOfPages);
            this.grpDataManipulate.Controls.Add(this.lblNoOfPages);
            this.grpDataManipulate.Controls.Add(this.cmbNoOfRecords);
            this.grpDataManipulate.Controls.Add(this.lblLoadedTable);
            this.grpDataManipulate.Controls.Add(this.userDataGridView);
            this.grpDataManipulate.Controls.Add(this.btnLoad);
            this.grpDataManipulate.Controls.Add(this.btnDelete);
            this.grpDataManipulate.Controls.Add(this.btnAdd);
            this.grpDataManipulate.Controls.Add(this.btnUpdate);
            this.grpDataManipulate.Location = new System.Drawing.Point(260, 13);
            this.grpDataManipulate.Name = "grpDataManipulate";
            this.grpDataManipulate.Size = new System.Drawing.Size(403, 488);
            this.grpDataManipulate.TabIndex = 6;
            this.grpDataManipulate.TabStop = false;
            this.grpDataManipulate.Text = "Add, edit, delete data";
            // 
            // lblPageNums
            // 
            this.lblPageNums.AutoSize = true;
            this.lblPageNums.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNums.Location = new System.Drawing.Point(261, 459);
            this.lblPageNums.Name = "lblPageNums";
            this.lblPageNums.Size = new System.Drawing.Size(0, 13);
            this.lblPageNums.TabIndex = 18;
            // 
            // lblTotRecords
            // 
            this.lblTotRecords.AutoSize = true;
            this.lblTotRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRecords.Location = new System.Drawing.Point(234, 16);
            this.lblTotRecords.Name = "lblTotRecords";
            this.lblTotRecords.Size = new System.Drawing.Size(0, 13);
            this.lblTotRecords.TabIndex = 10;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(346, 70);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(50, 23);
            this.btnLast.TabIndex = 14;
            this.btnLast.Text = "L&ast";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(234, 70);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 23);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(122, 70);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(50, 23);
            this.btnPrevious.TabIndex = 12;
            this.btnPrevious.Text = "<<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(10, 70);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(50, 23);
            this.btnFirst.TabIndex = 11;
            this.btnFirst.Text = "&First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNoOfPages
            // 
            this.btnNoOfPages.Location = new System.Drawing.Point(357, 41);
            this.btnNoOfPages.Name = "btnNoOfPages";
            this.btnNoOfPages.Size = new System.Drawing.Size(40, 23);
            this.btnNoOfPages.TabIndex = 10;
            this.btnNoOfPages.Text = "&Set";
            this.btnNoOfPages.UseVisualStyleBackColor = true;
            this.btnNoOfPages.Click += new System.EventHandler(this.btnNoOfPages_Click);
            // 
            // lblNoOfPages
            // 
            this.lblNoOfPages.AutoSize = true;
            this.lblNoOfPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfPages.Location = new System.Drawing.Point(125, 46);
            this.lblNoOfPages.Name = "lblNoOfPages";
            this.lblNoOfPages.Size = new System.Drawing.Size(150, 13);
            this.lblNoOfPages.TabIndex = 7;
            this.lblNoOfPages.Text = "No. of records per page: ";
            // 
            // cmbNoOfRecords
            // 
            this.cmbNoOfRecords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoOfRecords.FormatString = "N2";
            this.cmbNoOfRecords.FormattingEnabled = true;
            this.cmbNoOfRecords.Items.AddRange(new object[] {
            "15",
            "25",
            "35",
            "45",
            "55"});
            this.cmbNoOfRecords.Location = new System.Drawing.Point(284, 43);
            this.cmbNoOfRecords.Name = "cmbNoOfRecords";
            this.cmbNoOfRecords.Size = new System.Drawing.Size(57, 21);
            this.cmbNoOfRecords.TabIndex = 9;
            // 
            // lblLoadedTable
            // 
            this.lblLoadedTable.AutoSize = true;
            this.lblLoadedTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadedTable.Location = new System.Drawing.Point(7, 16);
            this.lblLoadedTable.Name = "lblLoadedTable";
            this.lblLoadedTable.Size = new System.Drawing.Size(0, 13);
            this.lblLoadedTable.TabIndex = 5;
            // 
            // grpLogo
            // 
            this.grpLogo.Controls.Add(this.lblName);
            this.grpLogo.Controls.Add(this.picLogo);
            this.grpLogo.Location = new System.Drawing.Point(12, 308);
            this.grpLogo.Name = "grpLogo";
            this.grpLogo.Size = new System.Drawing.Size(230, 193);
            this.grpLogo.TabIndex = 7;
            this.grpLogo.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 140);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(199, 42);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Jayant D. Kulkarni                            Contact me: jayantdotnet@gmail.com";
            // 
            // picLogo
            // 
            this.picLogo.Image = global::AddEditDeleteDataGridView.Properties.Resources.Genius1;
            this.picLogo.Location = new System.Drawing.Point(7, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(102, 122);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnLoadSqlServers;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(700, 513);
            this.Controls.Add(this.grpLogo);
            this.Controls.Add(this.grpDataManipulate);
            this.Controls.Add(this.grpSqlServers);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add, Edit and Delete in DataGridView";
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).EndInit();
            this.grpSqlServers.ResumeLayout(false);
            this.grpSqlServers.PerformLayout();
            this.grpDataManipulate.ResumeLayout(false);
            this.grpDataManipulate.PerformLayout();
            this.grpLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridView userDataGridView;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grpSqlServers;
        private System.Windows.Forms.ComboBox cmbSqlServers;
        private System.Windows.Forms.Button btnLoadSqlServers;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnGetAllDataBases;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox cmbAllDataBases;
        private System.Windows.Forms.Button btnGetAllTables;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.GroupBox grpDataManipulate;
        private System.Windows.Forms.GroupBox grpLogo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblLoadedTable;
        private System.Windows.Forms.ProgressBar prgProgress;
        private System.Windows.Forms.ComboBox cmbNoOfRecords;
        private System.Windows.Forms.Label lblNoOfPages;
        private System.Windows.Forms.Button btnNoOfPages;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label lblTotRecords;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPageNums;
    }
}

