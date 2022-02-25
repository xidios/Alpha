﻿namespace Alpha.WinForms
{
    partial class PopupWindowForEditLevelOfDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupWindowForEditLevelOfDetail));
            this.levelOfDetailOrderInput = new System.Windows.Forms.NumericUpDown();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.levelOfDetailDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.levelOfDetailNameInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.levelOfDetailOrderInput)).BeginInit();
            this.SuspendLayout();
            // 
            // levelOfDetailOrderInput
            // 
            this.levelOfDetailOrderInput.Location = new System.Drawing.Point(12, 187);
            this.levelOfDetailOrderInput.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.levelOfDetailOrderInput.Name = "levelOfDetailOrderInput";
            this.levelOfDetailOrderInput.Size = new System.Drawing.Size(282, 20);
            this.levelOfDetailOrderInput.TabIndex = 28;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(12, 213);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 27;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(103, 213);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 26;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Order";
            // 
            // levelOfDetailDescriptionInput
            // 
            this.levelOfDetailDescriptionInput.Location = new System.Drawing.Point(12, 72);
            this.levelOfDetailDescriptionInput.MaxLength = 255;
            this.levelOfDetailDescriptionInput.Name = "levelOfDetailDescriptionInput";
            this.levelOfDetailDescriptionInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.levelOfDetailDescriptionInput.Size = new System.Drawing.Size(282, 96);
            this.levelOfDetailDescriptionInput.TabIndex = 24;
            this.levelOfDetailDescriptionInput.Text = "";
            // 
            // levelOfDetailNameInput
            // 
            this.levelOfDetailNameInput.Location = new System.Drawing.Point(12, 33);
            this.levelOfDetailNameInput.MaxLength = 100;
            this.levelOfDetailNameInput.Name = "levelOfDetailNameInput";
            this.levelOfDetailNameInput.Size = new System.Drawing.Size(282, 20);
            this.levelOfDetailNameInput.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Name";
            // 
            // PopupWindowForEditLevelOfDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 248);
            this.Controls.Add(this.levelOfDetailOrderInput);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.levelOfDetailDescriptionInput);
            this.Controls.Add(this.levelOfDetailNameInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PopupWindowForEditLevelOfDetail";
            this.Text = "PopupWindowForEditLevelOfDetail";
            ((System.ComponentModel.ISupportInitialize)(this.levelOfDetailOrderInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown levelOfDetailOrderInput;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox levelOfDetailDescriptionInput;
        private System.Windows.Forms.TextBox levelOfDetailNameInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}