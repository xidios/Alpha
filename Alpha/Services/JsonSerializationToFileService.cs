﻿using Alpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Alpha.Data;
using System.IO;

namespace Alpha.Services
{
    // TODO: Generic
    public class JsonSerializationToFileService
    {
        private JsonPaths jsonPaths = new JsonPaths();
        // TODO: PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        public void ExportWorkProductCriterionsToFile(List<WorkProductCriterion> workProductCriterions)
        {
            var jsonWorkProductCriterions = JsonSerializer.Serialize(workProductCriterions, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
                
            });
            File.WriteAllText(jsonPaths.PathToWorkProductCriterionsFile, jsonWorkProductCriterions);
        }
        public void ExportAlphaCriterionsToFile(List<AlphaCriterion> alphaCriterions)
        {
            var jsonAlphaCriterions = JsonSerializer.Serialize(alphaCriterions, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true

            });
            File.WriteAllText(jsonPaths.PathToAlphaCriterionsFile, jsonAlphaCriterions);
        }
        public void ExportActivitiesToJsonFile(List<Activity> activities)
        {
            var jsonActivities = JsonSerializer.Serialize(activities, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(jsonPaths.PathToActivitiesFile, jsonActivities);
        }
        public void ExportAlphasToFile(List<Alpha> alphas)
        {
            var jsonAlphas = JsonSerializer.Serialize(alphas, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(jsonPaths.PathToAlphasFile, jsonAlphas);
        }
        public void ExportWorkProductsToJsonFile(List<WorkProduct> workProducts)
        {
            var jsonWorkProducts = JsonSerializer.Serialize(workProducts, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            });
            File.WriteAllText(jsonPaths.PathToWorkProductsFile, jsonWorkProducts);
        }
       
    }
}
