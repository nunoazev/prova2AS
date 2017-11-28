using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeAS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<prova> provas = new List<prova>();
            List<participante> participantes = new List<participante>();
            List<entidade> entidades = new List<entidade>();
            List<chefeoficina> chefeoficinas = new List<chefeoficina>();


            //menu

            int opmenu = 5;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Adicionar novo Participante");
                Console.WriteLine("2 - Adicionar nova Indentidade");
                Console.WriteLine("3 - Adicionar nova prova");
                Console.WriteLine("4 - Gestao de erros");

                Console.WriteLine("0 - Sair");

                opmenu = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opmenu)
                {
                    case 1:
                        addparticipante(participantes,entidades);
                        break;
                    case 2:
                        addentidade(entidades);
                        break;
                    case 3:
                        addprova(provas,participantes);
                        break;
                    case 4:
                        gestaoerros();
                        break;
                }


            } while (opmenu != 0);


            //extra 
            Console.WriteLine(participantes.Count);
            Console.ReadKey();
        }

        //static garante que ja existe na primeira execucao do codigo. pesquisar!

        static void addparticipante(List<participante> participantes,List<entidade> entidades)
        {
            if (entidades.Count!=0)
            {
                Console.WriteLine("Insira o seu BI:");
                int bi = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira o seu Nome:");
                String nome = Console.ReadLine();
                Console.WriteLine("Insira a sua data nascimento:");
                DateTime dn = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Insira a entidade:");
                int count = 1;
                foreach (entidade e in entidades)
                {
                    
                    Console.WriteLine("{0} - {1}, {2} ",count,e.nome,e.distrito);
                    count++;
                }
                int ent = int.Parse(Console.ReadLine());

                participante novo = new participante(bi, nome, dn, entidades[ent-1]);

                participantes.Add(novo);
            } else
            {
                Console.WriteLine("tem de criar a entidade primeiro");
                Console.ReadKey();
            }
           
        }

        static void addentidade(List<entidade> entidades)
        {
           
            String nome;
            String dest;
            bool flag;

            do
            {
               flag = false;
                Console.WriteLine("Insira nome entidade:");
                nome = Console.ReadLine();
                Console.WriteLine("Insira o destrito:");
                dest = Console.ReadLine();

                foreach (entidade e in entidades)
                {
                    if (dest == e.distrito && nome == e.nome)
                    {
                        flag = true;
                        Console.WriteLine("Ja existe uma entidade com nome e distrito iguais");
                        break;
                    }
                }

            } while (flag);

            Console.WriteLine("Insira o tipo de prova:");
            String tipoprova = Console.ReadLine();
            entidade novo = new entidade(nome, dest, tipoprova);
            entidades.Add(novo);
            
        }

        static void addprova(List <prova> provas, List<participante> participantes)
        {
            if (provas.Count != 0)
            {
                Console.WriteLine("Id da prova? (Ex: PROG_JAVA_3)");
                string idprova = Console.ReadLine();

                foreach ()
                {

                }
            }
            else
            {
                int num = 0;
                Console.WriteLine("Prova ainda nao existe, vamos criar");
                Console.WriteLine();

                do
                {
                    Console.WriteLine("Participantes a inserir:");
                   num = int.Parse(Console.ReadLine());
                } while (num <= 0);

                for (int i=0; i<num;i++) {
                    do
                    {
                        Console.WriteLine("Insira o bi do participante");
                        int bi = int.Parse(Console.ReadLine());
                        foreach(participante p in participantes)
                        {
                            if (bi == p.id)
                            {

                            }
                        }
                    } while ();
                }

            } 

        }

        static void gestaoerros()
        {
            Console.WriteLine();
        }
    }
}
