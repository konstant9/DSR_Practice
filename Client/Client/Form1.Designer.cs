namespace Client
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
            this.directoryListView1 = new System.Windows.Forms.ListView();
            this.nameDirectoryListViewColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeDirectoryListViewColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeDirectoryListViewColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconList1 = new System.Windows.Forms.ImageList(this.components);
            this.pathComboBox1 = new System.Windows.Forms.ComboBox();
            this.pathComboBox2 = new System.Windows.Forms.ComboBox();
            this.iconList2 = new System.Windows.Forms.ImageList(this.components);
            this.directoryListView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuSubItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // directoryListView1
            // 
            this.directoryListView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.directoryListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameDirectoryListViewColumnHeader,
            this.typeDirectoryListViewColumnHeader,
            this.sizeDirectoryListViewColumnHeader});
            this.directoryListView1.FullRowSelect = true;
            this.directoryListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.directoryListView1.Location = new System.Drawing.Point(0, 42);
            this.directoryListView1.Margin = new System.Windows.Forms.Padding(2);
            this.directoryListView1.MultiSelect = false;
            this.directoryListView1.Name = "directoryListView1";
            this.directoryListView1.Size = new System.Drawing.Size(464, 398);
            this.directoryListView1.TabIndex = 4;
            this.directoryListView1.UseCompatibleStateImageBehavior = false;
            this.directoryListView1.View = System.Windows.Forms.View.Details;
            this.directoryListView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.directoryListView_KeyPress);
            this.directoryListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.directoryListView_MouseDoubleClick);
            // 
            // nameDirectoryListViewColumnHeader
            // 
            this.nameDirectoryListViewColumnHeader.Text = "Name";
            this.nameDirectoryListViewColumnHeader.Width = 200;
            // 
            // typeDirectoryListViewColumnHeader
            // 
            this.typeDirectoryListViewColumnHeader.Text = "Type";
            this.typeDirectoryListViewColumnHeader.Width = 100;
            // 
            // sizeDirectoryListViewColumnHeader
            // 
            this.sizeDirectoryListViewColumnHeader.Text = "Size";
            this.sizeDirectoryListViewColumnHeader.Width = 100;
            // 
            // iconList1
            // 
            this.iconList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconList1.ImageSize = new System.Drawing.Size(16, 16);
            this.iconList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pathComboBox1
            // 
            this.pathComboBox1.FormattingEnabled = true;
            this.pathComboBox1.Location = new System.Drawing.Point(0, 24);
            this.pathComboBox1.Name = "pathComboBox1";
            this.pathComboBox1.Size = new System.Drawing.Size(464, 21);
            this.pathComboBox1.TabIndex = 6;
            this.pathComboBox1.TabStop = false;
            this.pathComboBox1.SelectedIndexChanged += new System.EventHandler(this.pathComboBox_SelectedIndexChanged);
            this.pathComboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pathComboBox_KeyPress);
            // 
            // pathComboBox2
            // 
            this.pathComboBox2.FormattingEnabled = true;
            this.pathComboBox2.Location = new System.Drawing.Point(466, 24);
            this.pathComboBox2.Name = "pathComboBox2";
            this.pathComboBox2.Size = new System.Drawing.Size(464, 21);
            this.pathComboBox2.TabIndex = 8;
            this.pathComboBox2.TabStop = false;
            this.pathComboBox2.SelectedIndexChanged += new System.EventHandler(this.pathComboBox_SelectedIndexChanged);
            this.pathComboBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pathComboBox_KeyPress);
            // 
            // iconList2
            // 
            this.iconList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconList2.ImageSize = new System.Drawing.Size(16, 16);
            this.iconList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // directoryListView2
            // 
            this.directoryListView2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.directoryListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.directoryListView2.FullRowSelect = true;
            this.directoryListView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.directoryListView2.Location = new System.Drawing.Point(466, 42);
            this.directoryListView2.Margin = new System.Windows.Forms.Padding(2);
            this.directoryListView2.MultiSelect = false;
            this.directoryListView2.Name = "directoryListView2";
            this.directoryListView2.Size = new System.Drawing.Size(464, 398);
            this.directoryListView2.TabIndex = 9;
            this.directoryListView2.UseCompatibleStateImageBehavior = false;
            this.directoryListView2.View = System.Windows.Forms.View.Details;
            this.directoryListView2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.directoryListView_KeyPress);
            this.directoryListView2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.directoryListView_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            this.columnHeader3.Width = 100;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.White;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(930, 24);
            this.mainMenuStrip.TabIndex = 10;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.russianToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // russianToolStripMenuItem
            // 
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            this.russianToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.russianToolStripMenuItem.Text = "Русский";
            this.russianToolStripMenuItem.Click += new System.EventHandler(this.russianToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuSubItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuSubItem
            // 
            this.helpToolStripMenuSubItem.Name = "helpToolStripMenuSubItem";
            this.helpToolStripMenuSubItem.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuSubItem.Text = "Help";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 440);
            this.Controls.Add(this.directoryListView2);
            this.Controls.Add(this.pathComboBox2);
            this.Controls.Add(this.pathComboBox1);
            this.Controls.Add(this.directoryListView1);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView directoryListView1;
        private System.Windows.Forms.ImageList iconList1;
        private System.Windows.Forms.ComboBox pathComboBox1;
        private System.Windows.Forms.ComboBox pathComboBox2;
        private System.Windows.Forms.ImageList iconList2;
        private System.Windows.Forms.ColumnHeader nameDirectoryListViewColumnHeader;
        private System.Windows.Forms.ColumnHeader typeDirectoryListViewColumnHeader;
        private System.Windows.Forms.ColumnHeader sizeDirectoryListViewColumnHeader;
        private System.Windows.Forms.ListView directoryListView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem russianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuSubItem;
    }
}

