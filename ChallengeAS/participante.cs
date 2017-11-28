using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAS
{
    class participante
    {
        public int id { get; private set; }
        public string nome { get; set; }
        public DateTime dataNasc { get; set; }
        public entidade eap { get; set; }

        public participante(int Id, string Nome, DateTime DataNasc, entidade Eap)
        {
            this.id = Id;
            this.nome = Nome;
            this.dataNasc = DataNasc;
            this.eap = Eap;
        }

        public int getIdade()
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - this.dataNasc.Year;

            if (this.dataNasc > hoje.AddYears(-idade))
                idade--;

            return idade;
        }
    }
}
