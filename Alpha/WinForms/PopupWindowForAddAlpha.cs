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
    public partial class PopupWindowForAddAlpha : Form
    {
        private Form1 form1;
        public PopupWindowForAddAlpha(Form1 form)
        {
            InitializeComponent();
            form1 = form;
            var alphasName =  form1.GetListOfAlphas().Select(o => o.Name).ToList();
            foreach (var name in alphasName)
                listBoxAlphas.Items.Add(name);
            

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string alphaName = alphaNameInput.Text;
            Alpha alphaParent = null;
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
            foreach (var a in form1.GetListOfAlphas())
            {
                if (a.Name == alphaName)
                {
                    MessageBox.Show("Alpha with same name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (checkBoxChildAlpha.Checked)
            {               
                var alphaPatentName = listBoxAlphas.Text;
                if(alphaPatentName != null && alphaPatentName != "")
                {
                    var allAlphas = form1.GetListOfAlphas();
                    alphaParent = allAlphas.First(a => a.Name == alphaPatentName); 
                }
            }

            
            Alpha alpha = new Alpha(alphaName, alphaDescription, alphaParent);            
            form1.AddNewAlpha(alpha);
            this.Close();
        }

        private void checkBoxChildAlpha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxChildAlpha.Checked)
            {
                listBoxAlphas.Enabled = true;
            }
            else
            {
                listBoxAlphas.Enabled = false;
            }
        }
    }
}
