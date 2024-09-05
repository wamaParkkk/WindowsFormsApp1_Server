namespace WindowsFormsApp1_Server
{
    partial class ServerForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxServerStatus = new System.Windows.Forms.RichTextBox();
            this.richTextBoxRecvMsg = new System.Windows.Forms.RichTextBox();
            this.panelUnloader1_Red = new System.Windows.Forms.Panel();
            this.panelUnloader1_Yellow = new System.Windows.Forms.Panel();
            this.panelUnloader1_Green = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(465, 743);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Message received from the client";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 743);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Client connection";
            // 
            // richTextBoxServerStatus
            // 
            this.richTextBoxServerStatus.BackColor = System.Drawing.Color.White;
            this.richTextBoxServerStatus.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxServerStatus.Location = new System.Drawing.Point(12, 763);
            this.richTextBoxServerStatus.Name = "richTextBoxServerStatus";
            this.richTextBoxServerStatus.ReadOnly = true;
            this.richTextBoxServerStatus.Size = new System.Drawing.Size(450, 210);
            this.richTextBoxServerStatus.TabIndex = 13;
            this.richTextBoxServerStatus.Text = "";
            // 
            // richTextBoxRecvMsg
            // 
            this.richTextBoxRecvMsg.BackColor = System.Drawing.Color.White;
            this.richTextBoxRecvMsg.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxRecvMsg.Location = new System.Drawing.Point(468, 763);
            this.richTextBoxRecvMsg.Name = "richTextBoxRecvMsg";
            this.richTextBoxRecvMsg.ReadOnly = true;
            this.richTextBoxRecvMsg.Size = new System.Drawing.Size(790, 210);
            this.richTextBoxRecvMsg.TabIndex = 12;
            this.richTextBoxRecvMsg.Text = "";
            // 
            // panelUnloader1_Red
            // 
            this.panelUnloader1_Red.BackColor = System.Drawing.Color.White;
            this.panelUnloader1_Red.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUnloader1_Red.Location = new System.Drawing.Point(12, 12);
            this.panelUnloader1_Red.Name = "panelUnloader1_Red";
            this.panelUnloader1_Red.Size = new System.Drawing.Size(200, 100);
            this.panelUnloader1_Red.TabIndex = 16;
            // 
            // panelUnloader1_Yellow
            // 
            this.panelUnloader1_Yellow.BackColor = System.Drawing.Color.White;
            this.panelUnloader1_Yellow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUnloader1_Yellow.Location = new System.Drawing.Point(12, 118);
            this.panelUnloader1_Yellow.Name = "panelUnloader1_Yellow";
            this.panelUnloader1_Yellow.Size = new System.Drawing.Size(200, 100);
            this.panelUnloader1_Yellow.TabIndex = 17;
            // 
            // panelUnloader1_Green
            // 
            this.panelUnloader1_Green.BackColor = System.Drawing.Color.White;
            this.panelUnloader1_Green.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUnloader1_Green.Location = new System.Drawing.Point(12, 224);
            this.panelUnloader1_Green.Name = "panelUnloader1_Green";
            this.panelUnloader1_Green.Size = new System.Drawing.Size(200, 100);
            this.panelUnloader1_Green.TabIndex = 18;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.panelUnloader1_Green);
            this.Controls.Add(this.panelUnloader1_Yellow);
            this.Controls.Add(this.panelUnloader1_Red);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxServerStatus);
            this.Controls.Add(this.richTextBoxRecvMsg);
            this.Name = "ServerForm";
            this.Text = "[Server] Alarm monitoring";
            this.Activated += new System.EventHandler(this.ServerForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxServerStatus;
        private System.Windows.Forms.RichTextBox richTextBoxRecvMsg;
        private System.Windows.Forms.Panel panelUnloader1_Red;
        private System.Windows.Forms.Panel panelUnloader1_Yellow;
        private System.Windows.Forms.Panel panelUnloader1_Green;
    }
}

