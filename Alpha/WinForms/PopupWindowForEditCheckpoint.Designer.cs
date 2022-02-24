namespace Alpha
{
    partial class PopupWindowForEditCheckpoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupWindowForEditCheckpoint));
            this.checkpointOrderInput = new System.Windows.Forms.NumericUpDown();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkpointDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.checkpointNameInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddDegreeOfEvidence = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.checkpointOrderInput)).BeginInit();
            this.SuspendLayout();
            // 
            // checkpointOrderInput
            // 
            this.checkpointOrderInput.Location = new System.Drawing.Point(12, 218);
            this.checkpointOrderInput.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.checkpointOrderInput.Name = "checkpointOrderInput";
            this.checkpointOrderInput.Size = new System.Drawing.Size(282, 20);
            this.checkpointOrderInput.TabIndex = 36;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(12, 244);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 35;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(103, 244);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 34;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Order";
            // 
            // checkpointDescriptionInput
            // 
            this.checkpointDescriptionInput.Location = new System.Drawing.Point(12, 103);
            this.checkpointDescriptionInput.MaxLength = 255;
            this.checkpointDescriptionInput.Name = "checkpointDescriptionInput";
            this.checkpointDescriptionInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.checkpointDescriptionInput.Size = new System.Drawing.Size(282, 96);
            this.checkpointDescriptionInput.TabIndex = 32;
            this.checkpointDescriptionInput.Text = "";
            // 
            // checkpointNameInput
            // 
            this.checkpointNameInput.Location = new System.Drawing.Point(12, 64);
            this.checkpointNameInput.MaxLength = 100;
            this.checkpointNameInput.Name = "checkpointNameInput";
            this.checkpointNameInput.Size = new System.Drawing.Size(282, 20);
            this.checkpointNameInput.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Name";
            // 
            // buttonAddDegreeOfEvidence
            // 
            this.buttonAddDegreeOfEvidence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddDegreeOfEvidence.Location = new System.Drawing.Point(12, 12);
            this.buttonAddDegreeOfEvidence.Name = "buttonAddDegreeOfEvidence";
            this.buttonAddDegreeOfEvidence.Size = new System.Drawing.Size(181, 21);
            this.buttonAddDegreeOfEvidence.TabIndex = 37;
            this.buttonAddDegreeOfEvidence.Text = "Degrees of evidence";
            this.buttonAddDegreeOfEvidence.UseVisualStyleBackColor = true;
            this.buttonAddDegreeOfEvidence.Click += new System.EventHandler(this.buttonAddDegreeOfEvidence_Click);
            // 
            // PopupWindowForEditCheckpoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 276);
            this.Controls.Add(this.buttonAddDegreeOfEvidence);
            this.Controls.Add(this.checkpointOrderInput);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkpointDescriptionInput);
            this.Controls.Add(this.checkpointNameInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PopupWindowForEditCheckpoint";
            this.Text = "PopupWindowForEditCheckpoint";
            ((System.ComponentModel.ISupportInitialize)(this.checkpointOrderInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown checkpointOrderInput;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox checkpointDescriptionInput;
        private System.Windows.Forms.TextBox checkpointNameInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddDegreeOfEvidence;
    }
}