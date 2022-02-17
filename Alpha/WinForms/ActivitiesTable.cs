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
using Alpha.Models;
using Alpha.Services;

namespace Alpha.WinForms
{
    public partial class ActivitiesTable : Form
    {
        List<Activity> activities = new List<Activity>();
        private JsonSerializationToFileService jsonSerializationToFileService = new JsonSerializationToFileService();
        private JsonDeserializationService jsonDeserializationService = new JsonDeserializationService();
        public ActivitiesTable()
        {
            InitializeComponent();
            UpdateActivitiesTable();
        }
        public List<Activity> GetActivitiesList() => activities;
        public void AddActivityToList(Activity activity)
        {
            activities.Add(activity);
            jsonSerializationToFileService.ExportActivitiesToJsonFile(activities);
            UpdateActivitiesTable();

        }
        public void UpdateActivitiesTable()
        {
            DeserializeJsonFiles();
            tableLayoutPanelActivities.Controls.Clear();

            tableLayoutPanelActivities.RowCount = activities.Count() + 1;
            tableLayoutPanelActivities.Controls.Add(new Label
            {
                Text = "Activity",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 0, 0);
            tableLayoutPanelActivities.Controls.Add(new Label
            {
                Text = "More",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 1, 0);
            tableLayoutPanelActivities.Controls.Add(new Label
            {
                Text = "Delete",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 2, 0);

            for (int i = 1; i <= activities.Count; i++)
            {
                tableLayoutPanelActivities.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30F));
                Activity activity = activities[i - 1];
                Guid activityId = activity.GetId();

                Button editButton = new Button();
                editButton.Text = "Edit";
                editButton.AccessibleName = activityId.ToString();
                editButton.Click += new EventHandler(buttonEdit_Click);

                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.AccessibleName = activityId.ToString();
                deleteButton.Click += new EventHandler(buttonDelete_Click);

                Label activityNameLabel = new Label();
                activityNameLabel.Text = activity.Name;

                tableLayoutPanelActivities.Controls.Add(activityNameLabel, 0, i);
                tableLayoutPanelActivities.Controls.Add(editButton, 1, i);
                tableLayoutPanelActivities.Controls.Add(deleteButton, 2, i);
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DeserializeJsonFiles()
        {
            activities = jsonDeserializationService.DeserializeJsonActivities();
        }

        public void ExportAllToJsonFiles()
        {
            jsonSerializationToFileService.ExportActivitiesToJsonFile(activities);
        }

        private void buttonAddActivity_Click(object sender, EventArgs e)
        {
            PopupWindowForAddActivity popupWindowForAddActivity = new PopupWindowForAddActivity(this);
            popupWindowForAddActivity.ShowDialog();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            Button b = (Button)sender;
            Guid activityId = Guid.Parse(b.AccessibleName);
            Activity activity = activities.FirstOrDefault(a => a.GetId() == activityId);
            if (activity == null)
            {
                MessageBox.Show("Some problems with activity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //RemoveFromWorkProductManifests(workProduct);
            activities.Remove(activity);
            ExportAllToJsonFiles();
            UpdateActivitiesTable();
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Guid activityId = Guid.Parse(b.AccessibleName);
            Activity activity = activities.FirstOrDefault(a => a.GetId() == activityId);
            if (activity == null)
            {
                MessageBox.Show("Some problems with activity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PopupWindowForEditActivity popupWindowForEditActivity = new PopupWindowForEditActivity(this, activity);
            popupWindowForEditActivity.ShowDialog();
            return;
        }
        public void ExportAllToJsonAndUpdateTable()
        {
            ExportAllToJsonFiles();
            UpdateActivitiesTable();
        }
    }
}
