using Alpha.Models;
using Alpha.Services;
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
    public partial class PopupWindowForAddActivity : Form
    {
        DataStorageService dataStorageService = DataStorageService.GetInstance();
        public PopupWindowForAddActivity()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string activityName = activityNameInput.Text;
            if (activityName == null || activityName == "")
            {
                MessageBox.Show("Please enter activity's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string activityDescription = activityDescriptionInput.Text;
            if (activityDescription == null || activityDescription == "")
            {
                MessageBox.Show("Please enter activity's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var a in dataStorageService.GetActivities())
            {
                if (a.GetName() == activityName)
                {
                    MessageBox.Show("Activity with same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Activity activity = new Activity(activityName, activityDescription);
            dataStorageService.AddActivity(activity);
            this.Close();
        }
    }
}
