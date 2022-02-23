using Alpha.Services;
using Alpha.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alpha.Interfaces;
using Alpha.Enums;

namespace Alpha.WinForms
{

    public partial class PopupWindowForAddDegreeOfEvidence : Form
    {
        private Checkpoint checkpoint;
        private List<LevelOfDetail> levelOfDetails;
        private List<State> states;
        private List<Checkpoint> checkpoints;
        private List<ICheckable> icheckables = new List<ICheckable>();
        private JsonDeserializationService jsonDeserializationService = new JsonDeserializationService();
        private JsonSerializationToFileService JsonSerializationToFileService = new JsonSerializationToFileService();
        public PopupWindowForAddDegreeOfEvidence(Checkpoint checkpoint)
        {
            InitializeComponent();
            DeserealizeICheckable();
            this.checkpoint = checkpoint;
            BindListBox();
            BindComboboxWithEnum();
        }
        private void BindListBox()
        {
            listBoxOfICheckable.DataSource = icheckables;
            listBoxOfICheckable.DisplayMember = "Name";
            listBoxOfICheckable.ValueMember = "Id";
        }
        private void BindComboboxWithEnum()
        {
            comboBoxDegreeOfEvidence.DataSource = Enum.GetValues(typeof(DegreeOfEvidenceEnum));
        }
        private void DeserealizeICheckable()
        {
            levelOfDetails = jsonDeserializationService.DeserializeJsonLevelOfDetails(new List<WorkProduct>());
            states = jsonDeserializationService.DeserializeJsonStates(new List<Alpha>());
            List<IDetailing> idetails = new List<IDetailing>();
            idetails.AddRange(levelOfDetails);
            idetails.AddRange(states);
            checkpoints = GetAllCheckpointsOfStates(idetails);
            icheckables.AddRange(checkpoints);
            icheckables.AddRange(states);
            icheckables.AddRange(levelOfDetails);
        }
        private List<Checkpoint> GetAllCheckpointsOfStates(List<IDetailing> details)
        {
            List<Checkpoint> checkpointsTemp = new List<Checkpoint>();
            foreach (var detail in details)
            {
                checkpointsTemp.AddRange(detail.GetCheckpoints());
            }
            return checkpointsTemp;
        }
        private List<DegreeOfEvidence> GetAllDegreesOfEvidence(List<Checkpoint> checkpoints)
        {
            List<DegreeOfEvidence> degreesOfEvidenceTemp = new List<DegreeOfEvidence>();
            foreach (var checkpoint in checkpoints)
            {
                degreesOfEvidenceTemp.AddRange(checkpoint.GetDegreeOfEvidences());
            }
            return degreesOfEvidenceTemp;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var icheckable = listBoxOfICheckable.SelectedItem;
            if (icheckable == null)
            {
                MessageBox.Show("Please choose ichekable", "Nullable icheckable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ICheckable icheckableCopy = (ICheckable)icheckable;
            string icheckableName = icheckableCopy.GetName();
            if (icheckableName == null || icheckableName == "")
            {
                MessageBox.Show("Please enter ichekable's name", "Nullable name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool typeOfEvidenceBool = checkBoxTypeOfEvidence.Checked;

            DegreeOfEvidenceEnum degreeOfEvidenceEnum;
            Enum.TryParse<DegreeOfEvidenceEnum>(comboBoxDegreeOfEvidence.SelectedValue.ToString(), out degreeOfEvidenceEnum);
            DegreeOfEvidence degreeOfEvidence = new DegreeOfEvidence(checkpoint,icheckableCopy, icheckableName, typeOfEvidenceBool, degreeOfEvidenceEnum);
            checkpoint.AddDegreeOfEvidence(degreeOfEvidence);
            // костыль, тк у нас создается копия листа изначально, то нужно дважды в чекпоинты добавить наш degree TODO: singleton чтобы пофиксить этот костыль
            var checkpointTemp = checkpoints.FirstOrDefault(c => c.GetId() == checkpoint.GetId());
            checkpointTemp.AddDegreeOfEvidence(degreeOfEvidence);
            //
            JsonSerializationToFileService.ExportDegreesOfEvidenceToJsonFile(GetAllDegreesOfEvidence(checkpoints));
            this.Close();
        }
    }
}
