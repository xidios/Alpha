using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alpha.Models;
using Alpha.Services;

namespace Alpha.WinForms
{
    public partial class PopupWindowForEditLevelOfDetail : Form
    {
        private LevelOfDetail levelOfDetail;
        private WorkProductCriterion workProductCriterion = null;
        private DataStorageService dataStorageService = DataStorageService.GetInstance();
        public PopupWindowForEditLevelOfDetail(LevelOfDetail levelOfDetail)
        {
            InitializeComponent();
            this.levelOfDetail = levelOfDetail;
            this.Text = $"Edit {levelOfDetail.GetName()}";
            UpdateEditLevelOfDetailsUI();
            UpdateListBoxes();
            UpdateWorkProductCriterionAndLabel();
        }
        private void UpdateEditLevelOfDetailsUI()
        {
            levelOfDetailNameInput.Text = levelOfDetail.GetName();
            levelOfDetailDescriptionInput.Text = levelOfDetail.GetDescription();
            levelOfDetailOrderInput.Text = levelOfDetail.GetOrder().ToString();
        }
        private void UpdateListBoxes()
        {
            var activitiesName = dataStorageService.GetActivities().Select(a => a.Name).ToList();
            foreach (var name in activitiesName)
            {
                listBoxOfActivities.Items.Add(name);
            }
        }
        private void UpdateWorkProductCriterionAndLabel()
        {
            workProductCriterion = levelOfDetail.GetWorkProductCriterion();
            if (workProductCriterion == null)
            {
                labelWorkProductCriterion.Text = "Work product criterion: null";
                typeTextBox.Text = "";
                partialTextBox.Text = "";
                minimalNumericUpDown.Value = 0;
                return;
            }
            string workProductCriterionActivityName = workProductCriterion.GetActivity().GetName();
            labelWorkProductCriterion.Text = $"Work product criterion: {workProductCriterionActivityName}";
            typeTextBox.Text = workProductCriterion.GetTypeParameter();
            partialTextBox.Text = workProductCriterion.GetPartial();
            minimalNumericUpDown.Value = workProductCriterion.GetMinimal();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string levelOfDetailName = levelOfDetailNameInput.Text;
            if (levelOfDetailName == null || levelOfDetailName == "")
            {
                MessageBox.Show("Please enter level of detail's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string levelOfDetailDescription = levelOfDetailDescriptionInput.Text;
            if (levelOfDetailDescription == null || levelOfDetailDescription == "")
            {
                MessageBox.Show("Please enter level of detail's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string levelOfDetailOdred = levelOfDetailOrderInput.Text;
            if (levelOfDetailOdred == null || levelOfDetailOdred == "")
            {
                MessageBox.Show("Please enter level of detail's order", "Nullable order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            levelOfDetail.Name = levelOfDetailName;
            levelOfDetail.Description = levelOfDetailDescription;
            levelOfDetail.Order = Int32.Parse(levelOfDetailOdred);
            dataStorageService.UpdateLevelOfDetails();
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonSaveCriterion_Click(object sender, EventArgs e)
        {
               
            string workProductCriterionType = typeTextBox.Text;
            if (workProductCriterionType == null || workProductCriterionType == "" && workProductCriterion == null)
            {
                MessageBox.Show("Work product criterion type was not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string workProductCriterionPartial = partialTextBox.Text;
            if (workProductCriterionPartial == null || workProductCriterionPartial == "" && workProductCriterion == null)
            {
                MessageBox.Show("Work product criterion partial was not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int workProductCriterionMinimal = (int)minimalNumericUpDown.Value;

            var activityName = listBoxOfActivities.Text;
            if (activityName == null || activityName == "" && workProductCriterion == null)
            {
                MessageBox.Show("Activity was not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var activity = dataStorageService.GetActivities().FirstOrDefault(a => a.GetName() == activityName);
            if (activity == null && workProductCriterion == null)
            {
                MessageBox.Show("Some problems with Work Product Criterion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (workProductCriterion == null)
            {
                workProductCriterion = new WorkProductCriterion(workProductCriterionType, workProductCriterionPartial, workProductCriterionMinimal, activity);
                workProductCriterion.SetLevelOfDetail(levelOfDetail);
                workProductCriterion.SetActivity(activity);
                dataStorageService.AddWorkProductCriterion(workProductCriterion);               
            }
            else
            {
                if (activity == null)
                {
                    activity = workProductCriterion.GetActivity();
                }
                activity.DeleteWorkProductCriterion(workProductCriterion);
                workProductCriterion.SetActivity(activity);
                workProductCriterion.Type = workProductCriterionType;
                workProductCriterion.Partial = workProductCriterionPartial;
                workProductCriterion.Minimal = workProductCriterionMinimal;
                dataStorageService.UpdateWorkProductCriterions();

            }
            UpdateWorkProductCriterionAndLabel();
        }

        private void buttonDeleteWorkProductCriterion_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            if (workProductCriterion == null)
            {
                return;
            }
            workProductCriterion.GetActivity().DeleteWorkProductCriterion(workProductCriterion);
            LevelOfDetail levelOfDetail = workProductCriterion.GetLevelOfDetail();
            levelOfDetail.DeleteWorkProductCriterion();
            dataStorageService.RemoveWorkProductCriterion(workProductCriterion);
            workProductCriterion = null;
            UpdateWorkProductCriterionAndLabel();
        }
    }
}
