﻿namespace WindowsFormsApp1_Server
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
            this.label3 = new System.Windows.Forms.Label();
            this.labl_Unloader1 = new System.Windows.Forms.Label();
            this.labl_Unloader2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labl_Unloader3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labl_Unloader4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labl_Unloader5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxUnloader1 = new System.Windows.Forms.TextBox();
            this.textBoxUnloader2 = new System.Windows.Forms.TextBox();
            this.textBoxUnloader3 = new System.Windows.Forms.TextBox();
            this.textBoxUnloader4 = new System.Windows.Forms.TextBox();
            this.textBoxUnloader5 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBuzzerOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(465, 813);
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
            this.label1.Location = new System.Drawing.Point(9, 813);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Client connection";
            // 
            // richTextBoxServerStatus
            // 
            this.richTextBoxServerStatus.BackColor = System.Drawing.Color.White;
            this.richTextBoxServerStatus.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxServerStatus.Location = new System.Drawing.Point(12, 833);
            this.richTextBoxServerStatus.Name = "richTextBoxServerStatus";
            this.richTextBoxServerStatus.ReadOnly = true;
            this.richTextBoxServerStatus.Size = new System.Drawing.Size(450, 140);
            this.richTextBoxServerStatus.TabIndex = 13;
            this.richTextBoxServerStatus.Text = "";
            // 
            // richTextBoxRecvMsg
            // 
            this.richTextBoxRecvMsg.BackColor = System.Drawing.Color.White;
            this.richTextBoxRecvMsg.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxRecvMsg.Location = new System.Drawing.Point(468, 833);
            this.richTextBoxRecvMsg.Name = "richTextBoxRecvMsg";
            this.richTextBoxRecvMsg.ReadOnly = true;
            this.richTextBoxRecvMsg.Size = new System.Drawing.Size(790, 140);
            this.richTextBoxRecvMsg.TabIndex = 12;
            this.richTextBoxRecvMsg.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 37);
            this.label3.TabIndex = 19;
            this.label3.Text = "K2022-1101253";
            // 
            // labl_Unloader1
            // 
            this.labl_Unloader1.BackColor = System.Drawing.Color.Silver;
            this.labl_Unloader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labl_Unloader1.Font = new System.Drawing.Font("Nirmala UI", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labl_Unloader1.ForeColor = System.Drawing.Color.White;
            this.labl_Unloader1.Location = new System.Drawing.Point(12, 46);
            this.labl_Unloader1.Name = "labl_Unloader1";
            this.labl_Unloader1.Size = new System.Drawing.Size(1240, 120);
            this.labl_Unloader1.TabIndex = 20;
            this.labl_Unloader1.Text = "--";
            this.labl_Unloader1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labl_Unloader2
            // 
            this.labl_Unloader2.BackColor = System.Drawing.Color.Silver;
            this.labl_Unloader2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labl_Unloader2.Font = new System.Drawing.Font("Nirmala UI", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labl_Unloader2.ForeColor = System.Drawing.Color.White;
            this.labl_Unloader2.Location = new System.Drawing.Point(12, 205);
            this.labl_Unloader2.Name = "labl_Unloader2";
            this.labl_Unloader2.Size = new System.Drawing.Size(1240, 120);
            this.labl_Unloader2.TabIndex = 22;
            this.labl_Unloader2.Text = "--";
            this.labl_Unloader2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(12, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 37);
            this.label4.TabIndex = 21;
            this.label4.Text = "K2023-1100445";
            // 
            // labl_Unloader3
            // 
            this.labl_Unloader3.BackColor = System.Drawing.Color.Silver;
            this.labl_Unloader3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labl_Unloader3.Font = new System.Drawing.Font("Nirmala UI", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labl_Unloader3.ForeColor = System.Drawing.Color.White;
            this.labl_Unloader3.Location = new System.Drawing.Point(12, 364);
            this.labl_Unloader3.Name = "labl_Unloader3";
            this.labl_Unloader3.Size = new System.Drawing.Size(1240, 120);
            this.labl_Unloader3.TabIndex = 24;
            this.labl_Unloader3.Text = "--";
            this.labl_Unloader3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(5, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 37);
            this.label5.TabIndex = 23;
            this.label5.Text = "K2023-1100333";
            // 
            // labl_Unloader4
            // 
            this.labl_Unloader4.BackColor = System.Drawing.Color.Silver;
            this.labl_Unloader4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labl_Unloader4.Font = new System.Drawing.Font("Nirmala UI", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labl_Unloader4.ForeColor = System.Drawing.Color.White;
            this.labl_Unloader4.Location = new System.Drawing.Point(12, 523);
            this.labl_Unloader4.Name = "labl_Unloader4";
            this.labl_Unloader4.Size = new System.Drawing.Size(1240, 120);
            this.labl_Unloader4.TabIndex = 26;
            this.labl_Unloader4.Text = "--";
            this.labl_Unloader4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(12, 486);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 37);
            this.label6.TabIndex = 25;
            this.label6.Text = "K2023-1100334";
            // 
            // labl_Unloader5
            // 
            this.labl_Unloader5.BackColor = System.Drawing.Color.Silver;
            this.labl_Unloader5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labl_Unloader5.Font = new System.Drawing.Font("Nirmala UI", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labl_Unloader5.ForeColor = System.Drawing.Color.White;
            this.labl_Unloader5.Location = new System.Drawing.Point(12, 682);
            this.labl_Unloader5.Name = "labl_Unloader5";
            this.labl_Unloader5.Size = new System.Drawing.Size(1240, 120);
            this.labl_Unloader5.TabIndex = 28;
            this.labl_Unloader5.Text = "--";
            this.labl_Unloader5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(12, 645);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(222, 37);
            this.label7.TabIndex = 27;
            this.label7.Text = "K2023-1100292";
            // 
            // textBoxUnloader1
            // 
            this.textBoxUnloader1.BackColor = System.Drawing.Color.Beige;
            this.textBoxUnloader1.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnloader1.ForeColor = System.Drawing.Color.Black;
            this.textBoxUnloader1.Location = new System.Drawing.Point(240, 9);
            this.textBoxUnloader1.Name = "textBoxUnloader1";
            this.textBoxUnloader1.Size = new System.Drawing.Size(510, 35);
            this.textBoxUnloader1.TabIndex = 29;
            // 
            // textBoxUnloader2
            // 
            this.textBoxUnloader2.BackColor = System.Drawing.Color.Beige;
            this.textBoxUnloader2.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnloader2.ForeColor = System.Drawing.Color.Black;
            this.textBoxUnloader2.Location = new System.Drawing.Point(240, 168);
            this.textBoxUnloader2.Name = "textBoxUnloader2";
            this.textBoxUnloader2.Size = new System.Drawing.Size(510, 35);
            this.textBoxUnloader2.TabIndex = 30;
            // 
            // textBoxUnloader3
            // 
            this.textBoxUnloader3.BackColor = System.Drawing.Color.Beige;
            this.textBoxUnloader3.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnloader3.ForeColor = System.Drawing.Color.Black;
            this.textBoxUnloader3.Location = new System.Drawing.Point(240, 327);
            this.textBoxUnloader3.Name = "textBoxUnloader3";
            this.textBoxUnloader3.Size = new System.Drawing.Size(510, 35);
            this.textBoxUnloader3.TabIndex = 31;
            // 
            // textBoxUnloader4
            // 
            this.textBoxUnloader4.BackColor = System.Drawing.Color.Beige;
            this.textBoxUnloader4.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnloader4.ForeColor = System.Drawing.Color.Black;
            this.textBoxUnloader4.Location = new System.Drawing.Point(240, 486);
            this.textBoxUnloader4.Name = "textBoxUnloader4";
            this.textBoxUnloader4.Size = new System.Drawing.Size(510, 35);
            this.textBoxUnloader4.TabIndex = 32;
            // 
            // textBoxUnloader5
            // 
            this.textBoxUnloader5.BackColor = System.Drawing.Color.Beige;
            this.textBoxUnloader5.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnloader5.ForeColor = System.Drawing.Color.Black;
            this.textBoxUnloader5.Location = new System.Drawing.Point(240, 645);
            this.textBoxUnloader5.Name = "textBoxUnloader5";
            this.textBoxUnloader5.Size = new System.Drawing.Size(510, 35);
            this.textBoxUnloader5.TabIndex = 33;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Navy;
            this.btnSave.Location = new System.Drawing.Point(756, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBuzzerOff
            // 
            this.btnBuzzerOff.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuzzerOff.ForeColor = System.Drawing.Color.Red;
            this.btnBuzzerOff.Location = new System.Drawing.Point(1102, 9);
            this.btnBuzzerOff.Name = "btnBuzzerOff";
            this.btnBuzzerOff.Size = new System.Drawing.Size(150, 35);
            this.btnBuzzerOff.TabIndex = 40;
            this.btnBuzzerOff.Text = "Buzzer off";
            this.btnBuzzerOff.UseVisualStyleBackColor = true;
            this.btnBuzzerOff.Click += new System.EventHandler(this.btnBuzzerOff_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 985);
            this.Controls.Add(this.btnBuzzerOff);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBoxUnloader5);
            this.Controls.Add(this.textBoxUnloader4);
            this.Controls.Add(this.textBoxUnloader3);
            this.Controls.Add(this.textBoxUnloader2);
            this.Controls.Add(this.textBoxUnloader1);
            this.Controls.Add(this.labl_Unloader5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labl_Unloader4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labl_Unloader3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labl_Unloader2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labl_Unloader1);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labl_Unloader1;
        private System.Windows.Forms.Label labl_Unloader2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labl_Unloader3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labl_Unloader4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labl_Unloader5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxUnloader1;
        private System.Windows.Forms.TextBox textBoxUnloader2;
        private System.Windows.Forms.TextBox textBoxUnloader3;
        private System.Windows.Forms.TextBox textBoxUnloader4;
        private System.Windows.Forms.TextBox textBoxUnloader5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBuzzerOff;
    }
}

