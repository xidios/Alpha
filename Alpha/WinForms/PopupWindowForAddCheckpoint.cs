﻿using System;
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
    public partial class PopupWindowForAddCheckpoint : Form
    {
        State state;
        PopupWindowForCheckpointsTable popupWindowForCheckpointsTable;
        public PopupWindowForAddCheckpoint(PopupWindowForCheckpointsTable popupWindowForCheckpointsTable, State state)
        {
            this.popupWindowForCheckpointsTable = popupWindowForCheckpointsTable;
            this.state = state;
            this.Text = $"Add checkpoint for {state.Name}";
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string stateName = checkpointNameInput.Text;
            if (stateName == null || stateName == "")
            {
                MessageBox.Show("Please enter checkpoint's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string stateDescription = checkpointDescriptionInput.Text;
            if (stateDescription == null || stateDescription == "")
            {
                MessageBox.Show("Please enter checkpoint's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int stateOrder = state.GetCheckpoints().Count() * 10;
            Checkpoint checkpoint = new Checkpoint(stateName, stateDescription, stateOrder, state);
            state.AddCheckpoint(checkpoint);
            popupWindowForCheckpointsTable.UpdateCheckpointsTable();
            this.Close();
        }
    }
}