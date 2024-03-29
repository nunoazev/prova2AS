﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAS
{
    class chefeoficina : staff
    {

        public double dinheiro { get; set; }
        public DateTime dataInscri { get; set; }
        public prova p { get; set; }
       
        public chefeoficina(DateTime dn, string nome, double dinheiro,prova p) : base( dn, nome)
        {            this.dinheiro = dinheiro;
            this.dataInscri = DateTime.Now;
            this.p = p;
        }

        public string calculaDataFimParticipacao(int numeroDeDias)
        {
            DateTime fimPartic = this.dataInscri.AddDays(numeroDeDias);

            return fimPartic.Day + " de " + fimPartic.Month;
        }

        public double calculaRetencao()
        {
            return (this.dinheiro*0.25);
        }
    }
}
