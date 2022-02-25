namespace Alpha
{
    partial class PopupWindowForEditState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupWindowForEditState));
            this.stateDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.stateNameInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.stateOrderInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.stateOrderInput)).BeginInit();
            this.SuspendLayout();
            // 
            // stateDescriptionInput
            // 
            this.stateDescriptionInput.Location = new System.Drawing.Point(21, 72);
            this.stateDescriptionInput.MaxLength = 255;
            this.stateDescriptionInput.Name = "stateDescriptionInput";
            this.stateDescriptionInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.stateDescriptionInput.Size = new System.Drawing.Size(282, 96);
            this.stateDescriptionInput.TabIndex = 15;
            this.stateDescriptionInput.Text = "";
            // 
            // stateNameInput
            // 
            this.stateNameInput.Location = new System.Drawing.Point(21, 33);
            this.stateNameInput.MaxLength = 100;
            this.stateNameInput.Name = "stateNameInput";
            this.stateNameInput.Size = new System.Drawing.Size(282, 20);
            this.stateNameInput.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Order";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(21, 213);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 19;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(102, 213);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 18;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // stateOrderInput
            // 
            this.stateOrderInput.Location = new System.Drawing.Point(21, 187);
            this.stateOrderInput.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.stateOrderInput.Name = "stateOrderInput";
            this.stateOrderInput.Size = new System.Drawing.Size(282, 20);
            this.stateOrderInput.TabIndex = 20;
            // 
            // PopupWindowForEditState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 253);
            this.Controls.Add(this.stateOrderInput);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stateDescriptionInput);
            this.Controls.Add(this.stateNameInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PopupWindowForEditState";
            this.Text = "PopupWindowForEditState";
            ((System.ComponentModel.ISupportInitialize)(this.stateOrderInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox stateDescriptionInput;
        private System.Windows.Forms.TextBox stateNameInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.NumericUpDown stateOrderInput;
    }
}