using System;
using System.Collections.Generic;
using System.Json;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace Alpha
{
    public partial class Form1 : Form
    {
        private List<Alpha> Alphas = new List<Alpha>();
        private string PathToAlphasFile = "alphas.json";
        public Form1()
        {
            InitializeComponent();
            UpdateAlphasTable();


        }

        public List<Alpha> GetListOfAlphas()
        {
            return Alphas;
        }


        public void UpdateAlphasTable()
        {
            DeserializeJsonToAlphas();
            tableLayoutPanel1.Controls.Clear();

            tableLayoutPanel1.RowCount = Alphas.Count() + 1;
            tableLayoutPanel1.Controls.Add(new Label
            {
                Text = "Alpha",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label
            {
                Text = "Alpha Parent",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label
            {
                Text = "Edit",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 2, 0);
            tableLayoutPanel1.Controls.Add(new Label
            {
                Text = "Delete",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 3, 0);



            for (int i = 1; i <= Alphas.Count; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30F));
                Alpha alpha = Alphas[i - 1];
                

                Button editButton = new Button();
                editButton.Text = "Edit";
                editButton.AccessibleName = (i - 1).ToString();
                editButton.Click += new EventHandler(buttonEdit_Click);

                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.AccessibleName = (i - 1).ToString();
                deleteButton.Click += new EventHandler(buttonDelete_Click);

                Label alphaNameLabel = new Label();
                alphaNameLabel.Text = alpha.Name;

                tableLayoutPanel1.Controls.Add(alphaNameLabel, 0, i);

                if (alpha.Parent != null)
                {
                    Label alphaParentNameLabel = new Label();
                    alphaParentNameLabel.Text = alpha.Parent.Name;
                    tableLayoutPanel1.Controls.Add(alphaParentNameLabel, 1, i);
                }

                tableLayoutPanel1.Controls.Add(editButton, 2, i);
                tableLayoutPanel1.Controls.Add(deleteButton, 3, i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void DeserializeJsonToAlphas()
        {
            if (File.Exists(PathToAlphasFile))
            {
                string jsonString = File.ReadAllText(PathToAlphasFile);
                if (jsonString != null && jsonString != "")
                {
                    Alphas = JsonSerializer.Deserialize<List<Alpha>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
            }
            else
            {
                File.Create(PathToAlphasFile);
            }

        }

        private void AddAlpha_Click(object sender, EventArgs e)
        {
            PopupWindowForAddAlpha popupWindowForAddAlpha = new PopupWindowForAddAlpha(this);
            popupWindowForAddAlpha.ShowDialog();

        }
        public void AddNewAlpha(Alpha alpha)
        {
            Alphas.Add(alpha);
            ExportAlphasToJson();
            UpdateAlphasTable();
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int alphaId = Int32.Parse(b.AccessibleName);
            Alpha alpha = Alphas[alphaId];
            PopupWindowForEditAlpha popupWindowForEditAlpha = new PopupWindowForEditAlpha(this,alpha);
            popupWindowForEditAlpha.ShowDialog();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult == DialogResult.No)
            {
                return;
            }
            Button b = (Button)sender;
            int alphaId = Int32.Parse(b.AccessibleName);
            Alpha alpha = Alphas[alphaId];
            Alphas.Remove(alpha);
            ExportAlphasToJson();
            UpdateAlphasTable();
        }
        public void ExportAlphasToJson()
        {
            var json = JsonSerializer.Serialize(Alphas, new JsonSerializerOptions {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true });
            File.WriteAllText(PathToAlphasFile, json);
        }
    }
}
