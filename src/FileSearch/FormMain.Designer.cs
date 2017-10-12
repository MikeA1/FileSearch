namespace Search
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonFindStartingDirectory = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFileContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxStartingDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFileContent = new System.Windows.Forms.TextBox();
            this.numericUpDownFoldersDeep = new System.Windows.Forms.NumericUpDown();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBoxCaseSensitive = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFoldersDeep)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFindStartingDirectory
            // 
            this.buttonFindStartingDirectory.Location = new System.Drawing.Point(338, 12);
            this.buttonFindStartingDirectory.Name = "buttonFindStartingDirectory";
            this.buttonFindStartingDirectory.Size = new System.Drawing.Size(24, 23);
            this.buttonFindStartingDirectory.TabIndex = 3;
            this.buttonFindStartingDirectory.Text = "...";
            this.buttonFindStartingDirectory.UseVisualStyleBackColor = true;
            this.buttonFindStartingDirectory.Click += new System.EventHandler(this.buttonFindStartingDirectory_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToOrderColumns = true;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridFileName,
            this.gridLineNumber,
            this.gridFileContent});
            this.grid.Location = new System.Drawing.Point(12, 145);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1354, 344);
            this.grid.TabIndex = 1;
            this.grid.TabStop = false;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // gridFileName
            // 
            this.gridFileName.HeaderText = "File Name";
            this.gridFileName.Name = "gridFileName";
            this.gridFileName.ReadOnly = true;
            this.gridFileName.Width = 300;
            // 
            // gridLineNumber
            // 
            this.gridLineNumber.HeaderText = "Line #";
            this.gridLineNumber.Name = "gridLineNumber";
            this.gridLineNumber.ReadOnly = true;
            this.gridLineNumber.Width = 85;
            // 
            // gridFileContent
            // 
            this.gridFileContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridFileContent.HeaderText = "Line";
            this.gridFileContent.Name = "gridFileContent";
            this.gridFileContent.ReadOnly = true;
            // 
            // textBoxStartingDirectory
            // 
            this.textBoxStartingDirectory.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStartingDirectory.Location = new System.Drawing.Point(112, 12);
            this.textBoxStartingDirectory.Name = "textBoxStartingDirectory";
            this.textBoxStartingDirectory.Size = new System.Drawing.Size(226, 23);
            this.textBoxStartingDirectory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Starting Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Folders Deep";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "File Name Regex";
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFileName.Location = new System.Drawing.Point(112, 64);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(250, 23);
            this.textBoxFileName.TabIndex = 5;
            this.textBoxFileName.Text = "(?:cs$|xaml$)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "File Content RegEx";
            // 
            // textBoxFileContent
            // 
            this.textBoxFileContent.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFileContent.Location = new System.Drawing.Point(112, 90);
            this.textBoxFileContent.Name = "textBoxFileContent";
            this.textBoxFileContent.Size = new System.Drawing.Size(250, 23);
            this.textBoxFileContent.TabIndex = 6;
            // 
            // numericUpDownFoldersDeep
            // 
            this.numericUpDownFoldersDeep.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownFoldersDeep.Location = new System.Drawing.Point(112, 38);
            this.numericUpDownFoldersDeep.Name = "numericUpDownFoldersDeep";
            this.numericUpDownFoldersDeep.Size = new System.Drawing.Size(64, 23);
            this.numericUpDownFoldersDeep.TabIndex = 4;
            this.numericUpDownFoldersDeep.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(287, 116);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.Location = new System.Drawing.Point(4, 492);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(1372, 14);
            this.labelStatus.TabIndex = 11;
            this.labelStatus.Text = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(384, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Regular Expressions";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(380, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(986, 124);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.WordWrap = false;
            // 
            // checkBoxCaseSensitive
            // 
            this.checkBoxCaseSensitive.AutoSize = true;
            this.checkBoxCaseSensitive.Location = new System.Drawing.Point(112, 116);
            this.checkBoxCaseSensitive.Name = "checkBoxCaseSensitive";
            this.checkBoxCaseSensitive.Size = new System.Drawing.Size(15, 14);
            this.checkBoxCaseSensitive.TabIndex = 14;
            this.checkBoxCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Case Sensitive";
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1378, 505);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBoxCaseSensitive);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.numericUpDownFoldersDeep);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFileContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStartingDirectory);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.buttonFindStartingDirectory);
            this.Controls.Add(this.textBox1);
            this.Name = "FormMain";
            this.Text = "File Search";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFoldersDeep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFindStartingDirectory;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox textBoxStartingDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFileContent;
        private System.Windows.Forms.NumericUpDown numericUpDownFoldersDeep;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxCaseSensitive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFileContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFileName;
    }
}

