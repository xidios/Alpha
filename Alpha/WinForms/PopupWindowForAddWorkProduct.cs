﻿using Alpha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alpha.WinForms
{
    public partial class PopupWindowForAddWorkProduct : Form
    {
        WorkProductsTable workProductsTable;

        public PopupWindowForAddWorkProduct(WorkProductsTable workProductsTable)
        {
            InitializeComponent();
            this.workProductsTable = workProductsTable;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string workProductName = workProductNameInput.Text;
            if (workProductName == null || workProductName == "")
            {
                MessageBox.Show("Please enter work product's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string workProductDescription = workProductDescriptionInput.Text;
            if (workProductDescription == null || workProductDescription == "")
            {
                MessageBox.Show("Please enter work product's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var wp in workProductsTable.GetWorkProducts())
            {
                if (wp.GetWorkProductName() == workProductName)
                {
                    MessageBox.Show("Work product with same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            WorkProduct workProduct = new WorkProduct(workProductName, workProductDescription);
            workProductsTable.AddWorkProduct(workProduct);
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
