namespace ApiCrud.Repositories.Bases
{
    public abstract class RepositoryBase
    {
        protected readonly string _strConexao;

        protected RepositoryBase(string strConexao)
        {
            this._strConexao = strConexao;
        }
    }
}
