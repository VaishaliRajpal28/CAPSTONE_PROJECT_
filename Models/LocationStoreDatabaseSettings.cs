namespace Capstone.Models
{
    public class LocationStoreDatabaseSettings : ILocationStoreDatabaseSettings
    {

        public string LocationCollectionName { get; set; } = string.Empty;

        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;

    }
}