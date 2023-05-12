using League.BL.Managers;
using League.BL.Model;
using League.BL.Exceptions;
using League.DL.Repositories;

namespace ConsoleAppSpelerManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=Daniel\\SQLEXPRESS;Initial Catalog=League;Integrated Security=True";
            SpelerRepositoryADO repo = new SpelerRepositoryADO(connectionString);
            SpelerManager manager = new SpelerManager(repo);
            try
            {
                Speler s = manager.RegistreerSpeler("Jan", 180, 80);
                Console.WriteLine($"Speler {s.Naam} is geregistreerd");
            }
            catch (SpelerManagerException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Er is een fout opgetreden");
            }
        }
    }
}