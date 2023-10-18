namespace Wissen
{
    partial class Sign_In
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sign_In));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.b_Feedback = new System.Windows.Forms.Button();
            this.p_logo = new System.Windows.Forms.PictureBox();
            this.tb_Email = new System.Windows.Forms.TextBox();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.b_Login = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_sign_up = new System.Windows.Forms.Label();
            this.b_sign_up = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_logo)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.b_Feedback, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.p_logo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_Email, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tb_Password, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.b_Login, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 541);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // b_Feedback
            // 
            this.b_Feedback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_Feedback.BackColor = System.Drawing.SystemColors.HotTrack;
            this.b_Feedback.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_Feedback.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Feedback.ForeColor = System.Drawing.Color.White;
            this.b_Feedback.Location = new System.Drawing.Point(146, 474);
            this.b_Feedback.Name = "b_Feedback";
            this.b_Feedback.Size = new System.Drawing.Size(142, 44);
            this.b_Feedback.TabIndex = 4;
            this.b_Feedback.Text = "Feedback";
            this.b_Feedback.UseVisualStyleBackColor = false;
            // 
            // p_logo
            // 
            this.p_logo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p_logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p_logo.BackgroundImage")));
            this.p_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p_logo.Location = new System.Drawing.Point(147, 63);
            this.p_logo.Name = "p_logo";
            this.p_logo.Size = new System.Drawing.Size(140, 50);
            this.p_logo.TabIndex = 0;
            this.p_logo.TabStop = false;
            // 
            // tb_Email
            // 
            this.tb_Email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Email.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Email.Location = new System.Drawing.Point(100, 187);
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.Size = new System.Drawing.Size(234, 27);
            this.tb_Email.TabIndex = 1;
            this.tb_Email.Enter += new System.EventHandler(this.tb_Email_Enter);
            this.tb_Email.Leave += new System.EventHandler(this.tb_Email_Leave);
            // 
            // tb_Password
            // 
            this.tb_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Password.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Password.Location = new System.Drawing.Point(100, 237);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(234, 27);
            this.tb_Password.TabIndex = 2;
            this.tb_Password.UseSystemPasswordChar = true;
            this.tb_Password.Enter += new System.EventHandler(this.tb_Password_Enter);
            this.tb_Password.Leave += new System.EventHandler(this.tb_Password_Leave);
            // 
            // b_Login
            // 
            this.b_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_Login.BackColor = System.Drawing.SystemColors.HotTrack;
            this.b_Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_Login.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Login.ForeColor = System.Drawing.Color.White;
            this.b_Login.Location = new System.Drawing.Point(146, 298);
            this.b_Login.Name = "b_Login";
            this.b_Login.Size = new System.Drawing.Size(142, 44);
            this.b_Login.TabIndex = 3;
            this.b_Login.Text = "Login";
            this.b_Login.UseVisualStyleBackColor = false;
            this.b_Login.Click += new System.EventHandler(this.b_Login_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.lb_sign_up, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.b_sign_up, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 367);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(428, 82);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // lb_sign_up
            // 
            this.lb_sign_up.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lb_sign_up.AutoSize = true;
            this.lb_sign_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sign_up.Location = new System.Drawing.Point(68, 31);
            this.lb_sign_up.Name = "lb_sign_up";
            this.lb_sign_up.Size = new System.Drawing.Size(185, 20);
            this.lb_sign_up.TabIndex = 0;
            this.lb_sign_up.Text = "Don\'t have an account?";
            // 
            // b_sign_up
            // 
            this.b_sign_up.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.b_sign_up.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.b_sign_up.FlatAppearance.BorderSize = 0;
            this.b_sign_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_sign_up.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_sign_up.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.b_sign_up.Location = new System.Drawing.Point(259, 20);
            this.b_sign_up.Name = "b_sign_up";
            this.b_sign_up.Size = new System.Drawing.Size(92, 41);
            this.b_sign_up.TabIndex = 1;
            this.b_sign_up.Text = "Sign Up";
            this.b_sign_up.UseVisualStyleBackColor = true;
            this.b_sign_up.Click += new System.EventHandler(this.b_sign_up_Click);
            // 
            // Sign_In
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 541);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sign_In";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_logo)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox p_logo;
        private System.Windows.Forms.TextBox tb_Email;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Button b_Login;
        private System.Windows.Forms.Button b_Feedback;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lb_sign_up;
        private System.Windows.Forms.Button b_sign_up;
    }
}

