using PneumoniaAutoDiagnosis.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PneumoniaAutoDiagnosis.Services
{
    public interface ICosmosDbService
    {
        IEnumerable<Patient> GetItemsAsync(string query);
        Patient GetItemAsync(string id);
        void AddItemAsync(Patient item);
        void UpdateItemAsync(string id, Patient item);
        void DeleteItemAsync(string id);
    }
}