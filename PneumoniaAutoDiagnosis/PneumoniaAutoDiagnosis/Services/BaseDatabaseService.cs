using MongoDB.Driver;
using PneumoniaAutoDiagnosis.DAL;

namespace PneumoniaAutoDiagnosis.Services
{
	public class BaseDatabaseService
	{
		public IMongoDatabase Database; 
		public BaseDatabaseService(IDiagnosesDbDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			Database = client.GetDatabase(settings.DatabaseName);
		}
	}
}
