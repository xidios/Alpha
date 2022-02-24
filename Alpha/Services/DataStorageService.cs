using Alpha.Interfaces;
using Alpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Services
{
    public class DataStorageService
    {
        private DataStorageService() { }
        private static DataStorageService instance = null;
        private JsonDeserializationService jsonDeserializationService = new JsonDeserializationService();
        private JsonSerializationToFileService jsonSerializationToFileService = new JsonSerializationToFileService();
        private List<Alpha> Alphas{ get; set; } = new List<Alpha>();
        private List<AlphaContaiment> AlphaContaiments { get; set; } = new List<AlphaContaiment>();
        private List<State> States { get; set; } = new List<State>();
        private List<Checkpoint> Checkpoints { get; set; } = new List<Checkpoint>();
        private List<WorkProduct> WorkProducts { get; set; } = new List<WorkProduct>();
        private List<LevelOfDetail> LevelOfDetails { get; set; } = new List<LevelOfDetail>();
        private List<Checkpoint> LevelOfDetailCheckpoints { get; set; } = new List<Checkpoint>();
        private List<Activity> Activities { get; set; } = new List<Activity>();
        private List<WorkProductCriterion> WorkProductCriterions { get; set; } = new List<WorkProductCriterion>();
        private List<AlphaCriterion> AlphaCriterions { get; set; } = new List<AlphaCriterion>();
        private List<WorkProductManifest> WorkProductManifests { get; set; } = new List<WorkProductManifest>();
        private List<IDetailing> Details { get; set; } = new List<IDetailing>();

        public List<Alpha> GetAlphas() => Alphas;
        public List<Activity> GetActivities() => Activities;
        public List<WorkProductCriterion> GetWorkProductCriterions() => WorkProductCriterions;
        public List<AlphaCriterion> GetAlphaCriterions() => AlphaCriterions;
        public List<WorkProduct> GetWorkProducts() => WorkProducts;
        public List<WorkProductManifest> GetWorkProductManifests() => WorkProductManifests;
        public static DataStorageService GetInstance()
        {
            if (instance == null)
            {
                instance = new DataStorageService();
                instance.DeserializeAllJsons();
            }
            return instance;
        }
        private void DeserializeAllJsons()
        {
            Alphas = jsonDeserializationService.DeserializeJsonAlphas();
            AlphaContaiments = jsonDeserializationService.DeserializeJsonAlphaContainments(Alphas);
            States = jsonDeserializationService.DeserializeJsonStates(Alphas);
            WorkProducts = jsonDeserializationService.DeserializeJsonWorkProducts();
            LevelOfDetails = jsonDeserializationService.DeserializeJsonLevelOfDetails(WorkProducts);
            Activities = jsonDeserializationService.DeserializeJsonActivities();
            WorkProductManifests = jsonDeserializationService.DeserializeJsonWorkProductManifests(Alphas, WorkProducts);
            WorkProductCriterions = jsonDeserializationService.DeserializeJsonWorkProductCriterions(Activities, LevelOfDetails);
            AlphaCriterions = jsonDeserializationService.DeserializeJsonAlphaCriterions(Activities, States);
            UpdateIDetailsList();
            Checkpoints = jsonDeserializationService.DeserializeJsonCheckpoints(Details);
        }
        private void UpdateIDetailsList()
        {
            foreach (var level in LevelOfDetails)
            {
                Details.Add(level);
            }
            foreach (var state in States)
            {
                Details.Add(state);
            }
        }
        public void AddAlpha(Alpha alpha)
        {
            Alphas.Add(alpha);
            jsonSerializationToFileService.ExportAlphasToFile(Alphas);
        }
        public void UpdateAlphas()
        {
            jsonSerializationToFileService.ExportAlphasToFile(Alphas);
        }
        public void RemoveAlpha(Alpha alpha)
        {            
            List<State> statesForRemove = alpha.GetStates();
            foreach (var state in statesForRemove)
            {
                RemoveCheckpointsByDetail(state);
                States.Remove(state);
                Details.Remove(state);
            }
            Alphas.Remove(alpha);
            jsonSerializationToFileService.ExportAlphasToFile(Alphas);
            jsonSerializationToFileService.ExportStatesToJsonFile(States);
            jsonSerializationToFileService.ExportCheckpointsToJsonFile(Checkpoints);
        }
        public void AddWorkProduct(WorkProduct workProduct)
        {
            WorkProducts.Add(workProduct);
            jsonSerializationToFileService.ExportWorkProductsToJsonFile(WorkProducts);
        }
        public void RemoveWorkProduct(WorkProduct workProduct)
        {
            List<LevelOfDetail> lodForRemove = workProduct.GetLevelOfDetails();
            foreach (var levelOfDetail in lodForRemove)
            {
                RemoveCheckpointsByDetail(levelOfDetail);
                LevelOfDetails.Remove(levelOfDetail);
                Details.Remove(levelOfDetail);
            }
            WorkProducts.Remove(workProduct);
            jsonSerializationToFileService.ExportWorkProductsToJsonFile(WorkProducts);
            jsonSerializationToFileService.ExportLevelOfDetailsToJsonFile(LevelOfDetails);
            jsonSerializationToFileService.ExportCheckpointsToJsonFile(Checkpoints);
        }
        public void UpdateWorkProducts()
        {
            jsonSerializationToFileService.ExportWorkProductsToJsonFile(WorkProducts);
        }
        public void AddAlphaContaiment(AlphaContaiment alphaContaiment)
        {
            AlphaContaiments.Add(alphaContaiment);
            jsonSerializationToFileService.ExportAlphaContainmentsToJsonFile(AlphaContaiments);
        }
        public void RemoveAlphaContaiment(AlphaContaiment alphaContaiment)
        {
            AlphaContaiments.Remove(alphaContaiment);
            jsonSerializationToFileService.ExportAlphaContainmentsToJsonFile(AlphaContaiments);
        }
        public void UpdateAlphaContaiments()
        {
            jsonSerializationToFileService.ExportAlphaContainmentsToJsonFile(AlphaContaiments);
        }
        public void AddAlphaCriterion(AlphaCriterion alphaCriterion)
        {
            AlphaCriterions.Add(alphaCriterion);
            jsonSerializationToFileService.ExportAlphaCriterionsToFile(AlphaCriterions);
        }
        public void RemoveAlphaCriterion(AlphaCriterion alphaCriterion)
        {
            State state = alphaCriterion.GetState();
            state.DeleteAlphaCriterion();
            AlphaCriterions.Remove(alphaCriterion);
            jsonSerializationToFileService.ExportAlphaCriterionsToFile(AlphaCriterions);
        }
        public void UpdateAlphaCriterions()
        {
            jsonSerializationToFileService.ExportAlphaCriterionsToFile(AlphaCriterions);
        }
        public void AddWorkProductManifest(WorkProductManifest workProductManifest)
        {
            WorkProductManifests.Add(workProductManifest);
            jsonSerializationToFileService.ExportWorkProductManifestsToJsonFile(WorkProductManifests);
        }        
        public void RemoveWorkProductManifest(WorkProductManifest workProductManifest)
        {
            WorkProductManifests.Remove(workProductManifest);
            jsonSerializationToFileService.ExportWorkProductManifestsToJsonFile(WorkProductManifests);
        }
        public void UpdateWorkProductManifests()
        {
            jsonSerializationToFileService.ExportWorkProductManifestsToJsonFile(WorkProductManifests);
        }
        public void AddState(State state)
        {

            States.Add(state);
            Details.Add(state);
            jsonSerializationToFileService.ExportStatesToJsonFile(States);
        }
        public void RemoveState(State state)
        {
            RemoveCheckpointsByDetail(state);
            States.Remove(state);
            Details.Remove(state);
            jsonSerializationToFileService.ExportStatesToJsonFile(States);
            jsonSerializationToFileService.ExportCheckpointsToJsonFile(Checkpoints);
        }
        public void UpdateStates()
        {
            jsonSerializationToFileService.ExportStatesToJsonFile(States);
        }
        public void AddCheckpoint(Checkpoint checkpoint)
        {
            Checkpoints.Add(checkpoint);
            jsonSerializationToFileService.ExportCheckpointsToJsonFile(Checkpoints);
        }
        public void RemoveCheckpoint(Checkpoint checkpoint)
        {
            Checkpoints.Remove(checkpoint);
            IDetailing detailing = Details.FirstOrDefault(i => i.GetId() == checkpoint.GetDetailId());
            jsonSerializationToFileService.ExportCheckpointsToJsonFile(Checkpoints);
        }
        public void UpdateCheckpoints()
        {
            jsonSerializationToFileService.ExportCheckpointsToJsonFile(Checkpoints);
        }
        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
            jsonSerializationToFileService.ExportActivitiesToJsonFile(Activities);
        }
        public void UpdateActivities()
        {
            jsonSerializationToFileService.ExportActivitiesToJsonFile(Activities);
        }
        public void RemoveActivity(Activity activity)
        {
            Activities.Remove(activity);
            jsonSerializationToFileService.ExportActivitiesToJsonFile(Activities);
        }

        public void AddWorkProductCriterion(WorkProductCriterion workProductCriterion)
        {
            WorkProductCriterions.Add(workProductCriterion);
            jsonSerializationToFileService.ExportWorkProductCriterionsToFile(WorkProductCriterions);
        }
        public void RemoveWorkProductCriterion(WorkProductCriterion workProductCriterion)
        {
            LevelOfDetail levelOfDetail = workProductCriterion.GetLevelOfDetail();
            levelOfDetail.DeleteWorkProductCriterion();
            WorkProductCriterions.Remove(workProductCriterion);
            jsonSerializationToFileService.ExportWorkProductCriterionsToFile(WorkProductCriterions);
        }
        public void UpdateWorkProductCriterions()
        {
            jsonSerializationToFileService.ExportWorkProductCriterionsToFile(WorkProductCriterions);
        }
        public void AddLevelOfDetail(LevelOfDetail levelOfDetail)
        {
            LevelOfDetails.Add(levelOfDetail);
            Details.Add(levelOfDetail);
            jsonSerializationToFileService.ExportLevelOfDetailsToJsonFile(LevelOfDetails);
        }
        public void RemoveLevelOfDetail(LevelOfDetail levelOfDetail)
        {
            RemoveCheckpointsByDetail(levelOfDetail);
            LevelOfDetails.Remove(levelOfDetail);
            Details.Remove(levelOfDetail);
            jsonSerializationToFileService.ExportLevelOfDetailsToJsonFile(LevelOfDetails);
            jsonSerializationToFileService.ExportCheckpointsToJsonFile(Checkpoints);
        }
        public void UpdateLevelOfDetails()
        {
            jsonSerializationToFileService.ExportLevelOfDetailsToJsonFile(LevelOfDetails);
        }
        public void RemoveCheckpointsByDetail(IDetailing detail)
        {
            List<Checkpoint> checkpointsForRemove = detail.GetCheckpoints();
            foreach (var checkpoint in checkpointsForRemove)
            {
                Checkpoints.Remove(checkpoint);
            }
        }
    }
}
