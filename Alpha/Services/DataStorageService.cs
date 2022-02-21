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
        private List<Alpha> Alphas{ get; set; } = new List<Alpha>();
        private List<AlphaContaiment> AlphaContaiments { get; set; } = new List<AlphaContaiment>();
        private List<State> States { get; set; } = new List<State>();
        private List<Checkpoint> StateCheckpoint { get; set; } = new List<Checkpoint>();
        private List<WorkProduct> WorkProducts { get; set; } = new List<WorkProduct>();
        private List<LevelOfDetail> LevelOfDetails { get; set; } = new List<LevelOfDetail>();
        private List<Checkpoint> LevelOfDetailCheckpoints { get; set; } = new List<Checkpoint>();
        private List<Activity> Activities { get; set; } = new List<Activity>();
        private List<WorkProductCriterion> WorkProductCriterions { get; set; } = new List<WorkProductCriterion>();
        private List<AlphaCriterion> AlphaCriterions { get; set; } = new List<AlphaCriterion>();
        private List<WorkProductManifest> WorkProductManifests { get; set; } = new List<WorkProductManifest>();

        public List<Activity> GetActivities() => Activities;
        public List<WorkProductCriterion> GetWorkProductCriterions() => WorkProductCriterions;
        public List<AlphaCriterion> GetAlphaCriterions() => AlphaCriterions;
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
        }
    }
}
