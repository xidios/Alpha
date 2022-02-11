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
    public partial class PopupWindowForCheckpointsTable : Form
    {
        State state;
        Form1 form1;
        public PopupWindowForCheckpointsTable(Form1 form1, State state)
        {
            InitializeComponent();
            this.form1 = form1;
            this.state = state;
            this.Text = $"Checkpoints of {state.Name}";
            UpdateCheckpointsTable();
        }

        public void UpdateCheckpointsTable()
        {

            form1.ExportAllToJsonFiles();
            tableLayoutPanelOfCheckpoints.Controls.Clear();

            tableLayoutPanelOfCheckpoints.RowCount = state.GetCheckpoints().Count() + 1; //не бейте
            tableLayoutPanelOfCheckpoints.Controls.Add(new Label
            {
                Text = "Checkpoint",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 0, 0);
            tableLayoutPanelOfCheckpoints.Controls.Add(new Label
            {
                Text = "Description",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 1, 0);
            tableLayoutPanelOfCheckpoints.Controls.Add(new Label
            {
                Text = "Orders",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 2, 0);
            tableLayoutPanelOfCheckpoints.Controls.Add(new Label
            {
                Text = "Edit",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 3, 0);
            tableLayoutPanelOfCheckpoints.Controls.Add(new Label
            {
                Text = "Delete",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 4, 0);
            List<Checkpoint> checkpoints = state.GetCheckpoints();
            for (int i = 1; i <= checkpoints.Count; i++)
            {
                tableLayoutPanelOfCheckpoints.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30F));
                Checkpoint checkpoint = checkpoints[i - 1];
                Guid stateId = checkpoint.GetCheckpointId();
                Label checkpointNameLabel = new Label();
                checkpointNameLabel.Text = checkpoint.Name;

                Label checkpointDescription = new Label();
                checkpointDescription.Text = checkpoint.Description;

                Label checkpointOrder = new Label();
                checkpointOrder.Text = checkpoint.Order.ToString();

                Button deleteCheckpointButton = new Button();
                deleteCheckpointButton.Text = "Delete";
                deleteCheckpointButton.AccessibleName = stateId.ToString();
                deleteCheckpointButton.Click += new EventHandler(buttonDeleteCheckpoint_Click);

                Button editCheckpointButton = new Button();
                editCheckpointButton.Text = "Edit";
                editCheckpointButton.AccessibleName = stateId.ToString();
                editCheckpointButton.Click += new EventHandler(buttonEditCheckpoint_Click);


                tableLayoutPanelOfCheckpoints.Controls.Add(checkpointNameLabel, 0, i);
                tableLayoutPanelOfCheckpoints.Controls.Add(checkpointDescription, 1, i);
                tableLayoutPanelOfCheckpoints.Controls.Add(checkpointOrder, 2, i);
                tableLayoutPanelOfCheckpoints.Controls.Add(editCheckpointButton, 3, i);
                tableLayoutPanelOfCheckpoints.Controls.Add(deleteCheckpointButton, 4, i);
            }


        }
        private void buttonAddCheckpoint_Click(object sender, EventArgs e)
        {
            PopupWindowForAddCheckpoint popupWindowForAddState = new PopupWindowForAddCheckpoint(this,state);
            popupWindowForAddState.ShowDialog();
        }
        private void buttonDeleteCheckpoint_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            Button b = (Button)sender;
            Guid checkpointId = Guid.Parse(b.AccessibleName);
            List<Checkpoint> checkpoints = state.GetCheckpoints();
            Checkpoint checkpoint = checkpoints.First(c => c.GetCheckpointId() == checkpointId);
            if (checkpoint == null)
            {
                MessageBox.Show("Some problems with checkpoint", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            checkpoints.Remove(checkpoint);
            UpdateCheckpointsTable();
        }

        private void buttonEditCheckpoint_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Guid checkpointId = Guid.Parse(b.AccessibleName);
            List<Checkpoint> checkpoints = state.GetCheckpoints();
            Checkpoint checkpoint = checkpoints.First(c => c.GetCheckpointId() == checkpointId);
            if (checkpoint == null)
            {
                MessageBox.Show("Some problems with state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PopupWindowForEditCheckpoint popupWindowForEditCheckpoint = new PopupWindowForEditCheckpoint(this, checkpoint);
            popupWindowForEditCheckpoint.ShowDialog();
        }
    }
}
