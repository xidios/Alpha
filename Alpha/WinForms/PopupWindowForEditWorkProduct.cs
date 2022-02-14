using Alpha.Models;
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
    public partial class PopupWindowForEditWorkProduct : Form
    {
        WorkProductsTable workProductsTable;
        WorkProduct workProduct;
        string oldWorkProductName;
        public PopupWindowForEditWorkProduct(WorkProductsTable workProductsTable, WorkProduct workProduct)
        {
            InitializeComponent();
            this.workProductsTable = workProductsTable;
            this.workProduct = workProduct;
            oldWorkProductName = workProduct.GetWorkProductName();
            workProductNameInput.Text = oldWorkProductName;
            workProductDescriptionInput.Text = workProduct.GetWorkProductDescription();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string workProductName = workProductNameInput.Text;
            if (workProductName == null || workProductName == "")
            {
                MessageBox.Show("Please enter work product's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (oldWorkProductName != workProductName) 
            {
                foreach (var wp in workProductsTable.GetWorkProducts())
                {

                    if (wp.GetWorkProductName() == workProductName)
                    {
                        MessageBox.Show("Work product with same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            string workProductDescription = workProductDescriptionInput.Text;
            if (workProductDescription == null || workProductDescription == "")
            {
                MessageBox.Show("Please enter work product's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            workProduct.SetName(workProductName);
            workProduct.SetDescription(workProductDescription);
            workProductsTable.ExportAllToJsonAndUpdateTable();
            this.Close();
        }
    }
}
