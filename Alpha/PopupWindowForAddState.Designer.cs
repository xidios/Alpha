namespace Alpha
{
    partial class PopupWindowForAddState
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StateDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.StateNameInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(81, 173);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(162, 173);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // StateDescriptionInput
            // 
            this.StateDescriptionInput.Location = new System.Drawing.Point(12, 71);
            this.StateDescriptionInput.MaxLength = 255;
            this.StateDescriptionInput.Name = "StateDescriptionInput";
            this.StateDescriptionInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.StateDescriptionInput.Size = new System.Drawing.Size(282, 96);
            this.StateDescriptionInput.TabIndex = 11;
            this.StateDescriptionInput.Text = "";
            // 
            // StateNameInput
            // 
            this.StateNameInput.Location = new System.Drawing.Point(12, 32);
            this.StateNameInput.MaxLength = 100;
            this.StateNameInput.Name = "StateNameInput";
            this.StateNameInput.Size = new System.Drawing.Size(282, 20);
            this.StateNameInput.TabIndex = 10;
            // 
            // PopupWindowForAddState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 216);
            this.Controls.Add(this.StateDescriptionInput);
            this.Controls.Add(this.StateNameInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonAdd);
            this.Name = "PopupWindowForAddState";
            this.Text = "Add state";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox StateDescriptionInput;
        private System.Windows.Forms.TextBox StateNameInput;
    }
}