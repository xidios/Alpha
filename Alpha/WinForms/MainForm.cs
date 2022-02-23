using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alpha.Services;

namespace Alpha.WinForms
{
    public partial class MainForm : Form
    {
        //DataStorageService dataStorageService = DataStorageService.GetInstance();
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOpenAlphasTable_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }

        private void buttonOpenWPTable_Click(object sender, EventArgs e)
        {
            new WorkProductsTable().ShowDialog();
        }

        private void buttonOpenActivitiesTable_Click(object sender, EventArgs e)
        {
            new ActivitiesTable().ShowDialog();
        }
    }
}
