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
            this.alphaDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.alphaNameInput = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkBoxChildAlpha = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxAlphas = new System.Windows.Forms.ListBox();
            this.tableLayoutPanelOfStates = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddState = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.upperBoundNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lowerBoundNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxOfSubAlphas = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.upperBoundNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerBoundNumericUpDown)).BeginInit();
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
            // alphaDescriptionInput
            // 
            this.alphaDescriptionInput.Location = new System.Drawing.Point(12, 71);
            this.alphaDescriptionInput.MaxLength = 255;
            this.alphaDescriptionInput.Name = "alphaDescriptionInput";
            this.alphaDescriptionInput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.alphaDescriptionInput.Size = new System.Drawing.Size(282, 96);
            this.alphaDescriptionInput.TabIndex = 9;
            this.alphaDescriptionInput.Text = "";
            // 
            // alphaNameInput
            // 
            this.alphaNameInput.Location = new System.Drawing.Point(12, 32);
            this.alphaNameInput.MaxLength = 100;
            this.alphaNameInput.Name = "alphaNameInput";
            this.alphaNameInput.Size = new System.Drawing.Size(282, 20);
            this.alphaNameInput.TabIndex = 8;
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
            this.checkBoxChildAlpha.Location = new System.Drawing.Point(96, 180);
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
            this.label2.Location = new System.Drawing.Point(12, 181);
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
            this.listBoxAlphas.Location = new System.Drawing.Point(12, 203);
            this.listBoxAlphas.Name = "listBoxAlphas";
            this.listBoxAlphas.Size = new System.Drawing.Size(282, 95);
            this.listBoxAlphas.TabIndex = 12;
            // 
            // tableLayoutPanelOfStates
            // 
            this.tableLayoutPanelOfStates.AutoScroll = true;
            this.tableLayoutPanelOfStates.ColumnCount = 6;
            this.tableLayoutPanelOfStates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOfStates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOfStates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOfStates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOfStates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOfStates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOfStates.Location = new System.Drawing.Point(376, 44);
            this.tableLayoutPanelOfStates.Name = "tableLayoutPanelOfStates";
            this.tableLayoutPanelOfStates.RowCount = 2;
            this.tableLayoutPanelOfStates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelOfStates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelOfStates.Size = new System.Drawing.Size(612, 266);
            this.tableLayoutPanelOfStates.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "States";
            // 
            // buttonAddState
            // 
            this.buttonAddState.Location = new System.Drawing.Point(416, 11);
            this.buttonAddState.Name = "buttonAddState";
            this.buttonAddState.Size = new System.Drawing.Size(41, 23);
            this.buttonAddState.TabIndex = 17;
            this.buttonAddState.Text = "Add";
            this.buttonAddState.UseVisualStyleBackColor = true;
            this.buttonAddState.Click += new System.EventHandler(this.buttonAddState_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Alpha containment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 424);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Lower bound";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 385);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Upper bound";
            // 
            // upperBoundNumericUpDown
            // 
            this.upperBoundNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperBoundNumericUpDown.Location = new System.Drawing.Point(17, 401);
            this.upperBoundNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.upperBoundNumericUpDown.Name = "upperBoundNumericUpDown";
            this.upperBoundNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.upperBoundNumericUpDown.TabIndex = 21;
            // 
            // lowerBoundNumericUpDown
            // 
            this.lowerBoundNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerBoundNumericUpDown.Location = new System.Drawing.Point(17, 440);
            this.lowerBoundNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.lowerBoundNumericUpDown.Name = "lowerBoundNumericUpDown";
            this.lowerBoundNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.lowerBoundNumericUpDown.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Subordinate Alpha";
            // 
            // listBoxOfSubAlphas
            // 
            this.listBoxOfSubAlphas.FormattingEnabled = true;
            this.listBoxOfSubAlphas.Location = new System.Drawing.Point(18, 480);
            this.listBoxOfSubAlphas.Name = "listBoxOfSubAlphas";
            this.listBoxOfSubAlphas.ScrollAlwaysVisible = true;
            this.listBoxOfSubAlphas.Size = new System.Drawing.Size(276, 30);
            this.listBoxOfSubAlphas.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Save Alpha Containment";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PopupWindowForEditAlpha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 602);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxOfSubAlphas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lowerBoundNumericUpDown);
            this.Controls.Add(this.upperBoundNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAddState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanelOfStates);
            this.Controls.Add(this.checkBoxChildAlpha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxAlphas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAlphaName);
            this.Controls.Add(this.alphaDescriptionInput);
            this.Controls.Add(this.alphaNameInput);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonClose);
            this.Name = "PopupWindowForEditAlpha";
            this.Text = "PopupWindowForEditAlpha";
            ((System.ComponentModel.ISupportInitialize)(this.upperBoundNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerBoundNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAlphaName;
        private System.Windows.Forms.RichTextBox alphaDescriptionInput;
        private System.Windows.Forms.TextBox alphaNameInput;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.CheckBox checkBoxChildAlpha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxAlphas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOfStates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown upperBoundNumericUpDown;
        private System.Windows.Forms.NumericUpDown lowerBoundNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBoxOfSubAlphas;
        private System.Windows.Forms.Button button1;
    }
}