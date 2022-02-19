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
using Alpha.Models;
using Alpha.WinForms;
using Alpha.Services;
using Alpha.Interfaces;

namespace Alpha
{
    public partial class Form1 : Form, IMainFormInterface
    {
        private List<Alpha> alphas = new List<Alpha>();
        private List<AlphaContaiment> alphaContaiments = new List<AlphaContaiment>();
        private List<WorkProduct> workProducts = new List<WorkProduct>();
        private List<WorkProductManifest> workProductManifests = new List<WorkProductManifest>();
        private List<Activity> activities = new List<Activity>();
        private List<AlphaCriterion> alphaCriterions = new List<AlphaCriterion>();
        private JsonDeserializationService jsonDeserializationService = new JsonDeserializationService();
        private JsonSerializationToFileService jsonSerializationToFileService = new JsonSerializationToFileService();        
        public Form1()
        {
            InitializeComponent();
            UpdateAlphasTable();
        }
        public void AddAlphaCriterion(AlphaCriterion alphaCriterion)
        {
            alphaCriterions.Add(alphaCriterion);
            jsonSerializationToFileService.ExportAlphaCriterionsToFile(alphaCriterions);
        }
        public void DeleteAlphaCriterion(AlphaCriterion alphaCriterion)
        {
            alphaCriterions.Remove(alphaCriterion);
            ExportAllToJsonFiles();
        }
        public List<Activity> GetAllActivities() => activities; 
        

        public List<Alpha> GetListOfAlphas() => alphas;

        public List<WorkProduct> GetListOfWorkProducts() => workProducts;
        public void AddAlphaConteinment(AlphaContaiment alphaContaiment)
        {
            alphaContaiments.Add(alphaContaiment);
            ExportAllToJsonFiles();
        }
        public void ExportWorkProductManifestsToJsonFile()
        {
            jsonSerializationToFileService.ExportWorkProductManifestsToJsonFile(workProductManifests);
        }
        public void AddWorkProductManifest(WorkProductManifest workProductManifest)
        {
            workProductManifests.Add(workProductManifest);
            ExportWorkProductManifestsToJsonFile();
        }
        public void DeleteAlphaConteinmentFromList(AlphaContaiment alphaContaiment)
        {
            alphaContaiments.Remove(alphaContaiment);
            ExportAllToJsonFiles();
        }
        public void DeleteWorkProductManifestFromList(WorkProductManifest workProductManifest)
        {
            workProductManifests.Remove(workProductManifest);
            ExportAllToJsonFiles();
        }

        public void ExportAllAlphaCriterionsToFile()
        {
            jsonSerializationToFileService.ExportAlphaCriterionsToFile(alphaCriterions);
        }
        public void UpdateAlphasTable()
        {
            DeserializeJsonFiles();
            tableLayoutPanel1.Controls.Clear();

            tableLayoutPanel1.RowCount = alphas.Count() + 1;
            tableLayoutPanel1.Controls.Add(new Label
            {
                Text = "Alpha",
                Font = new Font(Label.DefaultFont, FontStyle.Bold),
                Size = new Size(200,20)
            }, 0, 0);
            tableLayoutPanel1.Controls.Add(new Label
            {
                Text = "Alpha Parent",
                Font = new Font(Label.DefaultFont, FontStyle.Bold),
                Size = new Size(200, 20)
            }, 1, 0);
            tableLayoutPanel1.Controls.Add(new Label
            {
                Text = "More",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 2, 0);
            tableLayoutPanel1.Controls.Add(new Label
            {
                Text = "Delete",
                Font = new Font(Label.DefaultFont, FontStyle.Bold)
            }, 3, 0);

            for (int i = 1; i <= alphas.Count; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 30F));
                Alpha alpha = alphas[i - 1];
                Guid alphaId = alpha.GetAlphaId();

                Button editButton = new Button();
                editButton.Text = "Edit";
                editButton.AccessibleName = alphaId.ToString();
                editButton.Click += new EventHandler(buttonEdit_Click);

                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.AccessibleName = alphaId.ToString();
                deleteButton.Click += new EventHandler(buttonDelete_Click);

                Label alphaNameLabel = new Label();
                alphaNameLabel.AutoSize = true;
                alphaNameLabel.Text = alpha.Name;

                tableLayoutPanel1.Controls.Add(alphaNameLabel, 0, i);

                if (alpha.ParentAlphaId != null)
                {
                    Label alphaParentNameLabel = new Label();
                    alphaParentNameLabel.Text = alpha.GetAlphaParent().GetName();
                    alphaParentNameLabel.AutoSize = true;
                    tableLayoutPanel1.Controls.Add(alphaParentNameLabel, 1, i);
                }

                tableLayoutPanel1.Controls.Add(editButton, 2, i);
                tableLayoutPanel1.Controls.Add(deleteButton, 3, i);
            }
        }

