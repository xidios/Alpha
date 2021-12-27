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
        public PopupWindowForEditAlpha(Form1 form,Alpha alpha)
        {
            InitializeComponent();
            form1 = form;
            this.alpha = alpha;
            AlphaNameInput.Text = alpha.Name;
            AlphaDescriptionInput.Text = alpha.Description;

            var alphasName = form1.GetListOfAlphas().Select(o => o.Name).ToList();
            foreach (var name in alphasName)
                if(alpha.Name != name)
                    listBoxAlphas.Items.Add(name);

            if(alpha.Parent != null)
            {
                checkBoxChildAlpha.Checked = true;
                listBoxAlphas.Enabled = true;
            }

            this.Text = $"Edit {alpha.Name}";
            UpdateStatesTable();
        }

        public void UpdateStatesTable()
        {
            tableLayoutPanelOfStates.Controls.Clear();

            tableLayoutPanelOfStates.RowCount = alpha.GetStates().Count() + 1;
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
                Text = "Edit",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 2, 0);
            List<State> states = new List<State>();
            states = alpha.GetStates();
            for (int i = 1; i <= states.Count; i++)
            {
                tableLayoutPanelOfStates.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30F));
                State state = states[i - 1];
                Label stateNameLabel = new Label();
                stateNameLabel.Text = state.Name;
                
                Label stateDescription = new Label();
                stateDescription.Text = state.Description;



                tableLayoutPanelOfStates.Controls.Add(stateNameLabel, 0, i);
                tableLayoutPanelOfStates.Controls.Add(stateDescription, 1, i);
            }

        }

            private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string alphaName = AlphaNameInput.Text;
            if (alphaName == null || alphaName == "")
            {
                MessageBox.Show("Please enter alpha's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string alphaDescription = AlphaDescriptionInput.Text;
            if (alphaDescription == null || alphaDescription == "")
            {
                MessageBox.Show("Please enter alpha's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EditAlphaParent();

            foreach (var a in form1.GetListOfAlphas())
            {
                if(alpha.Name == alphaName)
                {
                    alpha.Description = alphaDescription;
                    form1.ExportAlphasToJson();
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
            form1.ExportAlphasToJson();
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
            PopupWindowForAddState popupWindowForAddState = new PopupWindowForAddState(alpha,this);
            popupWindowForAddState.ShowDialog();
        }
    }
}
