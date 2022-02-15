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

namespace Alpha
{
    // TODO: Там нужно будет добавить поле, которого не было в исходном, типа степени влияния...
    // TODO: REFACTORING
    // TODO: checkpoint tests
    // TODO: AlphaContainment tests
    public partial class Form1 : Form
    {
        private List<Alpha> alphas = new List<Alpha>();
        private List<AlphaContaiment> alphaContaiments = new List<AlphaContaiment>();
        private List<WorkProduct> workProducts = new List<WorkProduct>();
        private List<WorkProductManifest> workProductManifests = new List<WorkProductManifest>();
        private string pathToAlphasFile = "alphas.json";
        private string pathToStatesFile = "states.json";
        private string pathToCheckpointsFile = "checkpoints.json";
        private string pathToAlphaContainmentsFile = "alphaContainments.json";
        public static string pathToWorkProductManifest = "workProductManifests.json";
        public Form1()
        {
            InitializeComponent();
            UpdateAlphasTable();
        }

        public List<Alpha> GetListOfAlphas() => alphas;
        
        public List<WorkProduct> GetListOfWorkProducts() => workProducts;
        public void AddAlphaConteinment(AlphaContaiment alphaContaiment)
        {
            alphaContaiments.Add(alphaContaiment);
            ExportAllToJsonFiles();
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


        public void UpdateAlphasTable()
        {
            DeserializeJsonFiles();
            tableLayoutPanel1.Controls.Clear();

            tableLayoutPanel1.RowCount = alphas.Count() + 1;
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
                editButton.AccessibleName = (i - 1).ToString();
                editButton.Click += new EventHandler(buttonEdit_Click);

                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.AccessibleName = alphaId.ToString();
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

        private void DeserializeJsonFiles()
        {
            DeserializeJsonAlphas();
            DeserializeJsonStates();
            DeserializeJsonAlphaContainments();
            DeserializeJsonWorkProducts();
            DeserializeJsonWorkProductManifest();
        }
        private void DeserializeJsonAlphas()
        {
            if (File.Exists(pathToAlphasFile))
            {
                string jsonString = File.ReadAllText(pathToAlphasFile);
                if (jsonString != null && jsonString != "")
                {
                    alphas = JsonSerializer.Deserialize<List<Alpha>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
            }
            else
            {
                using (File.Create(pathToAlphasFile)) { }
            }
        }
        private void DeserializeJsonStates()
        {
            if (File.Exists(pathToStatesFile))
            {
                string jsonString = File.ReadAllText(pathToStatesFile);
                List<State> states = new List<State>();
                if (jsonString != null && jsonString != "")
                {
                    states = JsonSerializer.Deserialize<List<State>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                foreach (var state in states)
                {
                    Alpha alpha = alphas.First(a => a.Id == state.AlphaId);
                    if (alpha != null)
                    {
                        alpha.AddState(state);
                    }
                }
                SortAlphasStatesByOrder();
                DeserializeJsonCheckpoints(states);
            }
            else
            {
                using (File.Create(pathToStatesFile)) { }
            }
        }
        private void DeserializeJsonCheckpoints(List<State> states)
        {
            if (File.Exists(pathToCheckpointsFile))
            {
                string jsonString = File.ReadAllText(pathToCheckpointsFile);
                List<Checkpoint> checkpoints = new List<Checkpoint>();
                if (jsonString != null && jsonString != "")
                {
                    checkpoints = JsonSerializer.Deserialize<List<Checkpoint>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                foreach (var checkpoint in checkpoints)
                {
                    State state = states.First(s => s.Id == checkpoint.StateId);
                    if (state != null)
                    {
                        state.AddCheckpoint(checkpoint);
                    }
                }
                SortStatesCheckpointsByOrder(states);
            }
            else
            {
                using (File.Create(pathToStatesFile)) { }
            }
        }
        
        private void DeserializeJsonAlphaContainments()
        {
            if (File.Exists(pathToAlphaContainmentsFile))
            {
                string jsonString = File.ReadAllText(pathToAlphaContainmentsFile);
                if (jsonString != null && jsonString != "")
                {
                    alphaContaiments = JsonSerializer.Deserialize<List<AlphaContaiment>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                foreach (var alphaContaiment in alphaContaiments)
                {
                    Alpha supAlpha = alphas.FirstOrDefault(a => a.Id == alphaContaiment.GetSupAlphaId());
                    Alpha subAlpha = alphas.FirstOrDefault(a => a.Id == alphaContaiment.GetSubAlphaId());
                    //if(supAlpha != null)
                    //{
                    //    supAlpha.SetSupperAlphaContainment(alphaContaiment);
                    //}
                    if (supAlpha != null && subAlpha != null)
                    {
                        alphaContaiment.SetSupAlpha(supAlpha);
                        alphaContaiment.SetSubAlpha(subAlpha);
                    }
                }
            }
            else
            {
                using (File.Create(pathToAlphaContainmentsFile)) { }
            }
        }

        private void DeserializeJsonWorkProductManifest()
        {
            if (File.Exists(pathToWorkProductManifest))
            {
                string jsonString = File.ReadAllText(pathToWorkProductManifest);
                if (jsonString != null && jsonString != "")
                {
                    workProductManifests = JsonSerializer.Deserialize<List<WorkProductManifest>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                foreach (var workProductManifest in workProductManifests)
                {
                    Alpha alpha = alphas.FirstOrDefault(a => a.Id == workProductManifest.GetAlphaId());
                    WorkProduct workProduct = workProducts.FirstOrDefault(a => a.Id == workProductManifest.GetWorkProductId());
                    if(workProduct != null && alpha != null)
                    {
                        workProductManifest.SetWorkProduct(workProduct);
                        workProductManifest.SetAlpha(alpha);
                    }
                }
            }
            else
            {
                using (File.Create(pathToWorkProductManifest)) { }
            }
        }
        private void DeserializeJsonWorkProducts()
        {
            workProducts = WorkProductsTable.DeserializeJsonWorkProducts();
        }
        // TODO: добавить интерфейс для Alpha и State, чтобы через дженерик метод вызывать сортировку
        private void SortStatesCheckpointsByOrder(List<State> states)
        {
            foreach (var state in states)
            {
                state.SortListOfCheckpointsByOrder();
            }
        }
        private void SortAlphasStatesByOrder()
        {
            foreach (var alpha in alphas)
            {
                alpha.SortListOfStatesByOrder();
            }
        }
        //
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
        // TODO: edit by AlphaId
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int alphaId = Int32.Parse(b.AccessibleName);
            Alpha alpha = alphas[alphaId];
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
            Alpha alpha = alphas.FirstOrDefault(a=>a.GetAlphaId()==alphaId);
            if(alpha == null)
            {
                MessageBox.Show("Some problems with alpha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RemoveFromAlphaContains(alpha);
            RemoveFromWokrProductManifests(alpha);
            alphas.Remove(alpha);
            ExportAllToJsonFiles();
            UpdateAlphasTable();
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
            var jsonAlphas = JsonSerializer.Serialize(alphas, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(pathToAlphasFile, jsonAlphas);

            SortAlphasStatesByOrder();
            List<State> states = GetAllStates();
            var jsonStates = JsonSerializer.Serialize(states, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(pathToStatesFile, jsonStates);

            SortStatesCheckpointsByOrder(states);
            List<Checkpoint> checkpoints = GetAllCheckpoints(states);
            var jsonCheckpoints = JsonSerializer.Serialize(checkpoints, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(pathToCheckpointsFile, jsonCheckpoints);

            var jsonAlphaContainments = JsonSerializer.Serialize(alphaContaiments, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(pathToAlphaContainmentsFile, jsonAlphaContainments);

            ExportWorkProductManifestsToJsonFile();
        }
        public void ExportWorkProductManifestsToJsonFile()
        {
            var jsonWorkProducts = JsonSerializer.Serialize(workProductManifests, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(pathToWorkProductManifest, jsonWorkProducts);
        }
        // TODO интерфейс для GetAll
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
