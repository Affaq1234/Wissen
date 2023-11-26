namespace Wissen
{
    partial class Teacher_Payment_Management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teacher_Payment_Management));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.p_logo = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.gv_payments = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.b_remove = new System.Windows.Forms.Button();
            this.b_send_notification = new System.Windows.Forms.Button();
            this.b_verify = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_logo)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_payments)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(908, 546);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.p_logo, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(902, 94);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // p_logo
            // 
            this.p_logo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.p_logo.Image = ((System.Drawing.Image)(resources.GetObject("p_logo.Image")));
            this.p_logo.Location = new System.Drawing.Point(15, 22);
            this.p_logo.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.p_logo.Name = "p_logo";
            this.p_logo.Size = new System.Drawing.Size(117, 50);
            this.p_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p_logo.TabIndex = 1;
            this.p_logo.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.gv_payments, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(902, 440);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // gv_payments
            // 
            this.gv_payments.AllowUserToAddRows = false;
            this.gv_payments.AllowUserToDeleteRows = false;
            this.gv_payments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_payments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_payments.Location = new System.Drawing.Point(3, 3);
            this.gv_payments.Name = "gv_payments";
            this.gv_payments.ReadOnly = true;
            this.gv_payments.RowHeadersWidth = 51;
            this.gv_payments.RowTemplate.Height = 24;
            this.gv_payments.Size = new System.Drawing.Size(896, 346);
            this.gv_payments.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.b_remove, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.b_send_notification, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.b_verify, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 355);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(896, 82);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // b_remove
            // 
            this.b_remove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_remove.BackColor = System.Drawing.SystemColors.HotTrack;
            this.b_remove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_remove.ForeColor = System.Drawing.Color.White;
            this.b_remove.Location = new System.Drawing.Point(681, 24);
            this.b_remove.MinimumSize = new System.Drawing.Size(130, 34);
            this.b_remove.Name = "b_remove";
            this.b_remove.Size = new System.Drawing.Size(130, 34);
            this.b_remove.TabIndex = 13;
            this.b_remove.Text = "Remove";
            this.b_remove.UseVisualStyleBackColor = false;
            this.b_remove.Click += new System.EventHandler(this.b_remove_Click);
            // 
            // b_send_notification
            // 
            this.b_send_notification.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_send_notification.BackColor = System.Drawing.SystemColors.HotTrack;
            this.b_send_notification.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_send_notification.ForeColor = System.Drawing.Color.White;
            this.b_send_notification.Location = new System.Drawing.Point(379, 24);
            this.b_send_notification.MinimumSize = new System.Drawing.Size(130, 34);
            this.b_send_notification.Name = "b_send_notification";
            this.b_send_notification.Size = new System.Drawing.Size(136, 34);
            this.b_send_notification.TabIndex = 12;
            this.b_send_notification.Text = "Send Notification";
            this.b_send_notification.UseVisualStyleBackColor = false;
            this.b_send_notification.Click += new System.EventHandler(this.b_send_notification_Click);
            // 
            // b_verify
            // 
            this.b_verify.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_verify.BackColor = System.Drawing.SystemColors.HotTrack;
            this.b_verify.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_verify.ForeColor = System.Drawing.Color.White;
            this.b_verify.Location = new System.Drawing.Point(84, 24);
            this.b_verify.MinimumSize = new System.Drawing.Size(130, 34);
            this.b_verify.Name = "b_verify";
            this.b_verify.Size = new System.Drawing.Size(130, 34);
            this.b_verify.TabIndex = 11;
            this.b_verify.Text = "Verify";
            this.b_verify.UseVisualStyleBackColor = false;
            this.b_verify.Click += new System.EventHandler(this.b_verify_Click);
            // 
            // Teacher_Payment_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 546);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Teacher_Payment_Management";
            this.Text = "Teacher_Payment_Management";
            this.Load += new System.EventHandler(this.Teacher_Payment_Management_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p_logo)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_payments)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox p_logo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView gv_payments;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button b_remove;
        private System.Windows.Forms.Button b_send_notification;
        private System.Windows.Forms.Button b_verify;
    }
}