using Alpha.Models;
using Alpha.Interfaces;
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
        private WorkProductsTable workProductsTable;
        private WorkProduct workProduct;
        private List<Activity> activities;
        private string oldWorkProductName;
        public List<Activity> GetActivities() => activities;
        public WorkProductsTable GetworkProductsTable() => workProductsTable;
        public PopupWindowForEditWorkProduct(WorkProductsTable workProductsTable, WorkProduct workProduct)
        {
            InitializeComponent();
            activities = workProductsTable.GetActivities();
            this.Text = $"Edit {workProduct.GetWorkProductName()}";
            this.workProductsTable = workProductsTable;
            this.workProduct = workProduct;
            oldWorkProductName = workProduct.GetWorkProductName();
            workProductNameInput.Text = oldWorkProductName;
            workProductDescriptionInput.Text = workProduct.GetWorkProductDescription();
            UpdateLevelOfDetailsTable();
        }
        public void UpdateLevelOfDetailsTable()
        {
            workProductsTable.ExportAllToJsonFiles();
            tableLayoutPanelOfLevelOfDetails.Controls.Clear();

            tableLayoutPanelOfLevelOfDetails.RowCount = workProduct.GetLevelOfDetails().Count() + 1;
            tableLayoutPanelOfLevelOfDetails.Controls.Add(new Label
            {
                Text = "Level of details",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 0, 0);
            tableLayoutPanelOfLevelOfDetails.Controls.Add(new Label
            {
                Text = "Description",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 1, 0);
            tableLayoutPanelOfLevelOfDetails.Controls.Add(new Label
            {
                Text = "Orders",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 2, 0);
            tableLayoutPanelOfLevelOfDetails.Controls.Add(new Label
            {
                Text = "Checkpoints",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 3, 0);
            tableLayoutPanelOfLevelOfDetails.Controls.Add(new Label
            {
                Text = "Edit",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 4, 0);
            tableLayoutPanelOfLevelOfDetails.Controls.Add(new Label
            {
                Text = "Delete",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 5, 0);
            List<LevelOfDetail> levelOfDetails = workProduct.GetLevelOfDetails();
            for (int i = 1; i <= levelOfDetails.Count; i++)
            {
                tableLayoutPanelOfLevelOfDetails.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30F));
                LevelOfDetail levelOfDetail = levelOfDetails[i - 1];
                Guid levelOfDetailId = levelOfDetail.GetId();
                Label levelOfDetailNameLabel = new Label();
                levelOfDetailNameLabel.Text = levelOfDetail.GetName();

                Label levelOfDetailDescription = new Label();
                levelOfDetailDescription.Text = levelOfDetail.GetDescription();

                Label levelOfDetailOrder = new Label();
                levelOfDetailOrder.Text = levelOfDetail.GetOrder().ToString();

                Button openCheckpointsButton = new Button();
                openCheckpointsButton.Text = "Open";
                openCheckpointsButton.AccessibleName = levelOfDetailId.ToString();
                openCheckpointsButton.Click += new EventHandler(buttonOpenCheckpointTable_Click);

                Button deleteLevelOfDetailButton = new Button();
                deleteLevelOfDetailButton.Text = "Delete";
                deleteLevelOfDetailButton.AccessibleName = levelOfDetailId.ToString();
                deleteLevelOfDetailButton.Click += new EventHandler(buttonDeleteLevelOfDetail_Click);

                Button editLevelOfDetailButton = new Button();
                editLevelOfDetailButton.Text = "Edit";
                editLevelOfDetailButton.AccessibleName = levelOfDetailId.ToString();
                editLevelOfDetailButton.Click += new EventHandler(buttonEditLevelOfDetail_Click);


                tableLayoutPanelOfLevelOfDetails.Controls.Add(levelOfDetailNameLabel, 0, i);
                tableLayoutPanelOfLevelOfDetails.Controls.Add(levelOfDetailDescription, 1, i);
                tableLayoutPanelOfLevelOfDetails.Controls.Add(levelOfDetailOrder, 2, i);
                tableLayoutPanelOfLevelOfDetails.Controls.Add(openCheckpointsButton, 3, i);
                tableLayoutPanelOfLevelOfDetails.Controls.Add(editLevelOfDetailButton, 4, i);
                tableLayoutPanelOfLevelOfDetails.Controls.Add(deleteLevelOfDetailButton, 5, i);
            }

        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // TODO: this
        private void buttonOpenCheckpointTable_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Guid levelOfDetailId = Guid.Parse(b.AccessibleName);
            List<LevelOfDetail> levelOfDetails = workProduct.GetLevelOfDetails();
            var levelOfDetail = levelOfDetails.First(s => s.GetId() == levelOfDetailId);
            if (levelOfDetail == null)
            {
                MessageBox.Show("Some problems with work product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PopupWindowForCheckpointsTable popupWindowForCheckpointsTable = new PopupWindowForCheckpointsTable(workProductsTable, levelOfDetail);
            popupWindowForCheckpointsTable.ShowDialog();
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
        private void buttonEditLevelOfDetail_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Guid levelOfDetailId = Guid.Parse(b.AccessibleName);
            List<LevelOfDetail> levelOfDetails = workProduct.GetLevelOfDetails();
            LevelOfDetail levelOfDetail = levelOfDetails.FirstOrDefault(l => l.GetId() == levelOfDetailId);
            if (levelOfDetail == null)
            {
                MessageBox.Show("Some problems with level of detail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PopupWindowForEditLevelOfDetail popupWindowForEditLevelOfDetail = new PopupWindowForEditLevelOfDetail(this, levelOfDetail);
            popupWindowForEditLevelOfDetail.ShowDialog();
        }
        private void buttonDeleteLevelOfDetail_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            Button b = (Button)sender;
            Guid levelOfDetailId = Guid.Parse(b.AccessibleName);
            List<LevelOfDetail> levelOfDetails = workProduct.GetLevelOfDetails();
            LevelOfDetail levelOfDetail = levelOfDetails.FirstOrDefault(l => l.GetId() == levelOfDetailId);
            if (levelOfDetail == null)
            {
                MessageBox.Show("Some problems with level of detail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            workProductsTable.DeleteWorkProductCriterion(levelOfDetail.GetWorkProductCriterion());
            levelOfDetails.Remove(levelOfDetail);
            UpdateLevelOfDetailsTable();
        }
        private void buttonAddlevelOfDetail_Click(object sender, EventArgs e)
        {
            PopupWindowForAddLevelOfDetails popupWindowForAddLevelOfDetails = new PopupWindowForAddLevelOfDetails(this, workProduct);
            popupWindowForAddLevelOfDetails.ShowDialog();
        }
    }
}
