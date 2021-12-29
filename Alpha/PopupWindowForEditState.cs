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
    public partial class PopupWindowForEditState : Form
    {
        State state;
        Form1 form1;
        PopupWindowForEditAlpha popupWindowForEditAlpha;
        public PopupWindowForEditState(State state, Form1 form1, PopupWindowForEditAlpha popupWindowForEditAlpha)
        {
            InitializeComponent();
            this.state = state;
            this.form1 = form1;
            this.popupWindowForEditAlpha = popupWindowForEditAlpha;
            this.Text = $"Edit {state.Name}";
            stateNameInput.Text = state.Name;
            stateDescriptionInput.Text = state.Description;
            stateOrderInput.Text = state.Order.ToString();
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
    }
}
