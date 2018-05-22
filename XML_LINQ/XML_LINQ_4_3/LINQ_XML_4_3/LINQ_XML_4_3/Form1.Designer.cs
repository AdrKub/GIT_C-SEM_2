namespace LINQ_XML_4_3
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.LstBx_Books = new System.Windows.Forms.ListBox();
            this.Lbl_Author = new System.Windows.Forms.Label();
            this.Lbl_Title = new System.Windows.Forms.Label();
            this.Lbl_Genre = new System.Windows.Forms.Label();
            this.Lbl_Price = new System.Windows.Forms.Label();
            this.Lbl_PubDate = new System.Windows.Forms.Label();
            this.Lbl_Description = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LstBx_Books
            // 
            this.LstBx_Books.FormattingEnabled = true;
            this.LstBx_Books.Location = new System.Drawing.Point(12, 66);
            this.LstBx_Books.Name = "LstBx_Books";
            this.LstBx_Books.Size = new System.Drawing.Size(156, 277);
            this.LstBx_Books.TabIndex = 0;
            this.LstBx_Books.SelectedIndexChanged += new System.EventHandler(this.LstBx_Books_SelectedIndexChanged);
            // 
            // Lbl_Author
            // 
            this.Lbl_Author.AutoSize = true;
            this.Lbl_Author.Location = new System.Drawing.Point(255, 66);
            this.Lbl_Author.Name = "Lbl_Author";
            this.Lbl_Author.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Author.TabIndex = 1;
            this.Lbl_Author.Text = "label1";
            // 
            // Lbl_Title
            // 
            this.Lbl_Title.AutoSize = true;
            this.Lbl_Title.Location = new System.Drawing.Point(255, 99);
            this.Lbl_Title.Name = "Lbl_Title";
            this.Lbl_Title.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Title.TabIndex = 2;
            this.Lbl_Title.Text = "label1";
            // 
            // Lbl_Genre
            // 
            this.Lbl_Genre.AutoSize = true;
            this.Lbl_Genre.Location = new System.Drawing.Point(255, 135);
            this.Lbl_Genre.Name = "Lbl_Genre";
            this.Lbl_Genre.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Genre.TabIndex = 3;
            this.Lbl_Genre.Text = "label1";
            // 
            // Lbl_Price
            // 
            this.Lbl_Price.AutoSize = true;
            this.Lbl_Price.Location = new System.Drawing.Point(255, 168);
            this.Lbl_Price.Name = "Lbl_Price";
            this.Lbl_Price.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Price.TabIndex = 4;
            this.Lbl_Price.Text = "label1";
            // 
            // Lbl_PubDate
            // 
            this.Lbl_PubDate.AutoSize = true;
            this.Lbl_PubDate.Location = new System.Drawing.Point(255, 204);
            this.Lbl_PubDate.Name = "Lbl_PubDate";
            this.Lbl_PubDate.Size = new System.Drawing.Size(35, 13);
            this.Lbl_PubDate.TabIndex = 5;
            this.Lbl_PubDate.Text = "label1";
            // 
            // Lbl_Description
            // 
            this.Lbl_Description.AutoSize = true;
            this.Lbl_Description.Location = new System.Drawing.Point(255, 239);
            this.Lbl_Description.Name = "Lbl_Description";
            this.Lbl_Description.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Description.TabIndex = 6;
            this.Lbl_Description.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 475);
            this.Controls.Add(this.Lbl_Description);
            this.Controls.Add(this.Lbl_PubDate);
            this.Controls.Add(this.Lbl_Price);
            this.Controls.Add(this.Lbl_Genre);
            this.Controls.Add(this.Lbl_Title);
            this.Controls.Add(this.Lbl_Author);
            this.Controls.Add(this.LstBx_Books);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstBx_Books;
        private System.Windows.Forms.Label Lbl_Author;
        private System.Windows.Forms.Label Lbl_Title;
        private System.Windows.Forms.Label Lbl_Genre;
        private System.Windows.Forms.Label Lbl_Price;
        private System.Windows.Forms.Label Lbl_PubDate;
        private System.Windows.Forms.Label Lbl_Description;
    }
}

