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
    public partial class PopupWindowForEditAlpha : Form
    {
        private Form1 form1;
        private Alpha alpha;
        private Alpha alphaParent;
        public PopupWindowForEditAlpha(Form1 form, Alpha alpha)
        {
            InitializeComponent();
            form1 = form;
            this.alpha = alpha;
            alphaNameInput.Text = alpha.Name;
            alphaDescriptionInput.Text = alpha.Description;

            var alphasName = form1.GetListOfAlphas().Select(o => o.Name).ToList();
            foreach (var name in alphasName)
                if (alpha.Name != name)
                    listBoxAlphas.Items.Add(name);

            if (alpha.Parent != null)
            {
                checkBoxChildAlpha.Checked = true;
                listBoxAlphas.Enabled = true;
            }

            this.Text = $"Edit {alpha.Name}";
            UpdateStatesTable();
        }

        public void UpdateStatesTable()
        {
            form1.ExportAllToJsonFiles();
            tableLayoutPanelOfStates.Controls.Clear();

            tableLayoutPanelOfStates.RowCount = alpha.GetStates().Count() + 1; //не бейте
            tableLayoutPanelOfStates.Controls.Add(new Label
            {
                Text = "State",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 0, 0);
            tableLayoutPanelOfStates.Controls.Add(new Label
            {
                Text = "Description",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 1, 0);
            tableLayoutPanelOfStates.Controls.Add(new Label
            {
                Text = "Orders",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 2, 0);
            tableLayoutPanelOfStates.Controls.Add(new Label
            {
                Text = "Checkpoints",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 3, 0);
            tableLayoutPanelOfStates.Controls.Add(new Label
            {
                Text = "Edit",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 4, 0);
            tableLayoutPanelOfStates.Controls.Add(new Label
            {
                Text = "Delete",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 5, 0);
            List<State> states = alpha.GetStates();
            for (int i = 1; i <= states.Count; i++)
            {
                tableLayoutPanelOfStates.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30F));
                State state = states[i - 1];
                Guid stateId = state.GetStateId();
                Label stateNameLabel = new Label();
                stateNameLabel.Text = state.Name;

                Label stateDescription = new Label();
                stateDescription.Text = state.Description;

                Label stateOrder = new Label();
                stateOrder.Text = state.Order.ToString();

                Button openCheckpointsButton = new Button();
                openCheckpointsButton.Text = "Open";
                openCheckpointsButton.AccessibleName = stateId.ToString();
                openCheckpointsButton.Click += new EventHandler(buttonOpenCheckpointTable_Click);

                Button deleteStateButton = new Button();
                deleteStateButton.Text = "Delete";
                deleteStateButton.AccessibleName = stateId.ToString();
                deleteStateButton.Click += new EventHandler(buttonDeleteState_Click);

                Button edirStateButton = new Button();
                edirStateButton.Text = "Edit";
                edirStateButton.AccessibleName = stateId.ToString();
                edirStateButton.Click += new EventHandler(buttonEditState_Click);


                tableLayoutPanelOfStates.Controls.Add(stateNameLabel, 0, i);
                tableLayoutPanelOfStates.Controls.Add(stateDescription, 1, i);
                tableLayoutPanelOfStates.Controls.Add(stateOrder, 2, i);
                tableLayoutPanelOfStates.Controls.Add(openCheckpointsButton, 3, i);
                tableLayoutPanelOfStates.Controls.Add(edirStateButton, 4, i);
                tableLayoutPanelOfStates.Controls.Add(deleteStateButton, 5, i);
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string alphaName = alphaNameInput.Text;
            if (alphaName == null || alphaName == "")
            {
                MessageBox.Show("Please enter alpha's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string alphaDescription = alphaDescriptionInput.Text;
            if (alphaDescription == null || alphaDescription == "")
            {
                MessageBox.Show("Please enter alpha's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EditAlphaParent();

            foreach (var a in form1.GetListOfAlphas())
            {
                if (alpha.Name == alphaName)
                {
                    alpha.Description = alphaDescription;
                    form1.ExportAllToJsonFiles();
                    form1.UpdateAlphasTable();
                    this.Close();
                    return;
                }
                if (a.Name == alphaName)
                {
                    MessageBox.Show("Alpha with same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            alpha.Name = alphaName;
            alpha.Description = alphaDescription;
            form1.ExportAllToJsonFiles();
            form1.UpdateAlphasTable();
            this.Close();
        }

        private void checkBoxChildAlpha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxChildAlpha.Checked)
            {
                listBoxAlphas.Enabled = true;
                alphaParent = alpha.Parent;
            }
            else
            {
                listBoxAlphas.Enabled = false;
                alphaParent = null;
            }
        }
        private void EditAlphaParent()
        {
            if (checkBoxChildAlpha.Checked)
            {
                var alphaPatentName = listBoxAlphas.Text;
                if (alphaPatentName != null && alphaPatentName != "")
                {
                    var allAlphas = form1.GetListOfAlphas();
                    alphaParent = allAlphas.First(a => a.Name == alphaPatentName);
                    alpha.Parent = alphaParent;
                }
            }
            else
            {
                alpha.Parent = null;
            }
        }

        private void buttonAddState_Click(object sender, EventArgs e)
        {
            PopupWindowForAddState popupWindowForAddState = new PopupWindowForAddState(alpha, this);
            popupWindowForAddState.ShowDialog();
        }
        private void buttonOpenCheckpointTable_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Guid stateId = Guid.Parse(b.AccessibleName);
            List<State> alphaStates = alpha.GetStates();
            var state = alphaStates.First(s => s.GetStateId() == stateId);
            if (state == null)
            {
                MessageBox.Show("Some problems with state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void buttonEditState_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Guid stateId = Guid.Parse(b.AccessibleName);
            List<State> states = alpha.GetStates();
            State state = states.First(s => s.GetStateId() == stateId);
            if (state == null)
            {
                MessageBox.Show("Some problems with state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PopupWindowForEditState popupWindowForEditState = new PopupWindowForEditState(state,form1,this);
            popupWindowForEditState.ShowDialog();
        }
        private void buttonDeleteState_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            Button b = (Button)sender;
            Guid stateId = Guid.Parse(b.AccessibleName);
            List<State> states = alpha.GetStates();
            State state = states.First(s => s.GetStateId() == stateId);
            if (state == null)
            {
                MessageBox.Show("Some problems with state", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            states.Remove(state);
            form1.ExportAllToJsonFiles();
            UpdateStatesTable();
        }
    }
}
