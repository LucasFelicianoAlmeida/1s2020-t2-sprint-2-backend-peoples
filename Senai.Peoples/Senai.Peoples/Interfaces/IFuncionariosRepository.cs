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
    }
}
