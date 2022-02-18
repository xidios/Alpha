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

namespace Alpha
{
    public partial class PopupWindowForEditState : Form
    {
        State state;
        Form1 form1;
        PopupWindowForEditAlpha popupWindowForEditAlpha;
        AlphaCriterion alphaCriterion;
        List<Activity> activities;
        public PopupWindowForEditState(State state, Form1 form1, PopupWindowForEditAlpha popupWindowForEditAlpha)
        {
            InitializeComponent();
            this.state = state;
            this.form1 = form1;
            activities = form1.GetAllActivities();
            this.popupWindowForEditAlpha = popupWindowForEditAlpha;
            this.Text = $"Edit {state.Name}";
            UpdateEditStateUI();
            UpdateListBoxes();
            UpdateWorkProductCriterionAndLabel();
        }
        private void UpdateEditStateUI()
        {
            stateNameInput.Text = state.Name;
            stateDescriptionInput.Text = state.Description;
            stateOrderInput.Text = state.Order.ToString();
        }
        private void UpdateListBoxes()
        {
            var activitiesName = activities.Select(a => a.Name).ToList();
            foreach (var name in activitiesName)
            {
                listBoxOfActivities.Items.Add(name);
            }
        }
        private void UpdateWorkProductCriterionAndLabel()
        {
            alphaCriterion = state.GetAlphaCriterion();
            if (alphaCriterion == null)
            {
                labelAlphaCriterion.Text = "Alpha criterion: null";
                typeTextBox.Text = "";
                partialTextBox.Text = "";
                minimalTextBox.Text = "";
                return;
            }
            string AkphaCriterionActivityName = alphaCriterion.GetActivity().GetName();
            labelAlphaCriterion.Text = $"Alpha criterion: {AkphaCriterionActivityName}";
            typeTextBox.Text = alphaCriterion.GetTypeParameter();
            partialTextBox.Text = alphaCriterion.GetPartial();
            minimalTextBox.Text = alphaCriterion.GetMinimal();

        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string stateName = stateNameInput.Text;
            if (stateName == null || stateName == "")
            {
                MessageBox.Show("Please enter state's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string stateDescription = stateDescriptionInput.Text;
            if (stateDescription == null || stateDescription == "")
            {
                MessageBox.Show("Please enter state's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string stateOdred = stateOrderInput.Text;
            if (stateOdred == null || stateOdred == "")
            {
                MessageBox.Show("Please enter state's order", "Nullable order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            state.Name = stateName;
            state.Description = stateDescription;
            state.Order = Int32.Parse(stateOdred);
            form1.ExportAllToJsonFiles();
            popupWindowForEditAlpha.UpdateStatesTable();
            this.Close();
        }

        private void buttonSaveCriterion_Click(object sender, EventArgs e)
        {
            string alphaCriterionType = typeTextBox.Text;
            if (alphaCriterionType == null || alphaCriterionType == "" && alphaCriterion == null)
            {
                MessageBox.Show("Alpha criterion type was not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string alphaCriterionPartial = partialTextBox.Text;
            if (alphaCriterionPartial == null || alphaCriterionPartial == "" && alphaCriterion == null)
            {
                MessageBox.Show("Alpha criterion partial was not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string alphaCriterionMinimal = minimalTextBox.Text;
            if (alphaCriterionMinimal == null || alphaCriterionMinimal == "" && alphaCriterion == null)
            {
                MessageBox.Show("Alpha criterion minimal was not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var activityName = listBoxOfActivities.Text;
            if (activityName == null || activityName == "" && alphaCriterion == null)
            {
                MessageBox.Show("Activity was not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var activity = activities.FirstOrDefault(a => a.GetName() == activityName);
            if (activity == null && alphaCriterion == null)
            {
                MessageBox.Show("Some problems with Alpha Criterion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (alphaCriterion == null)
            {
                alphaCriterion = new AlphaCriterion(alphaCriterionType, alphaCriterionPartial, alphaCriterionMinimal, activity);
                alphaCriterion.SetState(state);
                alphaCriterion.SetActivity(activity);
                form1.AddAlphaCriterion(alphaCriterion);
            }
            else
            {
                if (activity == null)
                {
                    activity = alphaCriterion.GetActivity();
                }
                activity.DeleteAlphaCriterion(alphaCriterion);
                alphaCriterion.SetActivity(activity);
                alphaCriterion.Type = alphaCriterionType;
                alphaCriterion.Partial = alphaCriterionPartial;
                alphaCriterion.Minimal = alphaCriterionMinimal;
                form1.ExportAllAlphaCriterionsToFile();

            }
            UpdateWorkProductCriterionAndLabel();
        }

        private void buttonDeleteCriterion_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            if (alphaCriterion == null)
            {
                return;
            }
            alphaCriterion.GetActivity().DeleteAlphaCriterion(alphaCriterion);
            State state = alphaCriterion.GetState();
            state.DeleteAlphaCriterion();
            form1.DeleteAlphaCriterion(alphaCriterion);
            alphaCriterion = null;
            UpdateWorkProductCriterionAndLabel();
        }
    }
}
