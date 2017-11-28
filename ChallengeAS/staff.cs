using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAS
{
    abstract class staff
    {
        public int idInterno { get; private set; }
        public DateTime dataNascimento { get; set; }
        public string nome { get; set; }

        public staff(int id, DateTime dn, string nome)
        {
            this.idInterno = id;
            this.dataNascimento = dn;
            this.nome = nome;
        }
    }
}
