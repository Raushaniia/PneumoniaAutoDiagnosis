using MongoDB.Driver;
using PneumoniaAutoDiagnosis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
