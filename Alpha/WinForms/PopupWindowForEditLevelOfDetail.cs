using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alpha.Models;

namespace Alpha.WinForms
{
    public partial class PopupWindowForEditLevelOfDetail : Form
    {
        LevelOfDetail levelOfDetail;
        PopupWindowForEditWorkProduct popupWindowForEditWork;
        public PopupWindowForEditLevelOfDetail(PopupWindowForEditWorkProduct popupWindowForEditWork, LevelOfDetail levelOfDetail)
        {
            InitializeComponent();
            this.levelOfDetail = levelOfDetail; 
            this.popupWindowForEditWork = popupWindowForEditWork;
            this.Text = $"Edit {levelOfDetail.GetName()}";
            levelOfDetailNameInput.Text = levelOfDetail.GetName();
            levelOfDetailDescriptionInput.Text = levelOfDetail.GetDescription();
            levelOfDetailOrderInput.Text = levelOfDetail.GetOrder().ToString();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string levelOfDetailName = levelOfDetailNameInput.Text;
            if (levelOfDetailName == null || levelOfDetailName == "")
            {
                MessageBox.Show("Please enter level of detail's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string levelOfDetailDescription = levelOfDetailDescriptionInput.Text;
            if (levelOfDetailDescription == null || levelOfDetailDescription == "")
            {
                MessageBox.Show("Please enter level of detail's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string levelOfDetailOdred = levelOfDetailOrderInput.Text;
            if (levelOfDetailOdred == null || levelOfDetailOdred == "")
            {
                MessageBox.Show("Please enter level of detail's order", "Nullable order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            levelOfDetail.Name = levelOfDetailName;
            levelOfDetail.Description = levelOfDetailDescription;
            levelOfDetail.Order = Int32.Parse(levelOfDetailOdred);
            popupWindowForEditWork.UpdateLevelOfDetailsTable();
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
