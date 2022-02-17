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
using Alpha.Services;

namespace Alpha.WinForms
{
    public partial class WorkProductsTable : Form
    {
        private List<WorkProduct> workProducts = new List<WorkProduct>();
        private List<WorkProductManifest> workProductManifests = new List<WorkProductManifest>();
        private List<Activity> activities = new List<Activity>();
        private JsonSerializationToFileService jsonSerializationToFileService = new JsonSerializationToFileService();
        private JsonDeserializationService jsonDeserializationService = new JsonDeserializationService();
        
        private string pathToWorkProductManifest = Form1.pathToWorkProductManifest;
        private string pathToLevelOfDetails = "levelOfDetails.json";
        public List<Activity> GetActivities() => activities;
        private List<WorkProductCriterion> workProductCriteria = new List<WorkProductCriterion>();
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
                MessageBox.Show("Some problems with work product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Some problems with work product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RemoveFromWorkProductManifests(workProduct);
            workProducts.Remove(workProduct);
            ExportAllToJsonFiles();
            UpdateWorkProductsTable();
        }
        private void RemoveFromWorkProductManifests(WorkProduct workProduct)
        {
            foreach (var workProductManifest in workProduct.GetWorkProductManifests())
                workProductManifests.Remove(workProductManifest);
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
            workProducts = jsonDeserializationService.DeserializeJsonWorkProducts();
            activities = jsonDeserializationService.DeserializeJsonActivities();
            DeserializeJsonWorkProductManifests();
            DeserializeJsonLevelOfDetails();
        }

        
        private void DeserializeJsonWorkProductManifests()
        {
            if (File.Exists(pathToWorkProductManifest))
            {
                string jsonString = File.ReadAllText(pathToWorkProductManifest);
                if (jsonString != null && jsonString != "")
                {
                    workProductManifests = JsonSerializer.Deserialize<List<WorkProductManifest>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                foreach (var workProductManifest in workProductManifests)
                {
                    WorkProduct workProduct = workProducts.FirstOrDefault(wp => wp.Id == workProductManifest.GetWorkProductId());
                    if (workProduct != null)
                    {
                        workProductManifest.SetWorkProduct(workProduct);
                    }
                }
            }
            else
            {
                using (File.Create(pathToWorkProductManifest)) { }
            }
        }

        private void DeserializeJsonLevelOfDetails()
        {
            if (File.Exists(pathToLevelOfDetails))
            {
                string jsonString = File.ReadAllText(pathToLevelOfDetails);
                List<LevelOfDetail> levelOfDetails = new List<LevelOfDetail>();
                if (jsonString != null && jsonString != "")
                {
                    levelOfDetails = JsonSerializer.Deserialize<List<LevelOfDetail>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                foreach (var levelOfDetail in levelOfDetails)
                {
                    WorkProduct workProduct = workProducts.First(wp => wp.GetWorkProductId() == levelOfDetail.GetWorkProductId());
                    if (workProduct != null)
                    {
                        workProduct.AddLevelOfDetailToList(levelOfDetail);
                    }
                }
                SortWorkProductsLevelOfStatesByOrder();
            }
            else
            {
                using (File.Create(pathToLevelOfDetails)) { }
            }
        }
        private void SortWorkProductsLevelOfStatesByOrder()
        {
            foreach (var workProduct in workProducts)
            {
                workProduct.SortListOfLevelOfDetailsByOrder();
            }
        }
        public void ExportAllToJsonFiles()
        {
            jsonSerializationToFileService.ExportWorkProductsToJsonFile(workProducts);
            ExportWorkProductManifestsToJsonFile();
            ExportLevelOfDetailsToJsonFile();
        }

        

        private void ExportWorkProductManifestsToJsonFile()
        {
            var jsonWorkProducts = JsonSerializer.Serialize(workProductManifests, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(pathToWorkProductManifest, jsonWorkProducts);
        }
        private void ExportLevelOfDetailsToJsonFile()
        {

            var jsonLevelOfDetails = JsonSerializer.Serialize(GetAllLevelOfDetails(), new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(pathToLevelOfDetails, jsonLevelOfDetails);
        }
        private List<LevelOfDetail> GetAllLevelOfDetails()
        {
            List<LevelOfDetail> AllLevelOfDetails = new List<LevelOfDetail>();
            foreach (var workProduct in workProducts)
            {
                AllLevelOfDetails.AddRange(workProduct.GetLevelOfDetails());
            }
            return AllLevelOfDetails;
        }
        private void buttonAddWorkProduct_Click(object sender, EventArgs e)
        {
            new PopupWindowForAddWorkProduct(this).ShowDialog();
        }
        public void AddWorkProduct(WorkProduct workProduct)
        {
            workProducts.Add(workProduct);
            jsonSerializationToFileService.ExportWorkProductsToJsonFile(workProducts);
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
