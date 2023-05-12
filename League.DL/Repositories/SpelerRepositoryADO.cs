using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using League.BL.Model;
using League.BL.Interfaces;
using League.BL.Exceptions;
using System.Data.SqlClient;
using League.DL.Exceptions;

namespace League.DL.Repositories
{
    public class SpelerRepositoryADO : ISpelerRepository
    {
        private string connectionString;

        public SpelerRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool BestaatSpeler(Speler speler)
        {
            string sql = "select count(*) from dbo.speler where naam=@naam";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@naam", speler.Naam);
                    int n = (int)cmd.ExecuteScalar();
                    if (n > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                catch (Exception ex)
                {

                    throw new SpelerRepositoryException("Fout bij het controleren of de speler bestaat", ex);
                }
            }
        }

        public Speler SchrijfSpelerInDB(Speler speler)
        {
            string sql = "insert into dbo.speler(naam, lengte, gewicht) output INSERTED.ID VALUES(@naam,@lengte,@gewicht)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@naam", speler.Naam);
                    if (speler.Lengte == null)
                    {
                        cmd.Parameters.AddWithValue("@lengte", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@lengte", speler.Lengte);
                    }
                    if (speler.Gewicht == null)
                    {
                        cmd.Parameters.AddWithValue("@gewicht", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@gewicht", speler.Gewicht);
                    }
                    int id = (int)cmd.ExecuteScalar();
                    speler.ZetId(id); return speler;
                }
                catch (Exception ex)
                {

                    throw new SpelerRepositoryException("Fout bij het schrijven van de speler naar de database", ex);
                }
            }
        }

        public void UpdateSpeler(Speler speler)
        {
            string sql = "update dbo.speler set naam=@naam, lengte=@lengte, gewicht=@gewicht where id=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@id",speler.Id);
                    command.Parameters.AddWithValue("@naam", speler.Naam);
                    if(speler.RugNummer == null) 
                    { 
                        command.Parameters.AddWithValue("@rugnummer", DBNull.Value); 
                    }
                    else {
                        command.Parameters.AddWithValue("@rugnummer", speler.RugNummer); 
                    }
                    if (speler.Lengte == null)
                    {
                        command.Parameters.AddWithValue("@lengte", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@lengte", speler.Lengte);
                    }
                    if (speler.Gewicht == null)
                    {
                        command.Parameters.AddWithValue("@gewicht", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@gewicht", speler.Gewicht);
                    }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw new SpelerRepositoryException("updatespeler0",ex);
                }
            }
        }
    }
}
