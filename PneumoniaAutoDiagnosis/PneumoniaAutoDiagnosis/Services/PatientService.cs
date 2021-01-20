using MongoDB.Driver;
using PneumoniaAutoDiagnosis.DAL;
using PneumoniaAutoDiagnosis.Models;
using System.Collections.Generic;
using System.Linq;

namespace PneumoniaAutoDiagnosis.Services
{
	public class PatientService : BaseDatabaseService
	{
		public IMongoCollection<Patient> _patients;

		public PatientService(IDiagnosesDbDatabaseSettings settings) : base(settings)
		{
			_patients = Database.GetCollection<Patient>(settings.PatientsCollectionName);
		}

		public List<Patient> Get() => _patients.Find(p => true).ToList();
		public Patient Get(string patientId) => _patients.Find(p => p.Id == patientId).FirstOrDefault();
		public void Create(Patient patient)
		{
			_patients.InsertOne(patient);
		}
		public void Delete(string patientId)
		{
			_patients.DeleteOne(p => p.Id == patientId);
		}
		public void Update(string id, Patient patientUpdated) => _patients.ReplaceOne(p => p.Id == id, patientUpdated);
	}
}
