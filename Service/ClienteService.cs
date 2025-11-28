namespace Sakura_Sushi.Service
{
    public class ClienteService
    {
        private readonly string _connectionString;

        public ClienteService(IConfiguration config)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            _connectionString = config.GetConnectionString("DefaultConnection");
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        public 
    }
}