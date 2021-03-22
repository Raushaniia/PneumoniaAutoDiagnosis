using MongoDB.Driver;
using PneumoniaAutoDiagnosis.DAL;
using PneumoniaAutoDiagnosis.Models;
using System.Collections.Generic;
using System.Linq;

namespace PneumoniaAutoDiagnosis.Services
{
	public class PatientService 
	{
		public IMongoCollection<Patient> _patients;
		private readonly ICosmosDbService _cosmosDbService;

		//public PatientService(IDiagnosesDbDatabaseSettings settings) : base(settings)
		//{
		//	_patients = Database.GetCollection<Patient>(settings.PatientsCollectionName);
		//}

		public PatientService(ICosmosDbService cosmosDbService)
		{
			_cosmosDbService = cosmosDbService;
		}

		public List<Patient> Get() => _cosmosDbService.GetItemsAsync("SELECT * FROM c").ToList();//_patients.Find(p => true).ToList();
		public Patient Get(string patientId) => _cosmosDbService.GetItemAsync(patientId);
		public void Create(Patient patient)
		{
			_cosmosDbService.AddItemAsync(patient);
		}
		public void Delete(string patientId)
		{
			_cosmosDbService.DeleteItemAsync(patientId);
			//_patients.DeleteOne(p => p.Id == patientId);
		}
		public void Update(string id, Patient patientUpdated) => _cosmosDbService.UpdateItemAsync(id, patientUpdated);//_patients.ReplaceOne(p => p.Id == id, patientUpdated);
	}
}
