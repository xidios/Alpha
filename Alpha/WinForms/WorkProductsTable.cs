using Alpha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alpha.WinForms
{
    public partial class WorkProductsTable : Form
    {
        private List<WorkProduct> workProducts = new List<WorkProduct>();
        private string pathToWorkProductsFile = "workProducts.json";
        public WorkProductsTable()
        {
            InitializeComponent();
            UpdateWorkProductsTable();
        }
        public void UpdateWorkProductsTable()
        {
            DeserializeJsonFiles();
            tableLayoutPanelWP.Controls.Clear();

            tableLayoutPanelWP.RowCount = workProducts.Count() + 1;
            tableLayoutPanelWP.Controls.Add(new Label
            {
                Text = "Work Product",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 0, 0);
            tableLayoutPanelWP.Controls.Add(new Label
            {
                Text = "More",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 1, 0);
            tableLayoutPanelWP.Controls.Add(new Label
            {
                Text = "Delete",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 2, 0);



            for (int i = 1; i <= workProducts.Count; i++)
            {
                tableLayoutPanelWP.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30F));
                WorkProduct workProduct = workProducts[i - 1];
                Guid workProductId = workProduct.GetWorkProductId();

                Button editButton = new Button();
                editButton.Text = "Edit";
                editButton.AccessibleName = workProductId.ToString();
                editButton.Click += new EventHandler(buttonEdit_Click);

                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.AccessibleName = workProductId.ToString();
                deleteButton.Click += new EventHandler(buttonDelete_Click);

                Label workProductNameLabel = new Label();
                workProductNameLabel.Text = workProduct.Name;

                tableLayoutPanelWP.Controls.Add(workProductNameLabel, 0, i);
                tableLayoutPanelWP.Controls.Add(editButton, 1, i);
                tableLayoutPanelWP.Controls.Add(deleteButton, 2, i);
            }
        }
        
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Guid workProductId = Guid.Parse(b.AccessibleName);
            WorkProduct workProduct = workProducts.FirstOrDefault(wp => wp.GetWorkProductId() == workProductId);
            if (workProduct == null)
            {
                MessageBox.Show("Some problems with alpha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PopupWindowForEditWorkProduct popupWindowForEditWorkProduct = new PopupWindowForEditWorkProduct(this, workProduct);
            popupWindowForEditWorkProduct.ShowDialog();
            return;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            Button b = (Button)sender;
            Guid workProductId = Guid.Parse(b.AccessibleName);
            WorkProduct workProduct = workProducts.FirstOrDefault(wp => wp.GetWorkProductId() == workProductId);
            if (workProduct == null)
            {
                MessageBox.Show("Some problems with alpha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            workProducts.Remove(workProduct);
            ExportAllToJsonFiles();
            UpdateWorkProductsTable();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddWP_Click(object sender, EventArgs e)
        {
            
        }
        private void DeserializeJsonFiles()
        {
            DeserializeJsonWorkProducts();
        }
        private void DeserializeJsonWorkProducts()
        {
            if (File.Exists(pathToWorkProductsFile))
            {
                string jsonString = File.ReadAllText(pathToWorkProductsFile);
                if (jsonString != null && jsonString != "")
                {
                    workProducts = JsonSerializer.Deserialize<List<WorkProduct>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
            }
            else
            {
                using (File.Create(pathToWorkProductsFile)) { }
            }
        }
        public void ExportAllToJsonFiles()
        {
            ExportWorkProductsToJsonFile();
        }

        public void ExportWorkProductsToJsonFile()
        {
            var jsonWorkProducts = JsonSerializer.Serialize(workProducts, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(pathToWorkProductsFile, jsonWorkProducts);
        }
        private void buttonAddWorkProduct_Click(object sender, EventArgs e)
        {
            new PopupWindowForAddWorkProduct(this).ShowDialog();
        }
        public void AddWorkProduct(WorkProduct workProduct)
        {
            workProducts.Add(workProduct);
            ExportWorkProductsToJsonFile();
            UpdateWorkProductsTable();
        }
        public void ExportAllToJsonAndUpdateTable()
        {
            ExportAllToJsonFiles();
            UpdateWorkProductsTable();
        }
        public List<WorkProduct> GetWorkProducts()
        {
            return workProducts;
        }
    }
}
