 using Microsoft.AspNetCore.Mvc;
 using practicas.Models;
using Microsoft.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace practicas.Controllers
{
	public class UsuarioController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        string connectionString = "Server=LAPTOP-CEDRUKGG;Database=ProgarammingV;User Id=sa;Password=1234;TrustServerCertificate=True;";

        public ActionResult ForMethod(string username,string password, string name, string fechaNacimiento, string email )
		{
			try
			{

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					string query = @"INSERT INTO Usuarios (username, name, fechanacimiento, email, password) " +
						" VALUES (@username, @name, @fechanacimiento,@email,@password) ";
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.AddWithValue("@username", username);
					command.Parameters.AddWithValue("@password", password);
					command.Parameters.AddWithValue("@name", name);
					command.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
					command.Parameters.AddWithValue("@email", email);
					connection.Open();
					int rowsAffected = command.ExecuteNonQuery();

					if (rowsAffected > 0)
					{



						ViewBag.Mensaje = "Usuario Creado exitosamente";



					}
					else
					{

						ViewBag.Mensaje = "ERROR - usuario no creado";
					}
				}

			}

			catch (Exception ex)
			{
				ViewBag.Error = "Error al insertar el usuario" + username + ": " + ex.Message;



			}
			return View("Index");
		}

	}
}
