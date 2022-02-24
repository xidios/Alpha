﻿namespace Alpha.WinForms
{
    partial class PopupWindowForAddActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupWindowForAddActivity));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAlphaName = new System.Windows.Forms.Label();
            this.activityDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.activityNameInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(116, 164);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 17;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(197, 164);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 16;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Activity description";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAlphaName
            // 
            this.labelAlphaName.AutoSize = true;
            this.labelAlphaName.Location = new System.Drawing.Point(40, 24);
            this.labelAlphaName.Name = "labelAlphaName";
            this.labelAlphaName.Size = new System.Drawing.Size(70, 13);
            this.labelAlphaName.TabIndex = 14;
            this.labelAlphaName.Text = "Activity name";
            // 
            // activityDescriptionInput
            // 
            this.activityDescriptionInput.Location = new System.Drawing.Point(116, 47);
            this.activityDescriptionInput.MaxLength = 255;
            this.activityDescriptionInput.Name = "activityDescriptionInput";
            this.activityDescriptionInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.activityDescriptionInput.Size = new System.Drawing.Size(282, 96);
            this.activityDescriptionInput.TabIndex = 13;
            this.activityDescriptionInput.Text = "";
            // 
            // activityNameInput
            // 
            this.activityNameInput.Location = new System.Drawing.Point(116, 21);
            this.activityNameInput.MaxLength = 100;
            this.activityNameInput.Name = "activityNameInput";
            this.activityNameInput.Size = new System.Drawing.Size(282, 20);
            this.activityNameInput.TabIndex = 12;
            // 
            // PopupWindowForAddActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 205);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAlphaName);
            this.Controls.Add(this.activityDescriptionInput);
            this.Controls.Add(this.activityNameInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PopupWindowForAddActivity";
            this.Text = "PopupWindowForAddActivity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAlphaName;
        private System.Windows.Forms.RichTextBox activityDescriptionInput;
        private System.Windows.Forms.TextBox activityNameInput;
    }
}