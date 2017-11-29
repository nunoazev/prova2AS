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
        
        public Dictionary<participante, float> listap { get; set; }

       


        public prova(string idnome, string descricao)
        {
            this.idnome = idnome;
            this.descricao = descricao;
            this.listap = new Dictionary<participante, float>();
        }

        public participante getVencedor()
        {
            float maior = 0;
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

            //adicionar portecao para ver se adiciona 1/0
            this.listap.Add(a,0);
            return 1;
        }

        public string getStats()
        {
            int numPartic = 0;
            float somaNotas = 0;

            string desc = String.Format("NOME DA PROVA: {0}  | VENCEDOR: {1} \nANALISE POR DISTRITOS:\n",this.descricao,getVencedor().nome);

            foreach (KeyValuePair<participante, float> p1 in this.listap)
            {
                somaNotas = 0;
                numPartic = 0;
                foreach (KeyValuePair<participante, float> p2 in this.listap)
                {
                    if(p1.Key.eap.distrito == p2.Key.eap.distrito)
                    {
                        if (!p1.Key.Equals(p2.Key))
                        {
                            numPartic++;
                            somaNotas += p1.Value;
                        }
                    }
                    
                }

                desc += String.Format("{0} | {1} | {2}", p1.Key.eap.distrito, (somaNotas/numPartic), numPartic);
            }
           
            return desc;

            //ORDENAR POR MEDIA DECRESCENTE
        }

    }
}
