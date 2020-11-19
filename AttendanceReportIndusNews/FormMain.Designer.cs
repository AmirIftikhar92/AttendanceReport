namespace AttendanceReportIndusNews
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
            this.ButtonImportFile = new System.Windows.Forms.Button();
            this.DataGridView_Excel = new System.Windows.Forms.DataGridView();
            this.OpenFileDialog_Excel = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Excel)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonImportFile
            // 
            this.ButtonImportFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonImportFile.Location = new System.Drawing.Point(12, 12);
            this.ButtonImportFile.Name = "ButtonImportFile";
            this.ButtonImportFile.Size = new System.Drawing.Size(90, 34);
            this.ButtonImportFile.TabIndex = 0;
            this.ButtonImportFile.Text = "&Import File";
            this.ButtonImportFile.UseVisualStyleBackColor = true;
            this.ButtonImportFile.Click += new System.EventHandler(this.ButtonImportFile_Click);
            // 
            // DataGridView_Excel
            // 
            this.DataGridView_Excel.AllowUserToAddRows = false;
            this.DataGridView_Excel.AllowUserToDeleteRows = false;
            this.DataGridView_Excel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Excel.Location = new System.Drawing.Point(13, 53);
            this.DataGridView_Excel.Name = "DataGridView_Excel";
            this.DataGridView_Excel.ReadOnly = true;
            this.DataGridView_Excel.Size = new System.Drawing.Size(759, 496);
            this.DataGridView_Excel.TabIndex = 1;
            // 
            // OpenFileDialog_Excel
            // 
            this.OpenFileDialog_Excel.FileName = "Excel File";
            this.OpenFileDialog_Excel.Filter = "\"Excel Files|*.xls; *.xlsx\"";
            this.OpenFileDialog_Excel.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_Excel_FileOk);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.DataGridView_Excel);
            this.Controls.Add(this.ButtonImportFile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "Attendance Report | Indus News";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Excel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonImportFile;
        private System.Windows.Forms.DataGridView DataGridView_Excel;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_Excel;
    }
}

