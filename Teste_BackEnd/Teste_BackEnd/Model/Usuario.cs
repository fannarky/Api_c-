using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_BackEnd.Model
{
    public class Usuario
    {
        public int idFuncionario { get; set; }

        public string nmFuncionario { get; set; }

        public string nmEmail { get; set; }

        public string nrTelefone { get; set; }

        public string nmSenha { get; set; }

        public int idEmpresa { get; set; }

        public int idGestor { get; set; }

        public int idTipo { get; set; }

        public string slackLink { get; set; }


    }
}
