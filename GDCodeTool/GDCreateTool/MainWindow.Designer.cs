namespace GDCreateTool
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeTo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblsymbol1 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.lblSearchTable = new System.Windows.Forms.Label();
            this.gpbmodel = new System.Windows.Forms.GroupBox();
            this.cklmodel = new System.Windows.Forms.CheckedListBox();
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.btnCreateWinds = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ltbleft = new System.Windows.Forms.ListBox();
            this.ltbright = new System.Windows.Forms.ListBox();
            this.Menu.SuspendLayout();
            this.gpbmodel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu.BackgroundImage")));
            this.Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.功能ToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(974, 25);
            this.Menu.TabIndex = 13;
            this.Menu.Text = "menuStrip1";
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.ChangeTo});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.功能ToolStripMenuItem.Text = "功能";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem.Text = "项目创建";
            // 
            // ChangeTo
            // 
            this.ChangeTo.Name = "ChangeTo";
            this.ChangeTo.Size = new System.Drawing.Size(124, 22);
            this.ChangeTo.Text = "反转";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(438, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 23);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblsymbol1
            // 
            this.lblsymbol1.AutoSize = true;
            this.lblsymbol1.BackColor = System.Drawing.Color.Transparent;
            this.lblsymbol1.Location = new System.Drawing.Point(305, 252);
            this.lblsymbol1.Name = "lblsymbol1";
            this.lblsymbol1.Size = new System.Drawing.Size(23, 12);
            this.lblsymbol1.TabIndex = 17;
            this.lblsymbol1.Text = "==>";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(163, 54);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(252, 21);
            this.txtTableName.TabIndex = 18;
            // 
            // lblSearchTable
            // 
            this.lblSearchTable.AutoSize = true;
            this.lblSearchTable.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchTable.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSearchTable.Location = new System.Drawing.Point(101, 57);
            this.lblSearchTable.Name = "lblSearchTable";
            this.lblSearchTable.Size = new System.Drawing.Size(56, 16);
            this.lblSearchTable.TabIndex = 19;
            this.lblSearchTable.Text = "查询表";
            // 
            // gpbmodel
            // 
            this.gpbmodel.BackColor = System.Drawing.Color.Transparent;
            this.gpbmodel.Controls.Add(this.cklmodel);
            this.gpbmodel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbmodel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbmodel.Location = new System.Drawing.Point(618, 101);
            this.gpbmodel.Name = "gpbmodel";
            this.gpbmodel.Size = new System.Drawing.Size(344, 234);
            this.gpbmodel.TabIndex = 20;
            this.gpbmodel.TabStop = false;
            this.gpbmodel.Text = "生成条件";
            // 
            // cklmodel
            // 
            this.cklmodel.BackColor = System.Drawing.Color.White;
            this.cklmodel.ColumnWidth = 100;
            this.cklmodel.FormattingEnabled = true;
            this.cklmodel.Location = new System.Drawing.Point(17, 31);
            this.cklmodel.MultiColumn = true;
            this.cklmodel.Name = "cklmodel";
            this.cklmodel.Size = new System.Drawing.Size(310, 184);
            this.cklmodel.TabIndex = 0;
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(618, 356);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(87, 23);
            this.btnCreateFile.TabIndex = 21;
            this.btnCreateFile.Text = "生成文件";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // btnCreateWinds
            // 
            this.btnCreateWinds.Location = new System.Drawing.Point(760, 356);
            this.btnCreateWinds.Name = "btnCreateWinds";
            this.btnCreateWinds.Size = new System.Drawing.Size(75, 23);
            this.btnCreateWinds.TabIndex = 21;
            this.btnCreateWinds.Text = "窗口生成";
            this.btnCreateWinds.UseVisualStyleBackColor = true;
            this.btnCreateWinds.Click += new System.EventHandler(this.btnCreateWinds_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(887, 356);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSetting.TabIndex = 21;
            this.btnSetting.Text = "模板设置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(618, 397);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(87, 23);
            this.btnOpenFile.TabIndex = 22;
            this.btnOpenFile.Text = "打开文件位置";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(760, 397);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ltbleft
            // 
            this.ltbleft.FormattingEnabled = true;
            this.ltbleft.ItemHeight = 12;
            this.ltbleft.Location = new System.Drawing.Point(51, 101);
            this.ltbleft.Name = "ltbleft";
            this.ltbleft.Size = new System.Drawing.Size(217, 316);
            this.ltbleft.TabIndex = 24;
            this.ltbleft.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ltbleft_MouseDoubleClick);
            // 
            // ltbright
            // 
            this.ltbright.FormattingEnabled = true;
            this.ltbright.ItemHeight = 12;
            this.ltbright.Location = new System.Drawing.Point(372, 101);
            this.ltbright.Name = "ltbright";
            this.ltbright.Size = new System.Drawing.Size(217, 316);
            this.ltbright.TabIndex = 25;
            this.ltbright.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ltbright_MouseDoubleClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(974, 455);
            this.Controls.Add(this.ltbright);
            this.Controls.Add(this.ltbleft);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnCreateWinds);
            this.Controls.Add(this.btnCreateFile);
            this.Controls.Add(this.gpbmodel);
            this.Controls.Add(this.lblSearchTable);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.lblsymbol1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.Menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主窗口";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.gpbmodel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblsymbol1;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label lblSearchTable;
        private System.Windows.Forms.GroupBox gpbmodel;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.Button btnCreateWinds;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckedListBox cklmodel;
        private System.Windows.Forms.ListBox ltbleft;
        private System.Windows.Forms.ListBox ltbright;
    }
}