using eCommerceWeb.Models.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;  //Classe do SQLServer

namespace eCommerceWeb.Models
{
	public class CategoriaModel : ModelBase
    {
        public List<Categoria> Read()
        {
            string sql = "SELECT * FROM Categoria";

            //SqlCommand cmd = new SqlCommand(sql, connection); --- Outra Opção
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = sql;

            SqlDataReader reader = cmd.ExecuteReader();

            List<Categoria> lista = new List<Categoria>();

            while(reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.CategoriaId = reader.GetInt32(0); //Indice 0 ou seja, coluna 0 da tebela
                categoria.Nome =        reader.GetString(1); //Indice 1 ou seja, coluna 1 da tebela

                lista.Add(categoria); //Cria a Lista
            }

            return lista; //Retornar a Lista
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Categoria WHERE CategoriaID =" + id;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
        }

        public void Create(Categoria c)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO Categoria VALUES (@nome)";


            cmd.Parameters.AddWithValue("@nome", c.Nome);

            cmd.ExecuteNonQuery();
        }

        public Categoria Read(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM Categoria WHERE CategoriaID = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                Categoria c = new Categoria();
                c.CategoriaId = reader.GetInt32(0);
                c.Nome = reader.GetString(1);
                return c;
            }

            return null;
        }

        public void Update(Categoria c)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "UPDATE Categoria SET Nome = @nome WHERE CategoriaId = @id";

            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@id", c.CategoriaId);

            cmd.ExecuteNonQuery();
        }
    }
}