using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAS
{
    class prova
    {
        public string idnome { get; private set; }
        public string descricao { get; set; }
        
        public Dictionary<participante, float> listap { get; set; } //notas

       


        public prova(string idnome, string descricao)
        {
            this.idnome = idnome;
            this.descricao = descricao;
            this.listap = new Dictionary<participante, float>();
        }

        public participante getVencedor()
        {
            float maior = -1;
            participante pessoa = null;
            foreach (KeyValuePair<participante, float> nota in this.listap)
            {

                if (nota.Value > maior)
                {
                    maior = nota.Value;
                    pessoa = nota.Key;
                }
            }


            return pessoa;
        }


        public int insereParticipante(participante a)
        {

            Random rand = new Random();
            //adicionar portecao para ver se adiciona 1/0
            this.listap.Add(a,rand.Next(1,21));
            return 1;
        }

        public string getStats()
        {
            int numPartic = 0;
            float somaNotas = 0;

            string desc = "NOME DA PROVA: "+ this.descricao + "  | VENCEDOR: "+ getVencedor().nome + " \nANALISE POR DISTRITOS:\n";

            foreach (KeyValuePair<participante, float> p1 in this.listap)
            {
                somaNotas = 0;
                numPartic = 0;
                foreach (KeyValuePair<participante, float> p2 in this.listap)
                {
                    if(p1.Key.eap.distrito.CompareTo(p2.Key.eap.distrito)==0)
                    {
                            numPartic++;
                            somaNotas += p1.Value;
                        
                    }
                    
                }

                desc += String.Format("{0} | {1} | {2}\n", p1.Key.eap.distrito, (somaNotas/numPartic), numPartic);
            }
           
            return desc;

            //ORDENAR POR MEDIA DECRESCENTE
        }

    }
}
