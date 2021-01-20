namespace PneumoniaAutoDiagnosis.DAL
{
    public class DiagnosesDbDatabaseSettings : IDiagnosesDbDatabaseSettings
    {
        public string PatientsCollectionName { get; set; }
        public string PatientCardsCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
