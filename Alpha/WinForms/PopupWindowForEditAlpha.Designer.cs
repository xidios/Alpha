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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupWindowForEditAlpha));
            this.label1 = new System.Windows.Forms.Label();
            this.labelAlphaName = new System.Windows.Forms.Label();
            this.alphaDescriptionInput = new System.Windows.Forms.RichTextBox();
            this.alphaNameInput = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkBoxChildAlpha = new System.Windows.Forms.CheckBox();
            this.labelAlphaParent = new System.Windows.Forms.Label();
            this.listBoxAlphas = new System.Windows.Forms.ListBox();
            this.tableLayoutPanelOfStates = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddState = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.upperBoundOfAlphaCotainmentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lowerBoundOfAlphaCotainmentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelSubAlpha = new System.Windows.Forms.Label();
            this.listBoxOfSubAlphas = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDeleteAlphaContainment = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBoxOfWorkProducts = new System.Windows.Forms.ListBox();
            this.buttonDeleteWorkProductManifest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSaveWorkProductManifest = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelWorkProductManifest = new System.Windows.Forms.Label();
            this.upperBoundOfWorkProductManifestUpDown = new System.Windows.Forms.NumericUpDown();
            this.lowerBoundOfWorkProductManifestUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.upperBoundOfAlphaCotainmentNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerBoundOfAlphaCotainmentNumericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upperBoundOfWorkProductManifestUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerBoundOfWorkProductManifestUpDown)).BeginInit();
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
            this.buttonAdd.Location = new System.Drawing.Point(12, 316);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 7;
            this.buttonAdd.Text = "Edit";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(103, 316);
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
            this.checkBoxChildAlpha.Location = new System.Drawing.Point(15, 197);
            this.checkBoxChildAlpha.Name = "checkBoxChildAlpha";
            this.checkBoxChildAlpha.Size = new System.Drawing.Size(121, 17);
            this.checkBoxChildAlpha.TabIndex = 14;
            this.checkBoxChildAlpha.Text = "Is the alpha a child?";
            this.checkBoxChildAlpha.UseVisualStyleBackColor = true;
            this.checkBoxChildAlpha.CheckedChanged += new System.EventHandler(this.checkBoxChildAlpha_CheckedChanged);
            // 
            // labelAlphaParent
            // 
            this.labelAlphaParent.AutoSize = true;
            this.labelAlphaParent.Location = new System.Drawing.Point(12, 181);
            this.labelAlphaParent.Name = "labelAlphaParent";
            this.labelAlphaParent.Size = new System.Drawing.Size(67, 13);
            this.labelAlphaParent.TabIndex = 13;
            this.labelAlphaParent.Text = "Alpha parent";
            // 
            // listBoxAlphas
            // 
            this.listBoxAlphas.Enabled = false;
            this.listBoxAlphas.FormattingEnabled = true;
            this.listBoxAlphas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listBoxAlphas.Location = new System.Drawing.Point(12, 215);
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
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Alpha containment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Lower bound";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Upper bound";
            // 
            // upperBoundOfAlphaCotainmentNumericUpDown
            // 
            this.upperBoundOfAlphaCotainmentNumericUpDown.DecimalPlaces = 2;
            this.upperBoundOfAlphaCotainmentNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperBoundOfAlphaCotainmentNumericUpDown.Location = new System.Drawing.Point(4, 62);
            this.upperBoundOfAlphaCotainmentNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.upperBoundOfAlphaCotainmentNumericUpDown.Name = "upperBoundOfAlphaCotainmentNumericUpDown";
            this.upperBoundOfAlphaCotainmentNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.upperBoundOfAlphaCotainmentNumericUpDown.TabIndex = 21;
            // 
            // lowerBoundOfAlphaCotainmentNumericUpDown
            // 
            this.lowerBoundOfAlphaCotainmentNumericUpDown.DecimalPlaces = 2;
            this.lowerBoundOfAlphaCotainmentNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerBoundOfAlphaCotainmentNumericUpDown.Location = new System.Drawing.Point(4, 101);
            this.lowerBoundOfAlphaCotainmentNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.lowerBoundOfAlphaCotainmentNumericUpDown.Name = "lowerBoundOfAlphaCotainmentNumericUpDown";
            this.lowerBoundOfAlphaCotainmentNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.lowerBoundOfAlphaCotainmentNumericUpDown.TabIndex = 22;
            // 
            // labelSubAlpha
            // 
            this.labelSubAlpha.AutoSize = true;
            this.labelSubAlpha.Location = new System.Drawing.Point(2, 124);
            this.labelSubAlpha.Name = "labelSubAlpha";
            this.labelSubAlpha.Size = new System.Drawing.Size(94, 13);
            this.labelSubAlpha.TabIndex = 23;
            this.labelSubAlpha.Text = "Subordinate Alpha";
            // 
            // listBoxOfSubAlphas
            // 
            this.listBoxOfSubAlphas.FormattingEnabled = true;
            this.listBoxOfSubAlphas.Location = new System.Drawing.Point(5, 141);
            this.listBoxOfSubAlphas.Name = "listBoxOfSubAlphas";
            this.listBoxOfSubAlphas.ScrollAlwaysVisible = true;
            this.listBoxOfSubAlphas.Size = new System.Drawing.Size(276, 69);
            this.listBoxOfSubAlphas.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Save Alpha Containment";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSaveConteinment_Click);
            // 
            // buttonDeleteAlphaContainment
            // 
            this.buttonDeleteAlphaContainment.Location = new System.Drawing.Point(206, 216);
            this.buttonDeleteAlphaContainment.Name = "buttonDeleteAlphaContainment";
            this.buttonDeleteAlphaContainment.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteAlphaContainment.TabIndex = 26;
            this.buttonDeleteAlphaContainment.Text = "Delete";
            this.buttonDeleteAlphaContainment.UseVisualStyleBackColor = true;
            this.buttonDeleteAlphaContainment.Click += new System.EventHandler(this.buttonDeleteAlphaContainment_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.listBoxOfSubAlphas);
            this.panel1.Controls.Add(this.buttonDeleteAlphaContainment);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.labelSubAlpha);
            this.panel1.Controls.Add(this.upperBoundOfAlphaCotainmentNumericUpDown);
            this.panel1.Controls.Add(this.lowerBoundOfAlphaCotainmentNumericUpDown);
            this.panel1.Location = new System.Drawing.Point(12, 345);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 247);
            this.panel1.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.listBoxOfWorkProducts);
            this.panel2.Controls.Add(this.buttonDeleteWorkProductManifest);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonSaveWorkProductManifest);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.labelWorkProductManifest);
            this.panel2.Controls.Add(this.upperBoundOfWorkProductManifestUpDown);
            this.panel2.Controls.Add(this.lowerBoundOfWorkProductManifestUpDown);
            this.panel2.Location = new System.Drawing.Point(376, 345);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 247);
            this.panel2.TabIndex = 28;
            // 
            // listBoxOfWorkProducts
            // 
            this.listBoxOfWorkProducts.FormattingEnabled = true;
            this.listBoxOfWorkProducts.Location = new System.Drawing.Point(5, 141);
            this.listBoxOfWorkProducts.Name = "listBoxOfWorkProducts";
            this.listBoxOfWorkProducts.ScrollAlwaysVisible = true;
            this.listBoxOfWorkProducts.Size = new System.Drawing.Size(276, 69);
            this.listBoxOfWorkProducts.TabIndex = 24;
            // 
            // buttonDeleteWorkProductManifest
            // 
            this.buttonDeleteWorkProductManifest.Location = new System.Drawing.Point(206, 216);
            this.buttonDeleteWorkProductManifest.Name = "buttonDeleteWorkProductManifest";
            this.buttonDeleteWorkProductManifest.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteWorkProductManifest.TabIndex = 26;
            this.buttonDeleteWorkProductManifest.Text = "Delete";
            this.buttonDeleteWorkProductManifest.UseVisualStyleBackColor = true;
            this.buttonDeleteWorkProductManifest.Click += new System.EventHandler(this.buttonDeleteWorkProductManifest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Work Product Manifest";
            // 
            // buttonSaveWorkProductManifest
            // 
            this.buttonSaveWorkProductManifest.Location = new System.Drawing.Point(5, 216);
            this.buttonSaveWorkProductManifest.Name = "buttonSaveWorkProductManifest";
            this.buttonSaveWorkProductManifest.Size = new System.Drawing.Size(158, 23);
            this.buttonSaveWorkProductManifest.TabIndex = 25;
            this.buttonSaveWorkProductManifest.Text = "Save Work Product Manifest";
            this.buttonSaveWorkProductManifest.UseVisualStyleBackColor = true;
            this.buttonSaveWorkProductManifest.Click += new System.EventHandler(this.buttonSaveWorkProductManifest_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Lower bound";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Upper bound";
            // 
            // labelWorkProductManifest
            // 
            this.labelWorkProductManifest.AutoSize = true;
            this.labelWorkProductManifest.Location = new System.Drawing.Point(2, 124);
            this.labelWorkProductManifest.Name = "labelWorkProductManifest";
            this.labelWorkProductManifest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelWorkProductManifest.Size = new System.Drawing.Size(73, 13);
            this.labelWorkProductManifest.TabIndex = 23;
            this.labelWorkProductManifest.Text = "Work Product";
            // 
            // upperBoundOfWorkProductManifestUpDown
            // 
            this.upperBoundOfWorkProductManifestUpDown.DecimalPlaces = 2;
            this.upperBoundOfWorkProductManifestUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperBoundOfWorkProductManifestUpDown.Location = new System.Drawing.Point(4, 62);
            this.upperBoundOfWorkProductManifestUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.upperBoundOfWorkProductManifestUpDown.Name = "upperBoundOfWorkProductManifestUpDown";
            this.upperBoundOfWorkProductManifestUpDown.Size = new System.Drawing.Size(120, 20);
            this.upperBoundOfWorkProductManifestUpDown.TabIndex = 21;
            // 
            // lowerBoundOfWorkProductManifestUpDown
            // 
            this.lowerBoundOfWorkProductManifestUpDown.DecimalPlaces = 2;
            this.lowerBoundOfWorkProductManifestUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerBoundOfWorkProductManifestUpDown.Location = new System.Drawing.Point(4, 101);
            this.lowerBoundOfWorkProductManifestUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.lowerBoundOfWorkProductManifestUpDown.Name = "lowerBoundOfWorkProductManifestUpDown";
            this.lowerBoundOfWorkProductManifestUpDown.Size = new System.Drawing.Size(120, 20);
            this.lowerBoundOfWorkProductManifestUpDown.TabIndex = 22;
            // 
            // PopupWindowForEditAlpha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 599);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonAddState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanelOfStates);
            this.Controls.Add(this.checkBoxChildAlpha);
            this.Controls.Add(this.labelAlphaParent);
            this.Controls.Add(this.listBoxAlphas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAlphaName);
            this.Controls.Add(this.alphaDescriptionInput);
            this.Controls.Add(this.alphaNameInput);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PopupWindowForEditAlpha";
            this.Text = "PopupWindowForEditAlpha";
            ((System.ComponentModel.ISupportInitialize)(this.upperBoundOfAlphaCotainmentNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerBoundOfAlphaCotainmentNumericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upperBoundOfWorkProductManifestUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerBoundOfWorkProductManifestUpDown)).EndInit();
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
        private System.Windows.Forms.Label labelAlphaParent;
        private System.Windows.Forms.ListBox listBoxAlphas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOfStates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown upperBoundOfAlphaCotainmentNumericUpDown;
        private System.Windows.Forms.NumericUpDown lowerBoundOfAlphaCotainmentNumericUpDown;
        private System.Windows.Forms.Label labelSubAlpha;
        private System.Windows.Forms.ListBox listBoxOfSubAlphas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDeleteAlphaContainment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBoxOfWorkProducts;
        private System.Windows.Forms.Button buttonDeleteWorkProductManifest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSaveWorkProductManifest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelWorkProductManifest;
        private System.Windows.Forms.NumericUpDown upperBoundOfWorkProductManifestUpDown;
        private System.Windows.Forms.NumericUpDown lowerBoundOfWorkProductManifestUpDown;
    }
}