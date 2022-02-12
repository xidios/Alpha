﻿using System;
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
    // TODO: Там нужно будет добавить поле, которого не было в исходном, типа степени влияния...
    // TODO: REFACTORING
    // TODO: checkpoint tests
    // TODO: AlphaContainment
    public partial class Form1 : Form
    {
        private List<Alpha> Alphas = new List<Alpha>();
        private List<AlphaContaiment> AlphaContaiments = new List<AlphaContaiment>();
        private string PathToAlphasFile = "alphas.json";
        private string PathToStatesFile = "states.json";
        private string PathToCheckpointsFile = "checkpoints.json";
        private string PathToAlphaContainmentsFile = "alphaContainments.json";
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
            DeserializeJsonFiles();
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
                Text = "More",
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
            //DeserializeJsonAlphaContainments();
        }
        private void DeserializeJsonAlphas()
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
        private void DeserializeJsonStates()
        {
            if (File.Exists(PathToStatesFile))
            {
                string jsonString = File.ReadAllText(PathToStatesFile);
                List<State> states = new List<State>();
                if (jsonString != null && jsonString != "")
                {
                    states = JsonSerializer.Deserialize<List<State>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                foreach (var state in states)
                {
                    Alpha alpha = Alphas.First(a => a.Id == state.AlphaId);
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
                File.Create(PathToStatesFile);
            }
        }
        private void DeserializeJsonCheckpoints(List<State> states)
        {
            if (File.Exists(PathToCheckpointsFile))
            {
                string jsonString = File.ReadAllText(PathToCheckpointsFile);
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
                File.Create(PathToStatesFile);
            }
        }

        private void DeserializeJsonAlphaContainments()
        {
            if (File.Exists(PathToAlphaContainmentsFile))
            {
                string jsonString = File.ReadAllText(PathToAlphaContainmentsFile);
                if (jsonString != null && jsonString != "")
                {
                    AlphaContaiments = JsonSerializer.Deserialize<List<AlphaContaiment>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                foreach (var alphaContaiment in AlphaContaiments)
                {
                    Alpha supAlpha = Alphas.First(a => a.Id == alphaContaiment.GetSupAlphaId());
                    Alpha subAlpha = Alphas.First(a => a.Id == alphaContaiment.GetSubAlphaId());
                    if(supAlpha != null)
                    {
                        supAlpha.SetAlphaContainment(alphaContaiment);
                    }
                    if (supAlpha != null && subAlpha != null)
                    {
                        alphaContaiment.SetSupAlpha(supAlpha);
                        alphaContaiment.SetSubAlpha(subAlpha);
                    }
                }
            }
            else
            {
                File.Create(PathToAlphaContainmentsFile);
            }
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
            foreach (var alpha in Alphas)
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
            Alphas.Add(alpha);
            ExportAllToJsonFiles();
            UpdateAlphasTable();
        }
        // TODO: edit by AlphaId
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int alphaId = Int32.Parse(b.AccessibleName);
            Alpha alpha = Alphas[alphaId];
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
            Alpha alpha = Alphas.First(a=>a.GetAlphaId()==alphaId);
            if(alpha == null)
            {
                MessageBox.Show("Some problems with alpha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Alphas.Remove(alpha);
            ExportAllToJsonFiles();
            UpdateAlphasTable();
        }
        // TODO: split this method
        public void ExportAllToJsonFiles()
        {
            var jsonAlphas = JsonSerializer.Serialize(Alphas, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(PathToAlphasFile, jsonAlphas);

            SortAlphasStatesByOrder();
            List<State> states = GetAllStates();
            var jsonStates = JsonSerializer.Serialize(states, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(PathToStatesFile, jsonStates);

            SortStatesCheckpointsByOrder(states);
            List<Checkpoint> checkpoints = GetAllCheckpoints(states);
            var jsonCheckpoints = JsonSerializer.Serialize(checkpoints, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(PathToCheckpointsFile, jsonCheckpoints);

            var jsonAlphaContainments = JsonSerializer.Serialize(AlphaContaiments, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(PathToAlphaContainmentsFile, jsonAlphaContainments);
        }
        // TODO интерфейс для GetAll
        private List<State> GetAllStates()
        {
            List<State> states = new List<State>();
            foreach (var alpha in Alphas)
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
    }
}
