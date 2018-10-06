using eCommerceWeb.Models.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;



namespace eCommerceWeb.Models
{
	public class ClienteModel:ModelBase
	{
		public Cliente Read(string email, string senha)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = connection;
			cmd.CommandText = @"Select * from Cliente Where Email = @Email AND Senha = @Senha";
			cmd.Parameters.AddWithValue("@Email", email);
			cmd.Parameters.AddWithValue("@Senha", senha);

			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				//Existe um cliente com email/Senha
				Cliente cliente = new Cliente();
				cliente.ClienteID = (int)reader["ClienteID"];
				cliente.Nome = (string)reader["Nome"];
				cliente.Email = (string)reader["Email"];

				return cliente;
			}
			else
			{
				return null;
			}
		}




		public List<Cliente> Read()
		{
			string sql = "SELECT * FROM Cliente";

			//SqlCommand cmd = new SqlCommand(sql, connection); --- Outra Opção
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = connection;
			cmd.CommandText = sql;

			SqlDataReader reader = cmd.ExecuteReader();

			List<Cliente> lista = new List<Cliente>();

			while (reader.Read())
			{
				Cliente cliente = new Cliente();
				cliente.ClienteID = reader.GetInt32(0);
				cliente.Nome = reader.GetString(1);
				cliente.Email = reader.GetString(2);
				cliente.Senha= reader.GetString(3);


				lista.Add(cliente); //Cria a Lista
			}

			return lista; //Retornar a Lista
		}





		public Cliente Read(int id)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = connection;
			cmd.CommandText = "SELECT * FROM Cliente WHERE ClienteID = @id";

			cmd.Parameters.AddWithValue("@id", id);

			SqlDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				Cliente c = new Cliente();
				c.ClienteID = reader.GetInt32(0);
				c.Nome = reader.GetString(1);
				c.Email = reader.GetString(2);
				c.Senha = reader.GetString(3);
				return c;
			}

			return null;
		}





		public void Create(Cliente c)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = connection;
			cmd.CommandText = "INSERT INTO Cliente VALUES (@nome,@email,@senha)";

			cmd.Parameters.AddWithValue("@nome", c.Nome);
			cmd.Parameters.AddWithValue("@email", c.Email);
			cmd.Parameters.AddWithValue("@senha", c.Senha);
			cmd.ExecuteNonQuery();
		}

		public void Delete(int id)
		{
			string sql = "DELETE FROM Cliente WHERE ClienteID =" + id;

			SqlCommand cmd = new SqlCommand();
			cmd.Connection = connection;
			cmd.CommandText = sql;

			cmd.ExecuteNonQuery();
		}


		public void Update(Cliente c)
		{
			
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = connection;
			cmd.CommandText = "UPDATE Cliente SET Nome = @nome , Email = @email, Senha = @senha WHERE ClienteID = @id";

			cmd.Parameters.AddWithValue("@nome", c.Nome);
			cmd.Parameters.AddWithValue("@email", c.Email);
			cmd.Parameters.AddWithValue("@senha", c.Senha);

			cmd.Parameters.AddWithValue("@id", c.ClienteID);

			cmd.ExecuteNonQuery();
		}
	}
}