using Alpha.Data;
using Alpha.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Alpha.Services
{
    public class JsonDeserializationService
    {
        private JsonPaths jsonPaths = new JsonPaths();
        public List<Activity> DeserializeJsonActivities()
        {
            if (File.Exists(jsonPaths.PathToActivitiesFile))
            {
                string jsonString = File.ReadAllText(jsonPaths.PathToActivitiesFile);
                if (jsonString != null && jsonString != "")
                {
                    return JsonSerializer.Deserialize<List<Activity>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                else
                {
                    return new List<Activity>();
                }
            }
            else
            {
                using (File.Create(jsonPaths.PathToActivitiesFile)) { }
                return new List<Activity>();
            }
        }
        public List<Alpha> DeserializeJsonAlphas()
        {
            if (File.Exists(jsonPaths.PathToAlphasFile))
            {
                string jsonString = File.ReadAllText(jsonPaths.PathToAlphasFile);
                if (jsonString != null && jsonString != "")
                {
                    return JsonSerializer.Deserialize<List<Alpha>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                else
                {
                    return new List<Alpha>();
                }
            }
            else
            {
                using (File.Create(jsonPaths.PathToAlphasFile)) { }
                return new List<Alpha>();
            }
        }
        public List<WorkProduct> DeserializeJsonWorkProducts()
        {
            if (File.Exists(jsonPaths.PathToWorkProductsFile))
            {
                string jsonString = File.ReadAllText(jsonPaths.PathToWorkProductsFile);
                if (jsonString != null && jsonString != "")
                {
                    return JsonSerializer.Deserialize<List<WorkProduct>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                else
                {
                    return new List<WorkProduct>();
                }
            }
            else
            {
                using (File.Create(jsonPaths.PathToWorkProductsFile)) { }
                return new List<WorkProduct>();
            }
        }
        public List<WorkProductCriterion> DeserializeJsonWorkProductCriterions(List<Activity> activities, List<LevelOfDetail> levelOfDetails)
        {
            
            if (File.Exists(jsonPaths.PathToWorkProductCriterionsFile))
            {
                List<WorkProductCriterion> workProductCriterions = new List<WorkProductCriterion>();
                string jsonString = File.ReadAllText(jsonPaths.PathToWorkProductCriterionsFile);
                if (jsonString != null && jsonString != "")
                {
                    workProductCriterions = JsonSerializer.Deserialize<List<WorkProductCriterion>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
                }
                foreach (var workProductCriterion in workProductCriterions)
                {
                    Activity activity = activities.FirstOrDefault(a => a.Id == workProductCriterion.GetActivityId());
                    LevelOfDetail levelOfDetail = levelOfDetails.FirstOrDefault(l => l.GetId() == workProductCriterion.GetLevelOfDetailId());
                    if (activity != null && levelOfDetail != null)
                    {
                        workProductCriterion.SetActivity(activity);
                        workProductCriterion.SetLevelOfDetail(levelOfDetail);
                        continue;
                    }
                    if (levelOfDetail == null) // w/o level of details
                    {
                        workProductCriterion.SetActivity(activity);
                    }
                }
                return workProductCriterions;
            }
            else
            {
                using (File.Create(jsonPaths.PathToWorkProductCriterionsFile)) { }
                return new List<WorkProductCriterion>();
            }
        }

    }
}
