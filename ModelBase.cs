using System;
using System.Data.SqlClient;  //Classe do SQLServer

namespace eCommerceWeb.Models
{
	public abstract class ModelBase : IDisposable
    {
        //TODO Adicionar no Arquivo de Configuração (WEB.config)
        const string SERVIDOR = "Gabriel-R";
        const string BANCODADOS = "BDEcommerce";
        const string USUARIO = "sa";
        const string SENHA = "G@briel442018";

        //SqlConnection -- Classe para Conectar ao BD
        //SqlCommand    -- Classe para inserir o Comando
        //SqlDataReader -- Classe para ler os dados do BD


        //Pertence ao nameSpace System.Data.SqlClient
        protected SqlConnection connection; //Para conectar ao BD

        public ModelBase()
        {
            string strConn = $"Data Source = {SERVIDOR}; Initial Catalog = {BANCODADOS}; Integrated Security = true";
            //USER Id = {USUARIO}; PASSWORD = {SENHA}";

            connection = new SqlConnection(strConn); //Para conectar ao BD - Cria o objeto que faz a conexão
            connection.Open(); //Inicia a Conexão
        }

        public void Dispose()
        {
            //Última "coisa" a ser feita pela classe, depois disso ela MORRE!
            connection.Close();
        }
    }
}