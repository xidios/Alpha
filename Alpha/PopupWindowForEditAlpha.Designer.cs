namespace Alpha
{
    partial class PopupWindowForEditAlpha
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelAlphaName = new System.Windows.Forms.Label();
            this.AlphaDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.AlphaNameInput = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkBoxChildAlpha = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxAlphas = new System.Windows.Forms.ListBox();
            this.tableLayoutPanelOfStates = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddState = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Alpha description";
            // 
            // labelAlphaName
            // 
            this.labelAlphaName.AutoSize = true;
            this.labelAlphaName.Location = new System.Drawing.Point(12, 16);
            this.labelAlphaName.Name = "labelAlphaName";
            this.labelAlphaName.Size = new System.Drawing.Size(63, 13);
            this.labelAlphaName.TabIndex = 10;
            this.labelAlphaName.Text = "Alpha name";
            // 
            // AlphaDescriptionInput
            // 
            this.AlphaDescriptionInput.Location = new System.Drawing.Point(12, 71);
            this.AlphaDescriptionInput.MaxLength = 255;
            this.AlphaDescriptionInput.Name = "AlphaDescriptionInput";
            this.AlphaDescriptionInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.AlphaDescriptionInput.Size = new System.Drawing.Size(282, 96);
            this.AlphaDescriptionInput.TabIndex = 9;
            this.AlphaDescriptionInput.Text = "";
            // 
            // AlphaNameInput
            // 
            this.AlphaNameInput.Location = new System.Drawing.Point(12, 32);
            this.AlphaNameInput.MaxLength = 100;
            this.AlphaNameInput.Name = "AlphaNameInput";
            this.AlphaNameInput.Size = new System.Drawing.Size(282, 20);
            this.AlphaNameInput.TabIndex = 8;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(17, 316);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Edit";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(108, 316);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // checkBoxChildAlpha
            // 
            this.checkBoxChildAlpha.AutoSize = true;
            this.checkBoxChildAlpha.Location = new System.Drawing.Point(98, 192);
            this.checkBoxChildAlpha.Name = "checkBoxChildAlpha";
            this.checkBoxChildAlpha.Size = new System.Drawing.Size(121, 17);
            this.checkBoxChildAlpha.TabIndex = 14;
            this.checkBoxChildAlpha.Text = "Is the alpha a child?";
            this.checkBoxChildAlpha.UseVisualStyleBackColor = true;
            this.checkBoxChildAlpha.CheckedChanged += new System.EventHandler(this.checkBoxChildAlpha_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Alpha parent";
            // 
            // listBoxAlphas
            // 
            this.listBoxAlphas.Enabled = false;
            this.listBoxAlphas.FormattingEnabled = true;
            this.listBoxAlphas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listBoxAlphas.Location = new System.Drawing.Point(15, 215);
            this.listBoxAlphas.Name = "listBoxAlphas";
            this.listBoxAlphas.Size = new System.Drawing.Size(282, 95);
            this.listBoxAlphas.TabIndex = 12;
            // 
            // tableLayoutPanelOfStates
            // 
            this.tableLayoutPanelOfStates.AutoScroll = true;
            this.tableLayoutPanelOfStates.ColumnCount = 3;
            this.tableLayoutPanelOfStates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOfStates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOfStates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOfStates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelOfStates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelOfStates.Location = new System.Drawing.Point(449, 44);
            this.tableLayoutPanelOfStates.Name = "tableLayoutPanelOfStates";
            this.tableLayoutPanelOfStates.RowCount = 2;
            this.tableLayoutPanelOfStates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelOfStates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelOfStates.Size = new System.Drawing.Size(441, 266);
            this.tableLayoutPanelOfStates.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "States";
            // 
            // buttonAddState
            // 
            this.buttonAddState.Location = new System.Drawing.Point(489, 12);
            this.buttonAddState.Name = "buttonAddState";
            this.buttonAddState.Size = new System.Drawing.Size(40, 23);
            this.buttonAddState.TabIndex = 17;
            this.buttonAddState.Text = "Add";
            this.buttonAddState.UseVisualStyleBackColor = true;
            this.buttonAddState.Click += new System.EventHandler(this.buttonAddState_Click);
            // 
            // PopupWindowForEditAlpha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 347);
            this.Controls.Add(this.buttonAddState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanelOfStates);
            this.Controls.Add(this.checkBoxChildAlpha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxAlphas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAlphaName);
            this.Controls.Add(this.AlphaDescriptionInput);
            this.Controls.Add(this.AlphaNameInput);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonClose);
            this.Name = "PopupWindowForEditAlpha";
            this.Text = "PopupWindowForEditAlpha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAlphaName;
        private System.Windows.Forms.RichTextBox AlphaDescriptionInput;
        private System.Windows.Forms.TextBox AlphaNameInput;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.CheckBox checkBoxChildAlpha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxAlphas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOfStates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddState;
    }
}