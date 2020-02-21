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
        string conexao = "Data Source = LAB104501\\SQLEXPRESS02; initial catalog = M_Peoples; user Id = sa; pwd=132";


        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(conexao))
            {
                string commandText = "SELECT * FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand command = new SqlCommand(commandText, con))
                {
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString(),

                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        funcionarios.Add(funcionario);
                    }

                }


            }
            return funcionarios;
        }

        public void Cadastrar(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string commandText = "INSERT INTO Funcionarios(Nome,Sobrenome) VALUES (@NOME,@SOBRENOME);";


                SqlCommand command = new SqlCommand(commandText, con);

                command.Parameters.AddWithValue("@NOME", funcionario.Nome);
                command.Parameters.AddWithValue("@SOBRENOME", funcionario.Sobrenome);

                con.Open();

                command.ExecuteNonQuery();
            }
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string commandText = "SELECT IdFuncionario, Nome , Sobrenome FROM Funcionarios WHERE IdFuncionario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand command = new SqlCommand(commandText, con))
                {
                    //Passa o valor do parametro
                    command.Parameters.AddWithValue("@ID", id);

                    //Executa o comando
                    rdr = command.ExecuteReader();


                    //Se ler o comando adiciona um funcionario com os parametros
                    if (rdr.Read())
                    {

                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),

                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        return funcionario;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        public void Deletar(int idDeletar)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string commandText = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";


                SqlDataReader rdr;
                using (SqlCommand command = new SqlCommand(commandText, con))
                {
                    command.Parameters.AddWithValue("@ID", idDeletar);

                    //Abrir a conexão
                    con.Open();

                    //Executa o comando
                    command.ExecuteNonQuery();

                }


            }
        }

        
        

        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string commandUpdate = "UPDATE Funcionarios SET Nome = @NOME, Sobrenome = @SOBRENOME  WHERE IdFuncionario = @ID";


                using (SqlCommand command = new SqlCommand(commandUpdate, con))
                {
                    //Passa os valores dos parametros
                    command.Parameters.AddWithValue("@ID", funcionario.IdFuncionario);
                    command.Parameters.AddWithValue("@NOME", funcionario.Nome);
                    command.Parameters.AddWithValue("@SOBRENOME", funcionario.Sobrenome);

                    con.Open();

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
