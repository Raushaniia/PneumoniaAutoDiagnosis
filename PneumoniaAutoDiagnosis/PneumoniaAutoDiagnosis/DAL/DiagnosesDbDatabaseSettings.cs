namespace PneumoniaAutoDiagnosis.DAL
{
    public class DiagnosesDbDatabaseSettings : IDiagnosesDbDatabaseSettings
    {
        public string PatientsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDiagnosesDbDatabaseSettings
    {
        string PatientsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
