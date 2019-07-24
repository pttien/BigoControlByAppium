namespace BigoController
{
    partial class mainFrom
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
            this.buffViewBtn = new System.Windows.Forms.Button();
            this.idInput = new System.Windows.Forms.TextBox();
            this.thaTimBtn = new System.Windows.Forms.Button();
            this.commentBtn = new System.Windows.Forms.Button();
            this.thoigianthatim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buffViewBtn
            // 
            this.buffViewBtn.Location = new System.Drawing.Point(319, 77);
            this.buffViewBtn.Name = "buffViewBtn";
            this.buffViewBtn.Size = new System.Drawing.Size(126, 41);
            this.buffViewBtn.TabIndex = 0;
            this.buffViewBtn.Text = "Vào room";
            this.buffViewBtn.UseVisualStyleBackColor = true;
            this.buffViewBtn.Click += new System.EventHandler(this.buffViewBtn_Click);
            // 
            // idInput
            // 
            this.idInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idInput.Location = new System.Drawing.Point(113, 77);
            this.idInput.Multiline = true;
            this.idInput.Name = "idInput";
            this.idInput.Size = new System.Drawing.Size(170, 34);
            this.idInput.TabIndex = 1;
            // 
            // thaTimBtn
            // 
            this.thaTimBtn.Location = new System.Drawing.Point(319, 145);
            this.thaTimBtn.Name = "thaTimBtn";
            this.thaTimBtn.Size = new System.Drawing.Size(128, 49);
            this.thaTimBtn.TabIndex = 2;
            this.thaTimBtn.Text = "Thả tim\r\n";
            this.thaTimBtn.UseVisualStyleBackColor = true;
            this.thaTimBtn.Click += new System.EventHandler(this.thaTimBtn_Click);
            // 
            // commentBtn
            // 
            this.commentBtn.Location = new System.Drawing.Point(319, 222);
            this.commentBtn.Name = "commentBtn";
            this.commentBtn.Size = new System.Drawing.Size(128, 49);
            this.commentBtn.TabIndex = 2;
            this.commentBtn.Text = "Comment";
            this.commentBtn.UseVisualStyleBackColor = true;
            this.commentBtn.Click += new System.EventHandler(this.commentBtn_Click);
            // 
            // thoigianthatim
            // 
            this.thoigianthatim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoigianthatim.Location = new System.Drawing.Point(463, 155);
            this.thoigianthatim.Multiline = true;
            this.thoigianthatim.Name = "thoigianthatim";
            this.thoigianthatim.Size = new System.Drawing.Size(116, 29);
            this.thoigianthatim.TabIndex = 1;
            this.thoigianthatim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.thoigianthatim_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(460, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thời gian thả tim (tính bằng giây)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nhập Id (nhập chính xác nha)";
            // 
            // mainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commentBtn);
            this.Controls.Add(this.thaTimBtn);
            this.Controls.Add(this.thoigianthatim);
            this.Controls.Add(this.idInput);
            this.Controls.Add(this.buffViewBtn);
            this.Name = "mainFrom";
            this.Text = "Điều Khiển Bigo";
            this.Load += new System.EventHandler(this.mainFrom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buffViewBtn;
        private System.Windows.Forms.TextBox idInput;
        private System.Windows.Forms.Button thaTimBtn;
        private System.Windows.Forms.Button commentBtn;
        private System.Windows.Forms.TextBox thoigianthatim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

