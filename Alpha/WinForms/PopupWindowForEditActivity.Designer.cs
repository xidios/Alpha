﻿namespace Alpha.WinForms
{
    partial class PopupWindowForEditActivity
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
            this.buttonEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAlphaName = new System.Windows.Forms.Label();
            this.activityDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.activityNameInput = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(120, 166);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 22;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Activity description";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAlphaName
            // 
            this.labelAlphaName.AutoSize = true;
            this.labelAlphaName.Location = new System.Drawing.Point(44, 25);
            this.labelAlphaName.Name = "labelAlphaName";
            this.labelAlphaName.Size = new System.Drawing.Size(70, 13);
            this.labelAlphaName.TabIndex = 20;
            this.labelAlphaName.Text = "Activity name";
            // 
            // activityDescriptionInput
            // 
            this.activityDescriptionInput.Location = new System.Drawing.Point(120, 64);
            this.activityDescriptionInput.MaxLength = 255;
            this.activityDescriptionInput.Name = "activityDescriptionInput";
            this.activityDescriptionInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.activityDescriptionInput.Size = new System.Drawing.Size(282, 96);
            this.activityDescriptionInput.TabIndex = 19;
            this.activityDescriptionInput.Text = "";
            // 
            // activityNameInput
            // 
            this.activityNameInput.Location = new System.Drawing.Point(120, 22);
            this.activityNameInput.MaxLength = 100;
            this.activityNameInput.Name = "activityNameInput";
            this.activityNameInput.Size = new System.Drawing.Size(282, 20);
            this.activityNameInput.TabIndex = 18;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(713, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 23;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // PopupWindowForEditActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAlphaName);
            this.Controls.Add(this.activityDescriptionInput);
            this.Controls.Add(this.activityNameInput);
            this.Name = "PopupWindowForEditActivity";
            this.Text = "PopupWindowForEditActivity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAlphaName;
        private System.Windows.Forms.RichTextBox activityDescriptionInput;
        private System.Windows.Forms.TextBox activityNameInput;
        private System.Windows.Forms.Button buttonClose;
    }
}