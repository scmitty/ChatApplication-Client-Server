namespace Chat_Client
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.usernameChat_txb = new System.Windows.Forms.TextBox();
            this.connection_btn = new System.Windows.Forms.Button();
            this.chat_txb = new System.Windows.Forms.TextBox();
            this.sendMsg_btn = new System.Windows.Forms.Button();
            this.msg_txb = new System.Windows.Forms.TextBox();
            this.esc_btn = new System.Windows.Forms.Button();
            this.disconnect_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // usernameChat_txb
            // 
            this.usernameChat_txb.Location = new System.Drawing.Point(233, 18);
            this.usernameChat_txb.Margin = new System.Windows.Forms.Padding(4);
            this.usernameChat_txb.Name = "usernameChat_txb";
            this.usernameChat_txb.Size = new System.Drawing.Size(216, 30);
            this.usernameChat_txb.TabIndex = 1;
            // 
            // connection_btn
            // 
            this.connection_btn.Location = new System.Drawing.Point(231, 48);
            this.connection_btn.Margin = new System.Windows.Forms.Padding(4);
            this.connection_btn.Name = "connection_btn";
            this.connection_btn.Size = new System.Drawing.Size(218, 28);
            this.connection_btn.TabIndex = 2;
            this.connection_btn.Text = "Connect To Chat";
            this.connection_btn.UseVisualStyleBackColor = true;
            this.connection_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // chat_txb
            // 
            this.chat_txb.Location = new System.Drawing.Point(24, 81);
            this.chat_txb.Margin = new System.Windows.Forms.Padding(4);
            this.chat_txb.Multiline = true;
            this.chat_txb.Name = "chat_txb";
            this.chat_txb.ReadOnly = true;
            this.chat_txb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chat_txb.Size = new System.Drawing.Size(436, 196);
            this.chat_txb.TabIndex = 3;
            // 
            // sendMsg_btn
            // 
            this.sendMsg_btn.Location = new System.Drawing.Point(261, 330);
            this.sendMsg_btn.Margin = new System.Windows.Forms.Padding(4);
            this.sendMsg_btn.Name = "sendMsg_btn";
            this.sendMsg_btn.Size = new System.Drawing.Size(201, 28);
            this.sendMsg_btn.TabIndex = 4;
            this.sendMsg_btn.Text = "Send Message";
            this.sendMsg_btn.UseVisualStyleBackColor = true;
            this.sendMsg_btn.Click += new System.EventHandler(this.sendMsg_btn_Click);
            // 
            // msg_txb
            // 
            this.msg_txb.Location = new System.Drawing.Point(24, 298);
            this.msg_txb.Margin = new System.Windows.Forms.Padding(4);
            this.msg_txb.Name = "msg_txb";
            this.msg_txb.Size = new System.Drawing.Size(436, 30);
            this.msg_txb.TabIndex = 5;
            // 
            // esc_btn
            // 
            this.esc_btn.Location = new System.Drawing.Point(261, 366);
            this.esc_btn.Margin = new System.Windows.Forms.Padding(4);
            this.esc_btn.Name = "esc_btn";
            this.esc_btn.Size = new System.Drawing.Size(201, 28);
            this.esc_btn.TabIndex = 6;
            this.esc_btn.Text = "Exit";
            this.esc_btn.UseVisualStyleBackColor = true;
            this.esc_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // disconnect_btn
            // 
            this.disconnect_btn.Location = new System.Drawing.Point(24, 364);
            this.disconnect_btn.Margin = new System.Windows.Forms.Padding(4);
            this.disconnect_btn.Name = "disconnect_btn";
            this.disconnect_btn.Size = new System.Drawing.Size(201, 28);
            this.disconnect_btn.TabIndex = 7;
            this.disconnect_btn.Text = "Disconnect";
            this.disconnect_btn.UseVisualStyleBackColor = true;
            this.disconnect_btn.Click += new System.EventHandler(this.disconnect_btn_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.sendMsg_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 407);
            this.Controls.Add(this.disconnect_btn);
            this.Controls.Add(this.esc_btn);
            this.Controls.Add(this.msg_txb);
            this.Controls.Add(this.sendMsg_btn);
            this.Controls.Add(this.chat_txb);
            this.Controls.Add(this.connection_btn);
            this.Controls.Add(this.usernameChat_txb);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Forum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameChat_txb;
        private System.Windows.Forms.Button connection_btn;
        private System.Windows.Forms.TextBox chat_txb;
        private System.Windows.Forms.Button sendMsg_btn;
        private System.Windows.Forms.TextBox msg_txb;
        private System.Windows.Forms.Button esc_btn;
        private System.Windows.Forms.Button disconnect_btn;
    }
}

