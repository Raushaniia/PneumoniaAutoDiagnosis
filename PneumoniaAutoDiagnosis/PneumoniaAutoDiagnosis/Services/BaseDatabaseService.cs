using MongoDB.Driver;
using PneumoniaAutoDiagnosis.DAL;

namespace PneumoniaAutoDiagnosis.Services
{
	public class BaseDatabaseService
	{
		public IMongoDatabase Database; 
		public BaseDatabaseService(IDiagnosesDbDatabaseSettings settings)
		{
			// test commit 
			var client = new MongoClient(settings.ConnectionString);
			Database = client.GetDatabase(settings.DatabaseName);
		}
	}
}
