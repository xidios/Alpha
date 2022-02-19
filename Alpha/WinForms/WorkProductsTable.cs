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
using Alpha.Interfaces;
using Alpha.Data;

namespace Alpha.WinForms
{
    public partial class WorkProductsTable : Form, IMainFormInterface
    {
        private List<WorkProduct> workProducts = new List<WorkProduct>();
        private List<WorkProductManifest> workProductManifests = new List<WorkProductManifest>();
        private List<Activity> activities = new List<Activity>();
        private List<WorkProductCriterion> workProductCriterions = new List<WorkProductCriterion>();
        private JsonSerializationToFileService jsonSerializationToFileService = new JsonSerializationToFileService();
        private JsonDeserializationService jsonDeserializationService = new JsonDeserializationService();
        public List<Activity> GetActivities() => activities;
        private List<WorkProductCriterion> workProductCriteria = new List<WorkProductCriterion>();
        public WorkProductsTable()
        {
            InitializeComponent();
            UpdateWorkProductsTable();
        }
        public void DeleteWorkProductCriterion(WorkProductCriterion workProductCriterion)
        {
            workProductCriterions.Remove(workProductCriterion);
            ExportAllToJsonFiles();
        }
        public void ExportAllWorkProductCriterionsToFile()
        {
            jsonSerializationToFileService.ExportWorkProductCriterionsToFile(workProductCriterions);
        }
        public void AddWorkProductCriterion(WorkProductCriterion workProductCriterion)
        {
            workProductCriterions.Add(workProductCriterion);
            jsonSerializationToFileService.ExportWorkProductCriterionsToFile(workProductCriterions);
        }
        public void UpdateWorkProductsTable()
        {
            DeserializeJsonFiles();
            tableLayoutPanelWP.Controls.Clear();

            tableLayoutPanelWP.RowCount = workProducts.Count() + 1;
            tableLayoutPanelWP.Controls.Add(new Label
            {
                Text = "Work Product",
                Font = new Font(Label.DefaultFont, FontStyle.Bold),
                Size = new Size(250,20)
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
                workProductNameLabel.AutoSize = true;
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
            RemoveFromWorkProductCriterion(workProduct);
            workProducts.Remove(workProduct);
            ExportAllToJsonFiles();
            UpdateWorkProductsTable();
        }
        private void RemoveFromWorkProductManifests(WorkProduct workProduct)
        {
            foreach (var workProductManifest in workProduct.GetWorkProductManifests())
                workProductManifests.Remove(workProductManifest);
        }
        private void RemoveFromWorkProductCriterion(WorkProduct workProduct)
        {
            List<LevelOfDetail> levelOfDetails = workProduct.GetLevelOfDetails();
            foreach (var levelOfDetail in levelOfDetails)
            {
                var workProductCriterion = levelOfDetail.GetWorkProductCriterion();
                workProductCriterions.Remove(workProductCriterion);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DeserializeJsonFiles()
        {
            workProducts = jsonDeserializationService.DeserializeJsonWorkProducts();
            activities = jsonDeserializationService.DeserializeJsonActivities();
            workProductManifests = jsonDeserializationService.DeserializeJsonWorkProductManifests(new List<Alpha>(), workProducts);
            jsonDeserializationService.DeserializeJsonLevelOfDetails(workProducts);
            workProductCriterions = jsonDeserializationService.DeserializeJsonWorkProductCriterions(activities, GetAllLevelOfDetails());
        }


        public void ExportAllToJsonFiles()
        {
            jsonSerializationToFileService.ExportWorkProductsToJsonFile(workProducts);
            jsonSerializationToFileService.ExportWorkProductManifestsToJsonFile(workProductManifests);
            jsonSerializationToFileService.ExportLevelOfDetailsToJsonFile(GetAllLevelOfDetails());
            List<Checkpoint> checkpoints = GetAllCheckpoints(GetAllLevelOfDetails());
            jsonSerializationToFileService.ExportCheckpointsToJsonFile(checkpoints, JsonPaths.pathToLevelOfDetailCheckpointsFile);
            jsonSerializationToFileService.ExportWorkProductCriterionsToFile(workProductCriterions);
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
        private List<Checkpoint> GetAllCheckpoints(List<LevelOfDetail> levelOfDetails)
        {
            List<Checkpoint> checkpoints = new List<Checkpoint>();
            foreach (var level in levelOfDetails)
            {
                checkpoints.AddRange(level.GetCheckpoints());
            }
            return checkpoints;
        }
    }
}