        private void DeserializeJsonFiles()
        {
            alphas = jsonDeserializationService.DeserializeJsonAlphas();
            activities = jsonDeserializationService.DeserializeJsonActivities();
            jsonDeserializationService.DeserializeJsonStates(alphas);
            alphaContaiments = jsonDeserializationService.DeserializeJsonAlphaContainments(alphas);
            DeserializeJsonWorkProducts();
            workProductManifests = jsonDeserializationService.DeserializeJsonWorkProductManifests(alphas, workProducts);
            alphaCriterions = jsonDeserializationService.DeserializeJsonAlphaCriterions(activities, GetAllStates());
        }

         
        private void DeserializeJsonWorkProducts()
        {
            workProducts = jsonDeserializationService.DeserializeJsonWorkProducts();
        }       
        private void AddAlpha_Click(object sender, EventArgs e)
        {
            PopupWindowForAddAlpha popupWindowForAddAlpha = new PopupWindowForAddAlpha(this);
            popupWindowForAddAlpha.ShowDialog();

        }
        public void AddNewAlpha(Alpha alpha)
        {
            alphas.Add(alpha);
            ExportAllToJsonFiles();
            UpdateAlphasTable();
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Guid alphaId = Guid.Parse(b.AccessibleName);
            Alpha alpha = alphas.FirstOrDefault(a => a.GetAlphaId() == alphaId);
            if (alpha == null)
            {
                MessageBox.Show("Some problems with alpha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PopupWindowForEditAlpha popupWindowForEditAlpha = new PopupWindowForEditAlpha(this, alpha);
            popupWindowForEditAlpha.ShowDialog();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            Button b = (Button)sender;
            Guid alphaId = Guid.Parse(b.AccessibleName);
            Alpha alpha = alphas.FirstOrDefault(a => a.GetAlphaId() == alphaId);
            if (alpha == null)
            {
                MessageBox.Show("Some problems with alpha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RemoveFromAlphaContains(alpha);
            RemoveFromWokrProductManifests(alpha);
            RemoveFromAlphaCriterion(alpha);
            alphas.Remove(alpha);
            ExportAllToJsonFiles();
            UpdateAlphasTable();
        }
        private void RemoveFromAlphaCriterion(Alpha alpha)
        {
            List<State> states = alpha.GetStates();
            foreach (var state in states)
            {
                var alphaCriterion = state.GetAlphaCriterion();
                alphaCriterions.Remove(alphaCriterion);
            }
        }
        private void RemoveFromAlphaContains(Alpha alpha)
        {
            foreach (var subordinateAlphaContaimnent in alpha.GetSubordinateAlphaConteinments())
            {
                alphaContaiments.Remove(subordinateAlphaContaimnent);
            }
            alphaContaiments.Remove(alpha.GetSupperAlphaContainment());
        }
        private void RemoveFromWokrProductManifests(Alpha alpha)
        {
            workProductManifests.Remove(alpha.GetWorkProductManifest());
        }
        // TODO: split this method
        public void ExportAllToJsonFiles()
        {
            jsonSerializationToFileService.ExportAlphasToFile(alphas);
            List<State> states = GetAllStates();
            jsonSerializationToFileService.ExportStatesToJsonFile(states);
            List<Checkpoint> checkpoints = GetAllCheckpoints(states);
            jsonSerializationToFileService.ExportCheckpointsToJsonFile(checkpoints);
            jsonSerializationToFileService.ExportAlphaContainmentsToJsonFile(alphaContaiments);
            jsonSerializationToFileService.ExportWorkProductManifestsToJsonFile(workProductManifests);
            jsonSerializationToFileService.ExportAlphaCriterionsToFile(alphaCriterions);
        }
        private List<State> GetAllStates()
        {
            List<State> states = new List<State>();
            foreach (var alpha in alphas)
            {
                states.AddRange(alpha.GetStates());
            }
            return states;
        }

        private List<Checkpoint> GetAllCheckpoints(List<State> states)
        {
            List<Checkpoint> checkpoints = new List<Checkpoint>();
            foreach (var state in states)
            {
                checkpoints.AddRange(state.GetCheckpoints());
            }
            return checkpoints;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
