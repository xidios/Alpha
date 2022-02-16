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

namespace Alpha.WinForms
{
    public partial class PopupWindowForEditActivity : Form
    {
        Activity activity;
        ActivitiesTable activitiesTable;
        string oldActivityName;
        public PopupWindowForEditActivity(ActivitiesTable activitiesTable, Activity activity)
        {
            InitializeComponent();
            this.activitiesTable = activitiesTable;
            this.activity = activity;
            oldActivityName = activity.GetName();
            activityNameInput.Text = activity.GetName();
            activityDescriptionInput.Text = activity.GetDescription();
            this.Text = $"Edit {activity.GetName()}";

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string activityName = activityNameInput.Text;
            if (activityName == null || activityName == "")
            {
                MessageBox.Show("Please enter activity's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (oldActivityName != activityName)
            {
                foreach (var a in activitiesTable.GetActivitiesList())
                {

                    if (a.GetName() == activityName)
                    {
                        MessageBox.Show("Activity with same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            string activityDescription = activityDescriptionInput.Text;
            if (activityDescription == null || activityDescription == "")
            {
                MessageBox.Show("Please enter activity's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            activity.SetName(activityName);
            activity.SetDescription(activityDescription);
            activitiesTable.ExportAllToJsonAndUpdateTable();
            this.Close();
        }
    }
}
