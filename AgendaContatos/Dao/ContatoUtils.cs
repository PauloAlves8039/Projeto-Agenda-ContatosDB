/*
 * Arquivo: classe ContatoUtils
 * Autor: Paulo Alves
 * Descrição: responsável por conter métodos para conexão e execução de instruções no banco de dados
 * Data: 01/12/2019
*/

using System.Data.SqlClient;

namespace AgendaContatos.Dao
{
    public class ContatoUtils
    {
        public static SqlConnection AbrirConexao()
        {
            SqlConnection conexao = new SqlConnection(@"Server=.\SQLEXPRESS;Database=db_agenda;User Id=sa;Password = ****;");
            conexao.Open();
            return conexao;
        }

        public static SqlCommand ExecutarComando(SqlConnection conexao)
        {
            SqlCommand comando = conexao.CreateCommand();
            return comando;
        }

        public static SqlDataReader ExecutarDataReader(SqlCommand comando)
        {
            return comando.ExecuteReader();
        }
    }
}
