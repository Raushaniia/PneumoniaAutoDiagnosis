namespace PneumoniaAutoDiagnosis.DAL
{
    public interface IDiagnosesDbDatabaseSettings
    {
        string PatientsCollectionName { get; set; }
        string PatientCardsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
