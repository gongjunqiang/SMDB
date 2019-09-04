namespace SMDB
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiModifyPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.学员管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Import = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiManageStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.成绩管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQueryAndAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_AttendanceQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Card = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_AQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_linkxkt = new System.Windows.Forms.ToolStripMenuItem();
            this.txmi_update = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_about = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeAccount = new System.Windows.Forms.Button();
            this.btnModifyPwd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStuManage = new System.Windows.Forms.Button();
            this.btnScoreQuery = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnGoXiketang = new System.Windows.Forms.Button();
            this.btnAttendanceQuery = new System.Windows.Forms.Button();
            this.btnScoreAnalasys = new System.Windows.Forms.Button();
            this.btnImportStu = new System.Windows.Forms.Button();
            this.btnAddStu = new System.Windows.Forms.Button();
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.学员管理ToolStripMenuItem,
            this.成绩管理ToolStripMenuItem,
            this.tsmi_AttendanceQuery,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiModifyPwd,
            this.toolStripSeparator3,
            this.tmiClose});
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.系统ToolStripMenuItem.Text = "系统(&S)";
            // 
            // tmiModifyPwd
            // 
            this.tmiModifyPwd.Image = ((System.Drawing.Image)(resources.GetObject("tmiModifyPwd.Image")));
            this.tmiModifyPwd.Name = "tmiModifyPwd";
            this.tmiModifyPwd.Size = new System.Drawing.Size(140, 22);
            this.tmiModifyPwd.Text = "密码修改(&C)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(137, 6);
            // 
            // tmiClose
            // 
            this.tmiClose.Image = ((System.Drawing.Image)(resources.GetObject("tmiClose.Image")));
            this.tmiClose.Name = "tmiClose";
            this.tmiClose.Size = new System.Drawing.Size(140, 22);
            this.tmiClose.Text = "退出(&E)";
            // 
            // 学员管理ToolStripMenuItem
            // 
            this.学员管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddStudent,
            this.tsmi_Import,
            this.toolStripSeparator2,
            this.tsmiManageStudent});
            this.学员管理ToolStripMenuItem.Name = "学员管理ToolStripMenuItem";
            this.学员管理ToolStripMenuItem.Size = new System.Drawing.Size(88, 21);
            this.学员管理ToolStripMenuItem.Text = "学员管理(&M)";
            // 
            // tsmiAddStudent
            // 
            this.tsmiAddStudent.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAddStudent.Image")));
            this.tsmiAddStudent.Name = "tsmiAddStudent";
            this.tsmiAddStudent.Size = new System.Drawing.Size(166, 22);
            this.tsmiAddStudent.Text = "添加学员(&A)";
            // 
            // tsmi_Import
            // 
            this.tsmi_Import.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Import.Image")));
            this.tsmi_Import.Name = "tsmi_Import";
            this.tsmi_Import.Size = new System.Drawing.Size(166, 22);
            this.tsmi_Import.Text = "批量导入学员";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // tsmiManageStudent
            // 
            this.tsmiManageStudent.Image = ((System.Drawing.Image)(resources.GetObject("tsmiManageStudent.Image")));
            this.tsmiManageStudent.Name = "tsmiManageStudent";
            this.tsmiManageStudent.Size = new System.Drawing.Size(166, 22);
            this.tsmiManageStudent.Text = "学员信息管理(&Q)";
            // 
            // 成绩管理ToolStripMenuItem
            // 
            this.成绩管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQueryAndAnalysis,
            this.toolStripSeparator1,
            this.tsmiQuery});
            this.成绩管理ToolStripMenuItem.Name = "成绩管理ToolStripMenuItem";
            this.成绩管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 21);
            this.成绩管理ToolStripMenuItem.Text = "成绩管理(&J)";
            // 
            // tsmiQueryAndAnalysis
            // 
            this.tsmiQueryAndAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("tsmiQueryAndAnalysis.Image")));
            this.tsmiQueryAndAnalysis.Name = "tsmiQueryAndAnalysis";
            this.tsmiQueryAndAnalysis.Size = new System.Drawing.Size(178, 22);
            this.tsmiQueryAndAnalysis.Text = "成绩查询与分析(&Q)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // tsmiQuery
            // 
            this.tsmiQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsmiQuery.Image")));
            this.tsmiQuery.Name = "tsmiQuery";
            this.tsmiQuery.Size = new System.Drawing.Size(178, 22);
            this.tsmiQuery.Text = "成绩快速查询(&S)";
            // 
            // tsmi_AttendanceQuery
            // 
            this.tsmi_AttendanceQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Card,
            this.toolStripSeparator7,
            this.tsmi_AQuery});
            this.tsmi_AttendanceQuery.Name = "tsmi_AttendanceQuery";
            this.tsmi_AttendanceQuery.Size = new System.Drawing.Size(84, 21);
            this.tsmi_AttendanceQuery.Text = "考勤管理(&A)";
            // 
            // tsmi_Card
            // 
            this.tsmi_Card.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Card.Image")));
            this.tsmi_Card.Name = "tsmi_Card";
            this.tsmi_Card.Size = new System.Drawing.Size(140, 22);
            this.tsmi_Card.Text = "考勤打卡(&R)";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(137, 6);
            // 
            // tsmi_AQuery
            // 
            this.tsmi_AQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_AQuery.Image")));
            this.tsmi_AQuery.Name = "tsmi_AQuery";
            this.tsmi_AQuery.Size = new System.Drawing.Size(140, 22);
            this.tsmi_AQuery.Text = "考勤查询";
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_linkxkt,
            this.txmi_update,
            this.toolStripSeparator8,
            this.tsmi_about});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // tsmi_linkxkt
            // 
            this.tsmi_linkxkt.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_linkxkt.Image")));
            this.tsmi_linkxkt.Name = "tsmi_linkxkt";
            this.tsmi_linkxkt.Size = new System.Drawing.Size(141, 22);
            this.tsmi_linkxkt.Text = "访问官网(&X)";
            // 
            // txmi_update
            // 
            this.txmi_update.Image = ((System.Drawing.Image)(resources.GetObject("txmi_update.Image")));
            this.txmi_update.Name = "txmi_update";
            this.txmi_update.Size = new System.Drawing.Size(141, 22);
            this.txmi_update.Text = "系统升级(&U)";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(138, 6);
            // 
            // tsmi_about
            // 
            this.tsmi_about.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_about.Image")));
            this.tsmi_about.Name = "tsmi_about";
            this.tsmi_about.Size = new System.Drawing.Size(141, 22);
            this.tsmi_about.Text = "关于我们(&A)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVersion,
            this.toolStripStatusLabel1,
            this.lblCurrentUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblVersion
            // 
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(85, 17);
            this.lblVersion.Text = " 版本号：V2.0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel1.Text = " [当前用登录户：";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(48, 17);
            this.lblCurrentUser.Text = "王晓军]";
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Controls.Add(this.tvMenu);
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.label2);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.btnChangeAccount);
            this.splitContainer.Panel1.Controls.Add(this.btnModifyPwd);
            this.splitContainer.Panel1.Controls.Add(this.btnExit);
            this.splitContainer.Panel1.Controls.Add(this.btnStuManage);
            this.splitContainer.Panel1.Controls.Add(this.btnScoreQuery);
            this.splitContainer.Panel1.Controls.Add(this.btnCard);
            this.splitContainer.Panel1.Controls.Add(this.btnUpdate);
            this.splitContainer.Panel1.Controls.Add(this.btnGoXiketang);
            this.splitContainer.Panel1.Controls.Add(this.btnAttendanceQuery);
            this.splitContainer.Panel1.Controls.Add(this.btnScoreAnalasys);
            this.splitContainer.Panel1.Controls.Add(this.btnImportStu);
            this.splitContainer.Panel1.Controls.Add(this.btnAddStu);
            this.splitContainer.Size = new System.Drawing.Size(1264, 682);
            this.splitContainer.SplitterDistance = 246;
            this.splitContainer.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(32, 560);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 3);
            this.label3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(32, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 3);
            this.label2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(32, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 3);
            this.label1.TabIndex = 4;
            // 
            // btnChangeAccount
            // 
            this.btnChangeAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeAccount.Image")));
            this.btnChangeAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeAccount.Location = new System.Drawing.Point(131, 424);
            this.btnChangeAccount.Name = "btnChangeAccount";
            this.btnChangeAccount.Size = new System.Drawing.Size(82, 41);
            this.btnChangeAccount.TabIndex = 6;
            this.btnChangeAccount.Text = "账号切换";
            this.btnChangeAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangeAccount.UseVisualStyleBackColor = true;
            this.btnChangeAccount.Click += new System.EventHandler(this.BtnChangeAccount_Click);
            // 
            // btnModifyPwd
            // 
            this.btnModifyPwd.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyPwd.Image")));
            this.btnModifyPwd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyPwd.Location = new System.Drawing.Point(32, 424);
            this.btnModifyPwd.Name = "btnModifyPwd";
            this.btnModifyPwd.Size = new System.Drawing.Size(82, 41);
            this.btnModifyPwd.TabIndex = 7;
            this.btnModifyPwd.Text = "密码修改";
            this.btnModifyPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifyPwd.UseVisualStyleBackColor = true;
            this.btnModifyPwd.Click += new System.EventHandler(this.BtnModifyPwd_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(131, 608);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 41);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出系统";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnStuManage
            // 
            this.btnStuManage.BackColor = System.Drawing.SystemColors.Control;
            this.btnStuManage.ForeColor = System.Drawing.Color.Black;
            this.btnStuManage.Image = ((System.Drawing.Image)(resources.GetObject("btnStuManage.Image")));
            this.btnStuManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStuManage.Location = new System.Drawing.Point(134, 236);
            this.btnStuManage.Name = "btnStuManage";
            this.btnStuManage.Size = new System.Drawing.Size(82, 41);
            this.btnStuManage.TabIndex = 9;
            this.btnStuManage.Text = "学员管理";
            this.btnStuManage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStuManage.UseVisualStyleBackColor = false;
            this.btnStuManage.Click += new System.EventHandler(this.BtnStuManage_Click);
            // 
            // btnScoreQuery
            // 
            this.btnScoreQuery.BackColor = System.Drawing.SystemColors.Control;
            this.btnScoreQuery.ForeColor = System.Drawing.Color.Black;
            this.btnScoreQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnScoreQuery.Image")));
            this.btnScoreQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScoreQuery.Location = new System.Drawing.Point(32, 348);
            this.btnScoreQuery.Name = "btnScoreQuery";
            this.btnScoreQuery.Size = new System.Drawing.Size(82, 41);
            this.btnScoreQuery.TabIndex = 10;
            this.btnScoreQuery.Text = "成绩浏览";
            this.btnScoreQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScoreQuery.UseVisualStyleBackColor = false;
            this.btnScoreQuery.Click += new System.EventHandler(this.BtnScoreQuery_Click);
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.SystemColors.Control;
            this.btnCard.ForeColor = System.Drawing.Color.Black;
            this.btnCard.Image = ((System.Drawing.Image)(resources.GetObject("btnCard.Image")));
            this.btnCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCard.Location = new System.Drawing.Point(32, 292);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(82, 41);
            this.btnCard.TabIndex = 11;
            this.btnCard.Text = "考勤打卡";
            this.btnCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCard.UseVisualStyleBackColor = false;
            this.btnCard.Click += new System.EventHandler(this.BtnCard_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(32, 500);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(82, 41);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "系统升级";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnGoXiketang
            // 
            this.btnGoXiketang.Image = ((System.Drawing.Image)(resources.GetObject("btnGoXiketang.Image")));
            this.btnGoXiketang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoXiketang.Location = new System.Drawing.Point(32, 608);
            this.btnGoXiketang.Name = "btnGoXiketang";
            this.btnGoXiketang.Size = new System.Drawing.Size(82, 41);
            this.btnGoXiketang.TabIndex = 13;
            this.btnGoXiketang.Text = "访问官网";
            this.btnGoXiketang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoXiketang.UseVisualStyleBackColor = true;
            // 
            // btnAttendanceQuery
            // 
            this.btnAttendanceQuery.BackColor = System.Drawing.SystemColors.Control;
            this.btnAttendanceQuery.ForeColor = System.Drawing.Color.Black;
            this.btnAttendanceQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnAttendanceQuery.Image")));
            this.btnAttendanceQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendanceQuery.Location = new System.Drawing.Point(132, 292);
            this.btnAttendanceQuery.Name = "btnAttendanceQuery";
            this.btnAttendanceQuery.Size = new System.Drawing.Size(82, 41);
            this.btnAttendanceQuery.TabIndex = 14;
            this.btnAttendanceQuery.Text = "考勤查询";
            this.btnAttendanceQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAttendanceQuery.UseVisualStyleBackColor = false;
            this.btnAttendanceQuery.Click += new System.EventHandler(this.BtnAttendanceQuery_Click);
            // 
            // btnScoreAnalasys
            // 
            this.btnScoreAnalasys.BackColor = System.Drawing.SystemColors.Control;
            this.btnScoreAnalasys.ForeColor = System.Drawing.Color.Black;
            this.btnScoreAnalasys.Image = ((System.Drawing.Image)(resources.GetObject("btnScoreAnalasys.Image")));
            this.btnScoreAnalasys.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScoreAnalasys.Location = new System.Drawing.Point(132, 348);
            this.btnScoreAnalasys.Name = "btnScoreAnalasys";
            this.btnScoreAnalasys.Size = new System.Drawing.Size(82, 41);
            this.btnScoreAnalasys.TabIndex = 15;
            this.btnScoreAnalasys.Text = "成绩分析";
            this.btnScoreAnalasys.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnScoreAnalasys.UseVisualStyleBackColor = false;
            this.btnScoreAnalasys.Click += new System.EventHandler(this.BtnScoreAnalasys_Click);
            // 
            // btnImportStu
            // 
            this.btnImportStu.BackColor = System.Drawing.SystemColors.Control;
            this.btnImportStu.Image = ((System.Drawing.Image)(resources.GetObject("btnImportStu.Image")));
            this.btnImportStu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportStu.Location = new System.Drawing.Point(134, 500);
            this.btnImportStu.Name = "btnImportStu";
            this.btnImportStu.Size = new System.Drawing.Size(82, 41);
            this.btnImportStu.TabIndex = 16;
            this.btnImportStu.Text = "批量导入";
            this.btnImportStu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportStu.UseVisualStyleBackColor = false;
            this.btnImportStu.Click += new System.EventHandler(this.BtnImportStu_Click);
            // 
            // btnAddStu
            // 
            this.btnAddStu.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddStu.ForeColor = System.Drawing.Color.Black;
            this.btnAddStu.Image = ((System.Drawing.Image)(resources.GetObject("btnAddStu.Image")));
            this.btnAddStu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddStu.Location = new System.Drawing.Point(32, 236);
            this.btnAddStu.Name = "btnAddStu";
            this.btnAddStu.Size = new System.Drawing.Size(82, 41);
            this.btnAddStu.TabIndex = 17;
            this.btnAddStu.Text = "添加学员";
            this.btnAddStu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddStu.UseVisualStyleBackColor = false;
            this.btnAddStu.Click += new System.EventHandler(this.BtnAddStu_Click);
            // 
            // tvMenu
            // 
            this.tvMenu.ImageIndex = 0;
            this.tvMenu.ImageList = this.imageList1;
            this.tvMenu.Location = new System.Drawing.Point(32, 40);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.SelectedImageIndex = 0;
            this.tvMenu.Size = new System.Drawing.Size(181, 190);
            this.tvMenu.TabIndex = 18;
            this.tvMenu.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.TvMenu_AfterCollapse);
            this.tvMenu.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.TvMenu_AfterExpand);
            this.tvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvMenu_AfterSelect);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(37, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "学员信息管理菜单";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "BOOKS01.ICO");
            this.imageList1.Images.SetKeyName(1, "turn.BMP");
            this.imageList1.Images.SetKeyName(2, "open.ico");
            this.imageList1.Images.SetKeyName(3, "CustomerOrder.ico");
            this.imageList1.Images.SetKeyName(4, "SysIco.ico");
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[学员信息管理系统]--最适合初学者学习的实践项目";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmiModifyPwd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tmiClose;
        private System.Windows.Forms.ToolStripMenuItem 学员管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddStudent;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Import;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageStudent;
        private System.Windows.Forms.ToolStripMenuItem 成绩管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiQueryAndAnalysis;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuery;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AttendanceQuery;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Card;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AQuery;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_linkxkt;
        private System.Windows.Forms.ToolStripMenuItem txmi_update;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem tsmi_about;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentUser;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeAccount;
        private System.Windows.Forms.Button btnModifyPwd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStuManage;
        private System.Windows.Forms.Button btnScoreQuery;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnGoXiketang;
        private System.Windows.Forms.Button btnAttendanceQuery;
        private System.Windows.Forms.Button btnScoreAnalasys;
        private System.Windows.Forms.Button btnImportStu;
        private System.Windows.Forms.Button btnAddStu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView tvMenu;
        private System.Windows.Forms.ImageList imageList1;
    }
}