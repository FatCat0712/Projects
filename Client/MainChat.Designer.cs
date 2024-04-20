namespace Client
{
    partial class MainChat
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
            this.bConnect = new System.Windows.Forms.Button();
            this.tchat = new System.Windows.Forms.TextBox();
            this.bSend = new System.Windows.Forms.Button();
            this.lchat = new System.Windows.Forms.ListBox();
            this.cbContacts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contact List";
            // 
            // bConnect
            // 
            this.bConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bConnect.Location = new System.Drawing.Point(645, 15);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(115, 32);
            this.bConnect.TabIndex = 2;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // tchat
            // 
            this.tchat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tchat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tchat.Location = new System.Drawing.Point(56, 384);
            this.tchat.Multiline = true;
            this.tchat.Name = "tchat";
            this.tchat.Size = new System.Drawing.Size(563, 30);
            this.tchat.TabIndex = 4;
            // 
            // bSend
            // 
            this.bSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSend.Location = new System.Drawing.Point(645, 384);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(98, 32);
            this.bSend.TabIndex = 5;
            this.bSend.Text = "Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // lchat
            // 
            this.lchat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lchat.FormattingEnabled = true;
            this.lchat.ItemHeight = 20;
            this.lchat.Location = new System.Drawing.Point(56, 77);
            this.lchat.Name = "lchat";
            this.lchat.Size = new System.Drawing.Size(704, 264);
            this.lchat.TabIndex = 6;
            // 
            // cbContacts
            // 
            this.cbContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContacts.FormattingEnabled = true;
            this.cbContacts.Location = new System.Drawing.Point(263, 22);
            this.cbContacts.Name = "cbContacts";
            this.cbContacts.Size = new System.Drawing.Size(288, 26);
            this.cbContacts.TabIndex = 7;
            // 
            // MainChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbContacts);
            this.Controls.Add(this.lchat);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.tchat);
            this.Controls.Add(this.bConnect);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
        
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.TextBox tchat;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.ListBox lchat;
        private System.Windows.Forms.ComboBox cbContacts;
    }
}

