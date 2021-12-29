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
        public PopupWindowForCheckpointsTable(State state)
        {
            InitializeComponent();
            this.state = state;
            this.Text = $"Checkpoints of {state.Name}";
            UpdateCheckpointsTable();
        }

        public void UpdateCheckpointsTable()
        {

            //form1.ExportAllToJsonFiles();
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
            }, 4, 0);
            tableLayoutPanelOfCheckpoints.Controls.Add(new Label
            {
                Text = "Delete",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 5, 0);
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
                //deleteStateButton.Click += new EventHandler(buttonDeleteState_Click);

                Button editCheckpointButton = new Button();
                editCheckpointButton.Text = "Edit";
                editCheckpointButton.AccessibleName = stateId.ToString();
                //edirStateButton.Click += new EventHandler(buttonEditState_Click);


                tableLayoutPanelOfCheckpoints.Controls.Add(checkpointNameLabel, 0, i);
                tableLayoutPanelOfCheckpoints.Controls.Add(checkpointDescription, 1, i);
                tableLayoutPanelOfCheckpoints.Controls.Add(checkpointOrder, 2, i);
                tableLayoutPanelOfCheckpoints.Controls.Add(editCheckpointButton, 3, i);
                tableLayoutPanelOfCheckpoints.Controls.Add(deleteCheckpointButton, 4, i);
            }


        }
        private void buttonAddCheckpoint_Click(object sender, EventArgs e)
        {

        }
    }
}
