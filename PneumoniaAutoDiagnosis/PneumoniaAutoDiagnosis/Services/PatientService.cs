using MongoDB.Driver;
using PneumoniaAutoDiagnosis.DAL;
using PneumoniaAutoDiagnosis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PneumoniaAutoDiagnosis.Services
{
	public class PatientService
	{
		public IMongoCollection<Patient> _patients;

		public PatientService(DiagnosesDbDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_patients = database.GetCollection<Patient>(settings.PatientsCollectionName);
		}

		public List<Patient> Get() => _patients.Find(p => true).ToList();
		public Patient Get(long patientId) => _patients.Find(p => p.Id == patientId).FirstOrDefault();
		public void Create(Patient patient)
		{
			_patients.InsertOne(patient);
		}
		public void Delete(long patientId)
		{
			_patients.DeleteOne(p => p.Id == patientId);
		}
		public void Update(long id, Patient patientUpdated) => _patients.ReplaceOne(p => p.Id == id, patientUpdated);
	}
}
