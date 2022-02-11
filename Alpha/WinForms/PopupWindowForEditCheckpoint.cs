using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alpha
{
    public partial class PopupWindowForEditCheckpoint : Form
    {
        PopupWindowForCheckpointsTable popupWindowForCheckpointsTable;
        Checkpoint checkpoint;
        public PopupWindowForEditCheckpoint(PopupWindowForCheckpointsTable popupWindowForCheckpointsTable, Checkpoint checkpoint)
        {
            InitializeComponent();
            this.popupWindowForCheckpointsTable = popupWindowForCheckpointsTable;
            this.checkpoint = checkpoint;
            this.Text = $"Edit {checkpoint.Name}";
            checkpointNameInput.Text = checkpoint.Name;
            checkpointDescriptionInput.Text = checkpoint.Description;
            checkpointOrderInput.Text = checkpoint.Order.ToString();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string checkpointName = checkpointNameInput.Text;
            if (checkpointName == null || checkpointName == "")
            {
                MessageBox.Show("Please enter checkpoint's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string checkpointDescription = checkpointDescriptionInput.Text;
            if (checkpointDescription == null || checkpointDescription == "")
            {
                MessageBox.Show("Please enter checkpoint's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string checkpointOdred = checkpointOrderInput.Text;
            if (checkpointOdred == null || checkpointOdred == "")
            {
                MessageBox.Show("Please enter checkpoint's order", "Nullable order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            checkpoint.Name = checkpointName;
            checkpoint.Description = checkpointDescription;
            checkpoint.Order = Int32.Parse(checkpointOdred);
            popupWindowForCheckpointsTable.UpdateCheckpointsTable();
            this.Close();
        }
    }
}
