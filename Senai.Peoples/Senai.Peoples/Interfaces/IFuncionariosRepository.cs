using Senai.Peoples.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.Interfaces
{
    interface IFuncionariosRepository
    {
        List<FuncionarioDomain> Listar();

        void Cadastrar(FuncionarioDomain novoFuncionario);

        void Deletar(int id);

        FuncionarioDomain BuscarPorId(int id);

        void AtualizarIdUrl(int id,FuncionarioDomain funcionarioAtualizado);
    }
}
