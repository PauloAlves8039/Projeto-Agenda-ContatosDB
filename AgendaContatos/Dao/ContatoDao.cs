/*
 * Arquivo: classe ContatoDao
 * Autor: Paulo Alves
 * Descrição: responsável pela regra de negocio da aplicação interagindo com o banco de dados
 * Data: 01/12/2019
*/

using System;
using System.Data;
using System.Data.SqlClient;
using AgendaContatos.Entities;

namespace AgendaContatos.Dao
{
    public class ContatoDao
    {
        public DataTable BuscarTodos()
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection conexao = ContatoUtils.AbrirConexao();
                SqlCommand comando = ContatoUtils.ExecutarComando(conexao);
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select * from tb_contatos";
                SqlDataReader leituraDados = ContatoUtils.ExecutarDataReader(comando);                
                dataTable.Load(leituraDados);
                

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar dados: " + ex.Message);
            }
            return dataTable;

        }

        public void Inserir(Contato contato)
        {
            try
            {
                SqlConnection conexao = ContatoUtils.AbrirConexao();
                SqlCommand comando = ContatoUtils.ExecutarComando(conexao);
                comando.CommandType = CommandType.Text;
                comando.CommandText = "insert into tb_contatos (nome, email, telefone) values (@nome, @email, @telefone)";
                comando.Parameters.Add(new SqlParameter("@nome", contato.Nome));
                comando.Parameters.Add(new SqlParameter("@email", contato.Email));
                comando.Parameters.Add(new SqlParameter("@telefone", contato.Telefone));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir dados: " + ex.Message);
            }
        }

        public void Atualizar(Contato contato)
        {
            try
            {
                SqlConnection conexao = ContatoUtils.AbrirConexao();
                SqlCommand comando = ContatoUtils.ExecutarComando(conexao);
                comando.CommandType = CommandType.Text;
                comando.CommandText = "update tb_contatos set nome = @nome, email = @email, telefone = @telefone where id = @id";
                comando.Parameters.Add(new SqlParameter("@nome", contato.Nome));
                comando.Parameters.Add(new SqlParameter("@email", contato.Email));
                comando.Parameters.Add(new SqlParameter("@telefone", contato.Telefone));
                comando.Parameters.Add(new SqlParameter("@id", contato.Id));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar dados: " + ex.Message);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                SqlConnection conexao = ContatoUtils.AbrirConexao();
                SqlCommand comando = ContatoUtils.ExecutarComando(conexao);
                comando.CommandType = CommandType.Text;
                comando.CommandText = "delete from tb_contatos where id=@id";
                comando.Parameters.Add(new SqlParameter("@id", id));
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir dados: " + ex.Message);
            }
        }
    }
}
