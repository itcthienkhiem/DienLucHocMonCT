namespace coInventory.Mini.HoSo
{
    partial class frmTraCuuChiPhiKBBHYT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraCuuChiPhiKBBHYT));
            this.txtSoTheBHYT = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNoiDKKCB = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMaKCB = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            this.TbTongChiPhiKCBBHYT = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.grdDM_KCB = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NgayDenKham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soTheBHYTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hoTenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongChiPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BHYTThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiBenhTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCSKCB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbTongChiPhiKCBBHYT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDM_KCB)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSoTheBHYT
            // 
            this.txtSoTheBHYT.BackColor = System.Drawing.SystemColors.Info;
            this.txtSoTheBHYT.Location = new System.Drawing.Point(103, 21);
            this.txtSoTheBHYT.Mask = ">AA-0-00-00-000-00000";
            this.txtSoTheBHYT.Name = "txtSoTheBHYT";
            this.txtSoTheBHYT.Size = new System.Drawing.Size(146, 22);
            this.txtSoTheBHYT.TabIndex = 23;
            this.txtSoTheBHYT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoTheBHYT_KeyDown);
            this.txtSoTheBHYT.Validated += new System.EventHandler(this.txtSoTheBHYT_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 14);
            this.label12.TabIndex = 24;
            this.label12.Text = "Số BHYT";
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(363, 25);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(27, 13);
            this.lblThongBao.TabIndex = 25;
            this.lblThongBao.Text = "[...]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "Họ và tên";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(100, 53);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(60, 14);
            this.lblHoTen.TabIndex = 27;
            this.lblHoTen.Text = "lblHoTen";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Location = new System.Drawing.Point(297, 53);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(78, 14);
            this.lblNgaySinh.TabIndex = 29;
            this.lblNgaySinh.Text = "lblNgaySinh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 28;
            this.label2.Text = "Ngày sinh";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinh.Location = new System.Drawing.Point(520, 53);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(69, 14);
            this.lblGioiTinh.TabIndex = 31;
            this.lblGioiTinh.Text = "lblGioiTinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(410, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 30;
            this.label5.Text = "Giới tính";
            // 
            // lblNoiDKKCB
            // 
            this.lblNoiDKKCB.AutoSize = true;
            this.lblNoiDKKCB.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoiDKKCB.Location = new System.Drawing.Point(100, 83);
            this.lblNoiDKKCB.Name = "lblNoiDKKCB";
            this.lblNoiDKKCB.Size = new System.Drawing.Size(81, 14);
            this.lblNoiDKKCB.TabIndex = 33;
            this.lblNoiDKKCB.Text = "lblNoiDKKCB";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 14);
            this.label7.TabIndex = 32;
            this.label7.Text = "Nơi ĐK KCB BĐ";
            // 
            // lblMaKCB
            // 
            this.lblMaKCB.AutoSize = true;
            this.lblMaKCB.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaKCB.Location = new System.Drawing.Point(100, 109);
            this.lblMaKCB.Name = "lblMaKCB";
            this.lblMaKCB.Size = new System.Drawing.Size(63, 14);
            this.lblMaKCB.TabIndex = 35;
            this.lblMaKCB.Text = "lblMaKCB";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 14);
            this.label9.TabIndex = 34;
            this.label9.Text = "Mã";
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGian.Location = new System.Drawing.Point(333, 109);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(73, 14);
            this.lblThoiGian.TabIndex = 37;
            this.lblThoiGian.Text = "lblThoiGian";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(223, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 14);
            this.label11.TabIndex = 36;
            this.label11.Text = "Thời hạn sử dụng";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.TbTongChiPhiKCBBHYT});
            // 
            // TbTongChiPhiKCBBHYT
            // 
            this.TbTongChiPhiKCBBHYT.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10});
            this.TbTongChiPhiKCBBHYT.TableName = "TbTongChiPhiKCBBHYT";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "SoTheBHYT";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "HoTen";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "GioiTinh";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "NgaySinh";
            this.dataColumn4.DataType = typeof(System.DateTime);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "TenCSKCB";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "TongChiPhi";
            this.dataColumn6.DataType = typeof(decimal);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "BHYTThanhToan";
            this.dataColumn7.DataType = typeof(decimal);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "NguoiBenhTra";
            this.dataColumn8.DataType = typeof(decimal);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "NgayThanhToan";
            this.dataColumn9.DataType = typeof(System.DateTime);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "NgayDenKham";
            this.dataColumn10.DataType = typeof(System.DateTime);
            // 
            // grdDM_KCB
            // 
            this.grdDM_KCB.AllowUserToAddRows = false;
            this.grdDM_KCB.AllowUserToDeleteRows = false;
            this.grdDM_KCB.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.grdDM_KCB.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdDM_KCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDM_KCB.AutoGenerateColumns = false;
            this.grdDM_KCB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDM_KCB.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDM_KCB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdDM_KCB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDM_KCB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayDenKham,
            this.NgayThanhToan,
            this.soTheBHYTDataGridViewTextBoxColumn,
            this.hoTenDataGridViewTextBoxColumn,
            this.GioiTinh,
            this.NgaySinh,
            this.TongChiPhi,
            this.BHYTThanhToan,
            this.NguoiBenhTra,
            this.TenCSKCB});
            this.grdDM_KCB.DataMember = "TbTongChiPhiKCBBHYT";
            this.grdDM_KCB.DataSource = this.dataSet1;
            this.grdDM_KCB.Location = new System.Drawing.Point(6, 182);
            this.grdDM_KCB.MultiSelect = false;
            this.grdDM_KCB.Name = "grdDM_KCB";
            this.grdDM_KCB.ReadOnly = true;
            this.grdDM_KCB.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdDM_KCB.RowTemplate.Height = 30;
            this.grdDM_KCB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDM_KCB.Size = new System.Drawing.Size(1164, 602);
            this.grdDM_KCB.TabIndex = 63;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.txtSoTheBHYT);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblThongBao);
            this.groupBox1.Controls.Add(this.lblThoiGian);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblHoTen);
            this.groupBox1.Controls.Add(this.lblMaKCB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblNgaySinh);
            this.groupBox1.Controls.Add(this.lblNoiDKKCB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblGioiTinh);
            this.groupBox1.Location = new System.Drawing.Point(6, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 137);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin BHYT";
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::coInventory.Mini.HoSo.Properties.Resources.cancel_omc1;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.Location = new System.Drawing.Point(295, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(30, 30);
            this.btnClear.TabIndex = 39;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackgroundImage = global::coInventory.Mini.HoSo.Properties.Resources.search_bmc;
            this.btnCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCheck.Location = new System.Drawing.Point(262, 16);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(30, 30);
            this.btnCheck.TabIndex = 38;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(14, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 16);
            this.label1.TabIndex = 65;
            this.label1.Text = "Danh sách các đợt khám chữa bệnh BHYT";
            // 
            // NgayDenKham
            // 
            this.NgayDenKham.DataPropertyName = "NgayDenKham";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NgayDenKham.DefaultCellStyle = dataGridViewCellStyle3;
            this.NgayDenKham.HeaderText = "Ngày Đến Khám";
            this.NgayDenKham.Name = "NgayDenKham";
            this.NgayDenKham.ReadOnly = true;
            this.NgayDenKham.Width = 110;
            // 
            // NgayThanhToan
            // 
            this.NgayThanhToan.DataPropertyName = "NgayThanhToan";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NgayThanhToan.DefaultCellStyle = dataGridViewCellStyle4;
            this.NgayThanhToan.HeaderText = "Ngày Thanh Toán";
            this.NgayThanhToan.Name = "NgayThanhToan";
            this.NgayThanhToan.ReadOnly = true;
            this.NgayThanhToan.Width = 110;
            // 
            // soTheBHYTDataGridViewTextBoxColumn
            // 
            this.soTheBHYTDataGridViewTextBoxColumn.DataPropertyName = "SoTheBHYT";
            this.soTheBHYTDataGridViewTextBoxColumn.HeaderText = "Số BHYT";
            this.soTheBHYTDataGridViewTextBoxColumn.Name = "soTheBHYTDataGridViewTextBoxColumn";
            this.soTheBHYTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hoTenDataGridViewTextBoxColumn
            // 
            this.hoTenDataGridViewTextBoxColumn.DataPropertyName = "HoTen";
            this.hoTenDataGridViewTextBoxColumn.HeaderText = "Họ Tên";
            this.hoTenDataGridViewTextBoxColumn.Name = "hoTenDataGridViewTextBoxColumn";
            this.hoTenDataGridViewTextBoxColumn.ReadOnly = true;
            this.hoTenDataGridViewTextBoxColumn.Width = 200;
            // 
            // GioiTinh
            // 
            this.GioiTinh.DataPropertyName = "GioiTinh";
            this.GioiTinh.HeaderText = "GioiTinh";
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.ReadOnly = true;
            this.GioiTinh.Visible = false;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NgaySinh.DefaultCellStyle = dataGridViewCellStyle5;
            this.NgaySinh.HeaderText = "Ngày Sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // TongChiPhi
            // 
            this.TongChiPhi.DataPropertyName = "TongChiPhi";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.TongChiPhi.DefaultCellStyle = dataGridViewCellStyle6;
            this.TongChiPhi.HeaderText = "Tổng Chi Phí";
            this.TongChiPhi.Name = "TongChiPhi";
            this.TongChiPhi.ReadOnly = true;
            // 
            // BHYTThanhToan
            // 
            this.BHYTThanhToan.DataPropertyName = "BHYTThanhToan";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.BHYTThanhToan.DefaultCellStyle = dataGridViewCellStyle7;
            this.BHYTThanhToan.HeaderText = "BHYT Thanh Toán";
            this.BHYTThanhToan.Name = "BHYTThanhToan";
            this.BHYTThanhToan.ReadOnly = true;
            this.BHYTThanhToan.Width = 120;
            // 
            // NguoiBenhTra
            // 
            this.NguoiBenhTra.DataPropertyName = "NguoiBenhTra";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.NguoiBenhTra.DefaultCellStyle = dataGridViewCellStyle8;
            this.NguoiBenhTra.HeaderText = "Người Bệnh Trả";
            this.NguoiBenhTra.Name = "NguoiBenhTra";
            this.NguoiBenhTra.ReadOnly = true;
            // 
            // TenCSKCB
            // 
            this.TenCSKCB.DataPropertyName = "TenCSKCB";
            this.TenCSKCB.HeaderText = "Tên CSKCB";
            this.TenCSKCB.Name = "TenCSKCB";
            this.TenCSKCB.ReadOnly = true;
            this.TenCSKCB.Width = 200;
            // 
            // frmTraCuuChiPhiKBBHYT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 774);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdDM_KCB);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmTraCuuChiPhiKBBHYT";
            this.Text = "Tra Cứu Online Chi Phí Khám Bệnh BHYT";
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbTongChiPhiKCBBHYT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDM_KCB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtSoTheBHYT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNoiDKKCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMaKCB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label label11;
        public System.Data.DataSet dataSet1;
        private System.Data.DataTable TbTongChiPhiKCBBHYT;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Windows.Forms.DataGridView grdDM_KCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCheck;
        private System.Data.DataColumn dataColumn10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDenKham;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn soTheBHYTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoTenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongChiPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn BHYTThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiBenhTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCSKCB;
    }
}