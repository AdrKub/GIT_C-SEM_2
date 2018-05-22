namespace SchoolCourseApp
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
            this.CmbBx_Department = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Lb_Department = new System.Windows.Forms.Label();
            this.LstBx_Courses = new System.Windows.Forms.ListBox();
            this.Lbl_Courses = new System.Windows.Forms.Label();
            this.LstBx_AllCourses = new System.Windows.Forms.ListBox();
            this.Lbl_AllCourses = new System.Windows.Forms.Label();
            this.TxtBx_Department = new System.Windows.Forms.TextBox();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_AddDepartment = new System.Windows.Forms.Button();
            this.Btn_CancelAddDep = new System.Windows.Forms.Button();
            this.GrpBx_AddDepartment = new System.Windows.Forms.GroupBox();
            this.Btn_AddToDepartment = new System.Windows.Forms.Button();
            this.GrpBx_AddNewCourse = new System.Windows.Forms.GroupBox();
            this.TxtBx_Course = new System.Windows.Forms.TextBox();
            this.Btn_CancelAddCour = new System.Windows.Forms.Button();
            this.Btn_AddCourse = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.GrpBx_AddDepartment.SuspendLayout();
            this.GrpBx_AddNewCourse.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbBx_Department
            // 
            this.CmbBx_Department.FormattingEnabled = true;
            this.CmbBx_Department.Location = new System.Drawing.Point(12, 66);
            this.CmbBx_Department.Name = "CmbBx_Department";
            this.CmbBx_Department.Size = new System.Drawing.Size(194, 21);
            this.CmbBx_Department.TabIndex = 2;
            this.CmbBx_Department.SelectedIndexChanged += new System.EventHandler(this.CmbBx_Department_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(466, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Lb_Department
            // 
            this.Lb_Department.AutoSize = true;
            this.Lb_Department.Location = new System.Drawing.Point(9, 39);
            this.Lb_Department.Name = "Lb_Department";
            this.Lb_Department.Size = new System.Drawing.Size(67, 13);
            this.Lb_Department.TabIndex = 4;
            this.Lb_Department.Text = "Departments";
            // 
            // LstBx_Courses
            // 
            this.LstBx_Courses.FormattingEnabled = true;
            this.LstBx_Courses.Location = new System.Drawing.Point(12, 133);
            this.LstBx_Courses.Name = "LstBx_Courses";
            this.LstBx_Courses.Size = new System.Drawing.Size(194, 160);
            this.LstBx_Courses.TabIndex = 5;
            // 
            // Lbl_Courses
            // 
            this.Lbl_Courses.AutoSize = true;
            this.Lbl_Courses.Location = new System.Drawing.Point(9, 106);
            this.Lbl_Courses.Name = "Lbl_Courses";
            this.Lbl_Courses.Size = new System.Drawing.Size(103, 13);
            this.Lbl_Courses.TabIndex = 6;
            this.Lbl_Courses.Text = "Department Courses";
            // 
            // LstBx_AllCourses
            // 
            this.LstBx_AllCourses.FormattingEnabled = true;
            this.LstBx_AllCourses.Location = new System.Drawing.Point(225, 133);
            this.LstBx_AllCourses.Name = "LstBx_AllCourses";
            this.LstBx_AllCourses.Size = new System.Drawing.Size(194, 160);
            this.LstBx_AllCourses.TabIndex = 7;
            // 
            // Lbl_AllCourses
            // 
            this.Lbl_AllCourses.AutoSize = true;
            this.Lbl_AllCourses.Location = new System.Drawing.Point(222, 106);
            this.Lbl_AllCourses.Name = "Lbl_AllCourses";
            this.Lbl_AllCourses.Size = new System.Drawing.Size(59, 13);
            this.Lbl_AllCourses.TabIndex = 8;
            this.Lbl_AllCourses.Text = "All Courses";
            // 
            // TxtBx_Department
            // 
            this.TxtBx_Department.Location = new System.Drawing.Point(6, 19);
            this.TxtBx_Department.Name = "TxtBx_Department";
            this.TxtBx_Department.Size = new System.Drawing.Size(194, 20);
            this.TxtBx_Department.TabIndex = 9;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.departmentToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // departmentToolStripMenuItem
            // 
            this.departmentToolStripMenuItem.Name = "departmentToolStripMenuItem";
            this.departmentToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.departmentToolStripMenuItem.Text = "Department";
            // 
            // Btn_AddDepartment
            // 
            this.Btn_AddDepartment.Location = new System.Drawing.Point(213, 16);
            this.Btn_AddDepartment.Name = "Btn_AddDepartment";
            this.Btn_AddDepartment.Size = new System.Drawing.Size(75, 23);
            this.Btn_AddDepartment.TabIndex = 11;
            this.Btn_AddDepartment.Text = "Add";
            this.Btn_AddDepartment.UseVisualStyleBackColor = true;
            // 
            // Btn_CancelAddDep
            // 
            this.Btn_CancelAddDep.Location = new System.Drawing.Point(294, 16);
            this.Btn_CancelAddDep.Name = "Btn_CancelAddDep";
            this.Btn_CancelAddDep.Size = new System.Drawing.Size(75, 23);
            this.Btn_CancelAddDep.TabIndex = 12;
            this.Btn_CancelAddDep.Text = "Cancel";
            this.Btn_CancelAddDep.UseVisualStyleBackColor = true;
            // 
            // GrpBx_AddDepartment
            // 
            this.GrpBx_AddDepartment.Controls.Add(this.TxtBx_Department);
            this.GrpBx_AddDepartment.Controls.Add(this.Btn_CancelAddDep);
            this.GrpBx_AddDepartment.Controls.Add(this.Btn_AddDepartment);
            this.GrpBx_AddDepartment.Location = new System.Drawing.Point(12, 373);
            this.GrpBx_AddDepartment.Name = "GrpBx_AddDepartment";
            this.GrpBx_AddDepartment.Size = new System.Drawing.Size(407, 54);
            this.GrpBx_AddDepartment.TabIndex = 13;
            this.GrpBx_AddDepartment.TabStop = false;
            this.GrpBx_AddDepartment.Text = "New Department";
            this.GrpBx_AddDepartment.Visible = false;
            // 
            // Btn_AddToDepartment
            // 
            this.Btn_AddToDepartment.Location = new System.Drawing.Point(225, 299);
            this.Btn_AddToDepartment.Name = "Btn_AddToDepartment";
            this.Btn_AddToDepartment.Size = new System.Drawing.Size(110, 23);
            this.Btn_AddToDepartment.TabIndex = 14;
            this.Btn_AddToDepartment.Text = "Add to Department";
            this.Btn_AddToDepartment.UseVisualStyleBackColor = true;
            this.Btn_AddToDepartment.Click += new System.EventHandler(this.Btn_AddToDepartment_Click);
            // 
            // GrpBx_AddNewCourse
            // 
            this.GrpBx_AddNewCourse.Controls.Add(this.TxtBx_Course);
            this.GrpBx_AddNewCourse.Controls.Add(this.Btn_CancelAddCour);
            this.GrpBx_AddNewCourse.Controls.Add(this.Btn_AddCourse);
            this.GrpBx_AddNewCourse.Location = new System.Drawing.Point(12, 446);
            this.GrpBx_AddNewCourse.Name = "GrpBx_AddNewCourse";
            this.GrpBx_AddNewCourse.Size = new System.Drawing.Size(407, 54);
            this.GrpBx_AddNewCourse.TabIndex = 15;
            this.GrpBx_AddNewCourse.TabStop = false;
            this.GrpBx_AddNewCourse.Text = "New Course";
            this.GrpBx_AddNewCourse.Visible = false;
            // 
            // TxtBx_Course
            // 
            this.TxtBx_Course.Location = new System.Drawing.Point(6, 19);
            this.TxtBx_Course.Name = "TxtBx_Course";
            this.TxtBx_Course.Size = new System.Drawing.Size(194, 20);
            this.TxtBx_Course.TabIndex = 9;
            // 
            // Btn_CancelAddCour
            // 
            this.Btn_CancelAddCour.Location = new System.Drawing.Point(294, 16);
            this.Btn_CancelAddCour.Name = "Btn_CancelAddCour";
            this.Btn_CancelAddCour.Size = new System.Drawing.Size(75, 23);
            this.Btn_CancelAddCour.TabIndex = 12;
            this.Btn_CancelAddCour.Text = "Cancel";
            this.Btn_CancelAddCour.UseVisualStyleBackColor = true;
            // 
            // Btn_AddCourse
            // 
            this.Btn_AddCourse.Location = new System.Drawing.Point(213, 16);
            this.Btn_AddCourse.Name = "Btn_AddCourse";
            this.Btn_AddCourse.Size = new System.Drawing.Size(75, 23);
            this.Btn_AddCourse.TabIndex = 11;
            this.Btn_AddCourse.Text = "Add";
            this.Btn_AddCourse.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 524);
            this.Controls.Add(this.GrpBx_AddNewCourse);
            this.Controls.Add(this.Btn_AddToDepartment);
            this.Controls.Add(this.GrpBx_AddDepartment);
            this.Controls.Add(this.Lbl_AllCourses);
            this.Controls.Add(this.LstBx_AllCourses);
            this.Controls.Add(this.Lbl_Courses);
            this.Controls.Add(this.LstBx_Courses);
            this.Controls.Add(this.Lb_Department);
            this.Controls.Add(this.CmbBx_Department);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GrpBx_AddDepartment.ResumeLayout(false);
            this.GrpBx_AddDepartment.PerformLayout();
            this.GrpBx_AddNewCourse.ResumeLayout(false);
            this.GrpBx_AddNewCourse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox CmbBx_Department;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label Lb_Department;
        private System.Windows.Forms.ListBox LstBx_Courses;
        private System.Windows.Forms.Label Lbl_Courses;
        private System.Windows.Forms.ListBox LstBx_AllCourses;
        private System.Windows.Forms.Label Lbl_AllCourses;
        private System.Windows.Forms.TextBox TxtBx_Department;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentToolStripMenuItem;
        private System.Windows.Forms.Button Btn_AddDepartment;
        private System.Windows.Forms.Button Btn_CancelAddDep;
        private System.Windows.Forms.GroupBox GrpBx_AddDepartment;
        private System.Windows.Forms.Button Btn_AddToDepartment;
        private System.Windows.Forms.GroupBox GrpBx_AddNewCourse;
        private System.Windows.Forms.TextBox TxtBx_Course;
        private System.Windows.Forms.Button Btn_CancelAddCour;
        private System.Windows.Forms.Button Btn_AddCourse;
    }
}

