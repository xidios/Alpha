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

namespace Alpha
{
    public partial class PopupWindowForAddState : Form
    {
        Alpha alpha;
        DataStorageService dataStorageService = DataStorageService.GetInstance();
        public PopupWindowForAddState(Alpha alpha)
        {
            InitializeComponent();
            this.alpha = alpha;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
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
            int stateOrder = alpha.GetStates().Count() * 10;
            State state = new State(stateName, stateDescription, stateOrder, alpha);
            alpha.AddState(state);
            dataStorageService.AddState(state);
            this.Close();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
