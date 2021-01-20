using MongoDB.Driver;
using PneumoniaAutoDiagnosis.DAL;
using PneumoniaAutoDiagnosis.Models;
using System.Collections.Generic;
using System.Linq;

namespace PneumoniaAutoDiagnosis.Services
{
	public class PatientCardService : BaseDatabaseService
	{
		public IMongoCollection<PatientCard> _patientCard;

		public PatientCardService(IDiagnosesDbDatabaseSettings settings) : base(settings)
		{
			_patientCard = Database.GetCollection<PatientCard>(settings.PatientCardsCollectionName);
		}

		public List<PatientCard> Get() => _patientCard.Find(p => true).ToList();
		public PatientCard Get(string patientCardId) => _patientCard.Find(p => p.Id == patientCardId).FirstOrDefault();
		public void Create(PatientCard patientCard)
		{
			_patientCard.InsertOne(patientCard);
		}
		public void Delete(string patientCardId)
		{
			_patientCard.DeleteOne(p => p.Id == patientCardId);
		}
		public void Update(string id, PatientCard patientCardUpdated) => _patientCard.ReplaceOne(p => p.Id == id, patientCardUpdated);
	}
}
