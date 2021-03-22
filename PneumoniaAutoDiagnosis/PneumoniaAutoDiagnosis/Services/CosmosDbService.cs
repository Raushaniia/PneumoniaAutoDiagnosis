using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using PneumoniaAutoDiagnosis.Models;

namespace PneumoniaAutoDiagnosis.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public  void AddItemAsync(Patient item)
        {
             this._container.CreateItemAsync<Patient>(item, new PartitionKey(item.Id));
        }

        public void DeleteItemAsync(string id)
        {
             this._container.DeleteItemAsync<Patient>(id, new PartitionKey(id));
        }

        public Patient GetItemAsync(string id)
        {
            try
            {
                ItemResponse<Patient> response =  this._container.ReadItemAsync<Patient>(id, new PartitionKey(id)).Result;
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public IEnumerable<Patient> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Patient>(new QueryDefinition(queryString));
            List<Patient> results = new List<Patient>();
            while (query.HasMoreResults)
            {
                var response = query.ReadNextAsync();

                results.AddRange(response.Result);
            }

            return results;
        }

        public void UpdateItemAsync(string id, Patient item)
        {
            this._container.UpsertItemAsync<Patient>(item, new PartitionKey(id));
        }
    }
}
