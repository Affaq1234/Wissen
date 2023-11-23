namespace Wissen
{
    partial class Chat_item
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
            this.b_chat = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.p_image = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.p_image)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_chat
            // 
            this.b_chat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.b_chat.BackColor = System.Drawing.SystemColors.HotTrack;
            this.b_chat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.b_chat.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_chat.ForeColor = System.Drawing.Color.White;
            this.b_chat.Location = new System.Drawing.Point(406, 43);
            this.b_chat.MinimumSize = new System.Drawing.Size(105, 35);
            this.b_chat.Name = "b_chat";
            this.b_chat.Size = new System.Drawing.Size(105, 35);
            this.b_chat.TabIndex = 5;
            this.b_chat.Text = "Chat";
            this.b_chat.UseVisualStyleBackColor = false;
            this.b_chat.Click += new System.EventHandler(this.b_chat_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(130, 49);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(57, 22);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "Name";
            // 
            // p_image
            // 
            this.p_image.BackColor = System.Drawing.Color.White;
            this.p_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_image.Location = new System.Drawing.Point(5, 5);
            this.p_image.Margin = new System.Windows.Forms.Padding(5);
            this.p_image.Name = "p_image";
            this.p_image.Size = new System.Drawing.Size(110, 111);
            this.p_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p_image.TabIndex = 0;
            this.p_image.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.Controls.Add(this.p_image, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_name, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.b_chat, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(519, 121);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Chat_item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Chat_item";
            this.Size = new System.Drawing.Size(519, 121);
            ((System.ComponentModel.ISupportInitialize)(this.p_image)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_chat;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.PictureBox p_image;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
