namespace Alpha
{
    partial class PopupWindowForAddAlpha
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.alphaNameInput = new System.Windows.Forms.TextBox();
            this.alphaDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.labelAlphaName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAlphas = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxChildAlpha = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(193, 300);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(112, 300);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // alphaNameInput
            // 
            this.alphaNameInput.Location = new System.Drawing.Point(106, 39);
            this.alphaNameInput.MaxLength = 100;
            this.alphaNameInput.Name = "alphaNameInput";
            this.alphaNameInput.Size = new System.Drawing.Size(282, 20);
            this.alphaNameInput.TabIndex = 2;
            // 
            // alphaDescriptionInput
            // 
            this.alphaDescriptionInput.Location = new System.Drawing.Point(106, 65);
            this.alphaDescriptionInput.MaxLength = 255;
            this.alphaDescriptionInput.Name = "alphaDescriptionInput";
            this.alphaDescriptionInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.alphaDescriptionInput.Size = new System.Drawing.Size(282, 96);
            this.alphaDescriptionInput.TabIndex = 3;
            this.alphaDescriptionInput.Text = "";
            // 
            // labelAlphaName
            // 
            this.labelAlphaName.AutoSize = true;
            this.labelAlphaName.Location = new System.Drawing.Point(12, 39);
            this.labelAlphaName.Name = "labelAlphaName";
            this.labelAlphaName.Size = new System.Drawing.Size(63, 13);
            this.labelAlphaName.TabIndex = 4;
            this.labelAlphaName.Text = "Alpha name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alpha description";
            // 
            // listBoxAlphas
            // 
            this.listBoxAlphas.Enabled = false;
            this.listBoxAlphas.FormattingEnabled = true;
            this.listBoxAlphas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listBoxAlphas.Location = new System.Drawing.Point(106, 199);
            this.listBoxAlphas.Name = "listBoxAlphas";
            this.listBoxAlphas.Size = new System.Drawing.Size(282, 95);
            this.listBoxAlphas.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Alpha parent";
            // 
            // checkBoxChildAlpha
            // 
            this.checkBoxChildAlpha.AutoSize = true;
            this.checkBoxChildAlpha.Location = new System.Drawing.Point(106, 168);
            this.checkBoxChildAlpha.Name = "checkBoxChildAlpha";
            this.checkBoxChildAlpha.Size = new System.Drawing.Size(121, 17);
            this.checkBoxChildAlpha.TabIndex = 8;
            this.checkBoxChildAlpha.Text = "Is the alpha a child?";
            this.checkBoxChildAlpha.UseVisualStyleBackColor = true;
            this.checkBoxChildAlpha.CheckedChanged += new System.EventHandler(this.checkBoxChildAlpha_CheckedChanged);
            // 
            // PopupWindowForAddAlpha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 335);
            this.Controls.Add(this.checkBoxChildAlpha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxAlphas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAlphaName);
            this.Controls.Add(this.alphaDescriptionInput);
            this.Controls.Add(this.alphaNameInput);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonClose);
            this.Name = "PopupWindowForAddAlpha";
            this.Text = "Add a new alpha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox alphaNameInput;
        private System.Windows.Forms.RichTextBox alphaDescriptionInput;
        private System.Windows.Forms.Label labelAlphaName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAlphas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxChildAlpha;
    }
}