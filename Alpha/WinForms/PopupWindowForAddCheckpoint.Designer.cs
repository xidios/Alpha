namespace Alpha
{
    partial class PopupWindowForAddCheckpoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupWindowForAddCheckpoint));
            this.checkpointDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.checkpointNameInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.specialIdInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkpointDescriptionInput
            // 
            this.checkpointDescriptionInput.Location = new System.Drawing.Point(14, 78);
            this.checkpointDescriptionInput.MaxLength = 255;
            this.checkpointDescriptionInput.Name = "checkpointDescriptionInput";
            this.checkpointDescriptionInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.checkpointDescriptionInput.Size = new System.Drawing.Size(282, 96);
            this.checkpointDescriptionInput.TabIndex = 17;
            this.checkpointDescriptionInput.Text = "";
            // 
            // checkpointNameInput
            // 
            this.checkpointNameInput.Location = new System.Drawing.Point(14, 39);
            this.checkpointNameInput.MaxLength = 100;
            this.checkpointNameInput.Name = "checkpointNameInput";
            this.checkpointNameInput.Size = new System.Drawing.Size(282, 20);
            this.checkpointNameInput.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(154, 220);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(73, 220);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 12;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Special ID ( can be nullable )";
            // 
            // specialIdInput
            // 
            this.specialIdInput.Location = new System.Drawing.Point(14, 194);
            this.specialIdInput.MaxLength = 100;
            this.specialIdInput.Name = "specialIdInput";
            this.specialIdInput.Size = new System.Drawing.Size(282, 20);
            this.specialIdInput.TabIndex = 25;
            // 
            // PopupWindowForAddCheckpoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 257);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.specialIdInput);
            this.Controls.Add(this.checkpointDescriptionInput);
            this.Controls.Add(this.checkpointNameInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PopupWindowForAddCheckpoint";
            this.Text = "Create Checkpoint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox checkpointDescriptionInput;
        private System.Windows.Forms.TextBox checkpointNameInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox specialIdInput;
    }
}