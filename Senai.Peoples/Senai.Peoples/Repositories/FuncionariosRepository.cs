using Senai.Peoples.Domain;
using Senai.Peoples.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.Repositories
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        string conexao = "Data Source = DEV18\\SQLEXPRESS; initial catalog = M_Peoples; user Id = sa; pwd=sa@132";


        public List<FuncionarioDomain> Listar(List<FuncionarioDomain> funcionarios)
        {
           using(SqlConnection con = new SqlConnection(conexao))
            {
                string command = "SELECT * FROM Funcionarios"
            }
        }
    }
}
