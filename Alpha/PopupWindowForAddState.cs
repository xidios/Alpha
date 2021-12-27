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
    public partial class PopupWindowForAddState : Form
    {
        Alpha alpha;
        PopupWindowForEditAlpha popupWindowForEditAlpha;
        public PopupWindowForAddState(Alpha alpha, PopupWindowForEditAlpha popupWindowForEditAlpha)
        {
            InitializeComponent();
            this.alpha = alpha;
            this.popupWindowForEditAlpha= popupWindowForEditAlpha;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string stateName = StateNameInput.Text;
            if (stateName == null || stateName == "")
            {
                MessageBox.Show("Please enter state's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string stateDescription = StateDescriptionInput.Text;
            if (stateDescription == null || stateDescription == "")
            {
                MessageBox.Show("Please enter state's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            State state = new State(stateName, stateDescription, alpha);
            alpha.AddState(state);
            popupWindowForEditAlpha.UpdateStatesTable();
            this.Close();
            
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
