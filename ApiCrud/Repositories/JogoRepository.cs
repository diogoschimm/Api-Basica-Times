using ApiCrud.Models;
using ApiCrud.Repositories.Bases;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApiCrud.Repositories
{
    public class JogoRepository : RepositoryBase
    {
        public JogoRepository(string strConexao) : base(strConexao) { }

        public List<Jogo> ObterTodos()
        {
            var query = $@"select idJogo, 
                                  idTimeMandante, 
                                  qtdGolsTimeMandante, 
                                  idTimeVisitante, 
                                  qtdGolsTimeVisitante      
                           from jogo";

            using var conexao = new SqlConnection(this._strConexao);
            using var comando = new SqlCommand(query, conexao);

            conexao.Open();

            var listaRetorno = new List<Jogo>();
            var dr = comando.ExecuteReader();
            while (dr.Read())
            {
                var jogo = new Jogo
                {
                    IdJogo = (int)dr["idJogo"],
                    IdTimeMandante = (int)dr["idTimeMandante"],
                    QtdGolsTimeMandante = (int)dr["qtdGolsTimeMandante"],
                    IdTimeVisitante = (int)dr["idTimeVisitante"],
                    QtdGolsTimeVisitante = (int)dr["qtdGolsTimeVisitante"]
                };

                listaRetorno.Add(jogo);
            }

            return listaRetorno;
        }
        public Jogo ObterPorId(int idJogo)
        {
            var query = $@"select idJogo, 
                                  idTimeMandante, 
                                  qtdGolsTimeMandante, 
                                  idTimeVisitante, 
                                  qtdGolsTimeVisitante      
                           from jogo
                           where idJogo = @idJogo";

            using var conexao = new SqlConnection(this._strConexao);
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.Add("@idJogo", SqlDbType.Int).Value = idJogo;

            conexao.Open();

            var dr = comando.ExecuteReader();
            if (dr.Read())
            {
                var jogo = new Jogo
                {
                    IdJogo = (int)dr["idJogo"],
                    IdTimeMandante = (int)dr["idTimeMandante"],
                    QtdGolsTimeMandante = (int)dr["qtdGolsTimeMandante"],
                    IdTimeVisitante = (int)dr["idTimeVisitante"],
                    QtdGolsTimeVisitante = (int)dr["qtdGolsTimeVisitante"]
                };
                return jogo;
            }

            return null;
        }
        public Jogo Salvar(Jogo jogo)
        {
            var query = $@"insert into Jogo ( 
                            idTimeMandante, 
                            qtdGolsTimeMandante, 
                            idTimeVisitante, 
                            qtdGolsTimeVisitante
                          ) values (  
                            @idTimeMandante, 
                            @qtdGolsTimeMandante, 
                            @idTimeVisitante, 
                            @qtdGolsTimeVisitante
                           );
                           set @idJogo = SCOPE_IDENTITY();";

            using var conexao = new SqlConnection(this._strConexao);
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.Add("@idTimeMandante", SqlDbType.Int).Value = jogo.IdTimeMandante;
            comando.Parameters.Add("@qtdGolsTimeMandante", SqlDbType.Int).Value = jogo.QtdGolsTimeMandante;
            comando.Parameters.Add("@idTimeVisitante", SqlDbType.Int).Value = jogo.IdTimeVisitante;
            comando.Parameters.Add("@qtdGolsTimeVisitante", SqlDbType.Int).Value = jogo.QtdGolsTimeVisitante;
            comando.Parameters.Add("@idJogo", SqlDbType.Int).Direction =  ParameterDirection.Output;

            conexao.Open();
            comando.ExecuteNonQuery();

            jogo.IdJogo = (int)comando.Parameters["@idJogo"].Value;
             
            return jogo;
        }
        public Jogo Atualizar(Jogo jogo)
        {
            var query = $@"update Jogo 
                           set 
                                idTimeMandante = @idTimeMandante, 
                                qtdGolsTimeMandante = @qtdGolsTimeMandante, 
                                idTimeVisitante = @idTimeVisitante, 
                                qtdGolsTimeVisitante = @qtdGolsTimeVisitante
                           where idJogo = @idJogo";

            using var conexao = new SqlConnection(this._strConexao);
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.Add("@idJogo", SqlDbType.Int).Value = jogo.IdJogo;
            comando.Parameters.Add("@idTimeMandante", SqlDbType.Int).Value = jogo.IdTimeMandante;
            comando.Parameters.Add("@qtdGolsTimeMandante", SqlDbType.Int).Value = jogo.QtdGolsTimeMandante;
            comando.Parameters.Add("@idTimeVisitante", SqlDbType.Int).Value = jogo.IdTimeVisitante;
            comando.Parameters.Add("@qtdGolsTimeVisitante", SqlDbType.Int).Value = jogo.QtdGolsTimeVisitante;

            conexao.Open();
            comando.ExecuteNonQuery();
             
            return jogo;
        }
        public void Excluir(int idJogo)
        {
            var query = $@"delete Jogo where idJogo = @idJogo";

            using var conexao = new SqlConnection(this._strConexao);
            using var comando = new SqlCommand(query, conexao);

            comando.Parameters.Add("@idJogo", SqlDbType.Int).Value = idJogo; 

            conexao.Open();
            comando.ExecuteNonQuery();
        }
    }
}
