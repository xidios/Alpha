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
            this.stateDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.stateNameInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.stateOrderInput = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.partialTextBox = new System.Windows.Forms.TextBox();
            this.minimalTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxOfActivities = new System.Windows.Forms.ListBox();
            this.buttonDeleteCriterion = new System.Windows.Forms.Button();
            this.labelAlphaCriterion = new System.Windows.Forms.Label();
            this.buttonSaveCriterion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stateOrderInput)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.buttonClose.Location = new System.Drawing.Point(566, 4);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.typeTextBox);
            this.panel1.Controls.Add(this.partialTextBox);
            this.panel1.Controls.Add(this.minimalTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.listBoxOfActivities);
            this.panel1.Controls.Add(this.buttonDeleteCriterion);
            this.panel1.Controls.Add(this.labelAlphaCriterion);
            this.panel1.Controls.Add(this.buttonSaveCriterion);
            this.panel1.Location = new System.Drawing.Point(353, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 288);
            this.panel1.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Partial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Minimal";
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(6, 53);
            this.typeTextBox.MaxLength = 100;
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(275, 20);
            this.typeTextBox.TabIndex = 32;
            // 
            // partialTextBox
            // 
            this.partialTextBox.Location = new System.Drawing.Point(5, 92);
            this.partialTextBox.MaxLength = 100;
            this.partialTextBox.Name = "partialTextBox";
            this.partialTextBox.Size = new System.Drawing.Size(276, 20);
            this.partialTextBox.TabIndex = 31;
            // 
            // minimalTextBox
            // 
            this.minimalTextBox.Location = new System.Drawing.Point(6, 131);
            this.minimalTextBox.MaxLength = 100;
            this.minimalTextBox.Name = "minimalTextBox";
            this.minimalTextBox.Size = new System.Drawing.Size(275, 20);
            this.minimalTextBox.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Activities";
            // 
            // listBoxOfActivities
            // 
            this.listBoxOfActivities.FormattingEnabled = true;
            this.listBoxOfActivities.Location = new System.Drawing.Point(5, 174);
            this.listBoxOfActivities.Name = "listBoxOfActivities";
            this.listBoxOfActivities.ScrollAlwaysVisible = true;
            this.listBoxOfActivities.Size = new System.Drawing.Size(276, 82);
            this.listBoxOfActivities.TabIndex = 24;
            // 
            // buttonDeleteCriterion
            // 
            this.buttonDeleteCriterion.Location = new System.Drawing.Point(206, 262);
            this.buttonDeleteCriterion.Name = "buttonDeleteCriterion";
            this.buttonDeleteCriterion.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteCriterion.TabIndex = 26;
            this.buttonDeleteCriterion.Text = "Delete";
            this.buttonDeleteCriterion.UseVisualStyleBackColor = true;
            this.buttonDeleteCriterion.Click += new System.EventHandler(this.buttonDeleteCriterion_Click);
            // 
            // labelAlphaCriterion
            // 
            this.labelAlphaCriterion.AutoSize = true;
            this.labelAlphaCriterion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAlphaCriterion.Location = new System.Drawing.Point(3, 9);
            this.labelAlphaCriterion.Name = "labelAlphaCriterion";
            this.labelAlphaCriterion.Size = new System.Drawing.Size(89, 13);
            this.labelAlphaCriterion.TabIndex = 18;
            this.labelAlphaCriterion.Text = "Alpha criterion";
            // 
            // buttonSaveCriterion
            // 
            this.buttonSaveCriterion.Location = new System.Drawing.Point(5, 262);
            this.buttonSaveCriterion.Name = "buttonSaveCriterion";
            this.buttonSaveCriterion.Size = new System.Drawing.Size(115, 23);
            this.buttonSaveCriterion.TabIndex = 25;
            this.buttonSaveCriterion.Text = "Save Criterion";
            this.buttonSaveCriterion.UseVisualStyleBackColor = true;
            this.buttonSaveCriterion.Click += new System.EventHandler(this.buttonSaveCriterion_Click);
            // 
            // PopupWindowForEditState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 343);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.stateOrderInput);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stateDescriptionInput);
            this.Controls.Add(this.stateNameInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PopupWindowForEditState";
            this.Text = "PopupWindowForEditState";
            ((System.ComponentModel.ISupportInitialize)(this.stateOrderInput)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.TextBox partialTextBox;
        private System.Windows.Forms.TextBox minimalTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxOfActivities;
        private System.Windows.Forms.Button buttonDeleteCriterion;
        private System.Windows.Forms.Label labelAlphaCriterion;
        private System.Windows.Forms.Button buttonSaveCriterion;
    }
}