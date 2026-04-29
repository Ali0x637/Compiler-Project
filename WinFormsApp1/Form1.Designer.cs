namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCode = new TextBox();
            Split = new Button();
            label1 = new Label();
            label2 = new Label();
            dgvTokens = new DataGridView();
            Lexeme = new DataGridViewTextBoxColumn();
            TokenType = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvTokens).BeginInit();
            SuspendLayout();
            // 
            // txtCode
            // 
            txtCode.Location = new Point(21, 68);
            txtCode.Multiline = true;
            txtCode.Name = "txtCode";
            txtCode.ScrollBars = ScrollBars.Vertical;
            txtCode.Size = new Size(425, 298);
            txtCode.TabIndex = 0;
            // 
            // Split
            // 
            Split.BackColor = SystemColors.ActiveBorder;
            Split.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Split.Location = new Point(370, 398);
            Split.Name = "Split";
            Split.Size = new Size(125, 46);
            Split.TabIndex = 1;
            Split.Text = "Split";
            Split.UseVisualStyleBackColor = false;
            Split.Click += Split_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveBorder;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 24);
            label1.Name = "label1";
            label1.Size = new Size(164, 30);
            label1.TabIndex = 2;
            label1.Text = "Tiny Code Input";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveBorder;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(497, 24);
            label2.Name = "label2";
            label2.Size = new Size(152, 30);
            label2.TabIndex = 3;
            label2.Text = "Tokens Output";
            // 
            // dgvTokens
            // 
            dgvTokens.BackgroundColor = SystemColors.AppWorkspace;
            dgvTokens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTokens.Columns.AddRange(new DataGridViewColumn[] { Lexeme, TokenType });
            dgvTokens.GridColor = SystemColors.ScrollBar;
            dgvTokens.Location = new Point(497, 68);
            dgvTokens.Name = "dgvTokens";
            dgvTokens.RowHeadersWidth = 51;
            dgvTokens.Size = new Size(303, 298);
            dgvTokens.TabIndex = 4;
            // 
            // Lexeme
            // 
            Lexeme.HeaderText = "Lexeme";
            Lexeme.MinimumWidth = 6;
            Lexeme.Name = "Lexeme";
            Lexeme.Width = 125;
            // 
            // TokenType
            // 
            TokenType.HeaderText = "TokenType";
            TokenType.MinimumWidth = 6;
            TokenType.Name = "TokenType";
            TokenType.Width = 125;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(850, 470);
            Controls.Add(dgvTokens);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Split);
            Controls.Add(txtCode);
            Name = "Form1";
            Text = "Compiler Project";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTokens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCode;
        private Button Split;
        private Label label1;
        private Label label2;
        private DataGridView dgvTokens;
        private DataGridViewTextBoxColumn Lexeme;
        private DataGridViewTextBoxColumn TokenType;
    }
}
