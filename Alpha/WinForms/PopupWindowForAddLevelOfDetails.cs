﻿using Alpha.Models;
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

namespace Alpha.WinForms
{
    public partial class PopupWindowForAddLevelOfDetails : Form
    {
        private DataStorageService dataStorageService = DataStorageService.GetInstance();
        private WorkProduct workProduct;
        public PopupWindowForAddLevelOfDetails(WorkProduct workProduct)
        {
            InitializeComponent();
            this.workProduct = workProduct;

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string levelOfDatailName = levelOfDetailNameInput.Text;
            if (levelOfDatailName == null || levelOfDatailName == "")
            {
                MessageBox.Show("Please enter level of detail's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string levelOfDatailDescription = levelOfDetailDescriptionInput.Text;
            if (levelOfDatailDescription == null || levelOfDatailDescription == "")
            {
                MessageBox.Show("Please enter level of detail's description", "Nullable description", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int levelOfDatailOrder = workProduct.GetLevelOfDetails().Count() * 10;
            LevelOfDetail levelOfDetail = new LevelOfDetail(levelOfDatailName, levelOfDatailDescription, levelOfDatailOrder, workProduct);
            workProduct.AddLevelOfDetailToList(levelOfDetail);
            dataStorageService.AddLevelOfDetail(levelOfDetail);
            this.Close();
        }
    }
}
