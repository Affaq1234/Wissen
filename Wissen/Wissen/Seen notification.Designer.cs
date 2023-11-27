namespace Wissen
{
    partial class Seen_notification
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.b_remove = new System.Windows.Forms.Button();
            this.lbl_notification = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.b_remove, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_notification, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 150);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // b_remove
            // 
            this.b_remove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_remove.BackColor = System.Drawing.SystemColors.HotTrack;
            this.b_remove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_remove.ForeColor = System.Drawing.Color.White;
            this.b_remove.Location = new System.Drawing.Point(481, 58);
            this.b_remove.MinimumSize = new System.Drawing.Size(130, 34);
            this.b_remove.Name = "b_remove";
            this.b_remove.Size = new System.Drawing.Size(130, 34);
            this.b_remove.TabIndex = 11;
            this.b_remove.Text = "Remove";
            this.b_remove.UseVisualStyleBackColor = false;
            this.b_remove.Click += new System.EventHandler(this.b_remove_Click);
            // 
            // lbl_notification
            // 
            this.lbl_notification.AutoSize = true;
            this.lbl_notification.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbl_notification.Location = new System.Drawing.Point(5, 5);
            this.lbl_notification.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_notification.Name = "lbl_notification";
            this.lbl_notification.Size = new System.Drawing.Size(70, 16);
            this.lbl_notification.TabIndex = 0;
            this.lbl_notification.Text = "notification";
            // 
            // Seen_notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Seen_notification";
            this.Size = new System.Drawing.Size(621, 150);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button b_remove;
        private System.Windows.Forms.Label lbl_notification;
    }
}
