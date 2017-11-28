using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAS
{
    class entidade
    {
        public string nome { get; set; }
        public string distrito { get; set; }
        public string tipoprova { get; set; }

        public entidade(string nome,string distrito,string tipoprova)
        {
            this.nome = nome;
            this.distrito = distrito;
            this.tipoprova = tipoprova;
        }



    }
}
