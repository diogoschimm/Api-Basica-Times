using ApiCrud.Models;
using ApiCrud.Repositories.Bases;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApiCrud.Repositories
{
    public class TimeRepository : RepositoryBase
    {
        public TimeRepository(string strConexao) : base(strConexao) { }

        public List<Time> ObterTodos()
        {
            var query = "select idTime, nomeTime from Time";

            var conexao = new SqlConnection(this._strConexao);
            var comando = new SqlCommand(query, conexao);

            var listaRetorno = new List<Time>();
            try
            {
                conexao.Open();

                var dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    var time = new Time
                    {
                        IdTime = (int)dr["idTime"],
                        NomeTime = dr["nomeTime"].ToString()
                    };
                    listaRetorno.Add(time);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
                comando.Dispose();
            }

            return listaRetorno;
        }
        public Time ObterPorId(int idTime)
        {
            var query = $@"select idTime, nomeTime from Time
                           where idTime = @idTime";

            var conexao = new SqlConnection(this._strConexao);
            var comando = new SqlCommand(query, conexao);
            try
            {
                comando.Parameters.Add("@idTime", SqlDbType.Int).Value = idTime;
                conexao.Open();

                var dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    var time = new Time
                    {
                        IdTime = (int)dr["idTime"],
                        NomeTime = dr["nomeTime"].ToString()
                    };
                    return time;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
                comando.Dispose();
            }
            return null;
        }

        public Time Salvar(Time time)
        {
            var query = $@"insert into Time ( 
                            nomeTime
                          ) values (  
                            @nomeTime
                          );
                          set @idTime = SCOPE_IDENTITY();";

            var conexao = new SqlConnection(this._strConexao);
            var comando = new SqlCommand(query, conexao);
            try
            {
                comando.Parameters.Add("@nometime", SqlDbType.VarChar, 100).Value = time.NomeTime;
                comando.Parameters.Add("@idTime", SqlDbType.Int).Direction = ParameterDirection.Output;

                conexao.Open();
                comando.ExecuteNonQuery();

                time.IdTime = (int)comando.Parameters["@idTime"].Value;
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
                comando.Dispose();
            }

            return time;
        }
        public Time Atualizar(Time time)
        {
            var query = $@"update Time 
                           set 
                                nometime = @nomeTime
                           where idJogo = @idJogo";

            var conexao = new SqlConnection(this._strConexao);
            var comando = new SqlCommand(query, conexao);

            try
            {
                comando.Parameters.Add("@idTime", SqlDbType.Int).Value = time.IdTime;
                comando.Parameters.Add("@nometime", SqlDbType.VarChar, 100).Value = time.NomeTime;

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
                comando.Dispose();
            }

            return time;
        }
        public void Excluir(int idTime)
        {
            var query = $@"delete Time where idTime = @idTime";

            var conexao = new SqlConnection(this._strConexao);
            var comando = new SqlCommand(query, conexao);
            try
            {
                comando.Parameters.Add("@idTime", SqlDbType.Int).Value = idTime;

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
                comando.Dispose();
            }
        }
    }
}
