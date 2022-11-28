using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDelTruco
{
    public class JugadoresDAO
    {
        private static string connectionString;
        private static SqlConnection connection;
        private static SqlCommand command;
        static JugadoresDAO()
        {
            connectionString = @"Server = .; Database = JugadoresTruco;Trusted_Connection=True; ";

            connection = new SqlConnection(connectionString);
            command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = CommandType.Text;
        }

        public static List<Jugador> ObtenerJugadoresDB()
        {
            List<Jugador> jugadores = new List<Jugador>();

            connection.Open();

            command.CommandText = "SELECT * FROM Jugadores";

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                int victorias = reader.GetInt32(2);
                Jugador jugadorLeido = new Jugador(id, nombre, victorias);
                jugadores.Add(jugadorLeido);
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return jugadores;
        }

        public static void ActualizarVictorias(Jugador ganador)
        {
            int victorias = ganador.Victorias + 1;
            try
            {
                connection.Open();
                command.CommandText = $"UPDATE Jugadores SET Victorias = @victorias WHERE Id = {ganador.Id}";
                command.Parameters.AddWithValue("@victorias", victorias);
                command.ExecuteNonQuery();         
            }
            catch (Exception ex )
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                command.Parameters.Clear();
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }      
        }

       
    }
}
