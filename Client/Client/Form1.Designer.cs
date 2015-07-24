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
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.directoryListView = new System.Windows.Forms.ListView();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.openButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(20, 20);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(454, 26);
            this.pathTextBox.TabIndex = 0;
            this.pathTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pathTextBox_KeyPress);
            // 
            // directoryListView
            // 
            this.directoryListView.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.directoryListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.directoryListView.Location = new System.Drawing.Point(20, 54);
            this.directoryListView.MultiSelect = false;
            this.directoryListView.Name = "directoryListView";
            this.directoryListView.Size = new System.Drawing.Size(454, 335);
            this.directoryListView.TabIndex = 4;
            this.directoryListView.UseCompatibleStateImageBehavior = false;
            this.directoryListView.View = System.Windows.Forms.View.Details;
            this.directoryListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.directoryListView_KeyPress);
            this.directoryListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.directoryListView_MouseDoubleClick);
            // 
            // iconList
            // 
            this.iconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconList.ImageSize = new System.Drawing.Size(16, 16);
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(363, 395);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(111, 35);
            this.openButton.TabIndex = 5;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 442);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.directoryListView);
            this.Controls.Add(this.pathTextBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.ListView directoryListView;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.Button openButton;
    }
}

