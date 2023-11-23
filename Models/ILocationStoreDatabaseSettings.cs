namespace Capstone.Models
{
    public interface ILocationStoreDatabaseSettings
    {
     string LocationCollectionName {get; set;}
    string ConnectionString { get; set; }
     string DatabaseName { get; set; }

    }
}
