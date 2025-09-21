namespace Library_Manegment_System
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnViewBooks = new System.Windows.Forms.Button();
            this.btnIssueBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Library Management System";
            // 
            // btnAddBook
            // 
            this.btnAddBook.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddBook.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.Location = new System.Drawing.Point(60, 108);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(120, 90);
            this.btnAddBook.TabIndex = 1;
            this.btnAddBook.Text = "Add Book";
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnViewBooks
            // 
            this.btnViewBooks.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnViewBooks.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBooks.Location = new System.Drawing.Point(268, 108);
            this.btnViewBooks.Name = "btnViewBooks";
            this.btnViewBooks.Size = new System.Drawing.Size(107, 90);
            this.btnViewBooks.TabIndex = 2;
            this.btnViewBooks.Text = "View Books";
            this.btnViewBooks.UseVisualStyleBackColor = false;
            this.btnViewBooks.Click += new System.EventHandler(this.btnViewBooks_Click);
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnIssueBook.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueBook.Location = new System.Drawing.Point(473, 108);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(118, 90);
            this.btnIssueBook.TabIndex = 3;
            this.btnIssueBook.Text = "Issue Book";
            this.btnIssueBook.UseVisualStyleBackColor = false;
            this.btnIssueBook.Click += new System.EventHandler(this.btnIssueBook_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnReturnBook.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnBook.Location = new System.Drawing.Point(60, 231);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(116, 85);
            this.btnReturnBook.TabIndex = 4;
            this.btnReturnBook.Text = "Return Book";
            this.btnReturnBook.UseVisualStyleBackColor = false;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnStudents.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudents.Location = new System.Drawing.Point(268, 231);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(116, 85);
            this.btnStudents.TabIndex = 5;
            this.btnStudents.Text = "Students";
            this.btnStudents.UseVisualStyleBackColor = false;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnExit.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(473, 231);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(118, 85);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStudents);
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.btnIssueBook);
            this.Controls.Add(this.btnViewBooks);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "LMS Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnViewBooks;
        private System.Windows.Forms.Button btnIssueBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnExit;
    }
}

