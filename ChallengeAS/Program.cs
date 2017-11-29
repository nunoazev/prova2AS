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
            if (participantes.Count != 0)
            {
                bool provaNaoExiste = false;
                string idprova = "";

                if (provas.Count != 0)
                {
                    Console.WriteLine("Id da prova? (Ex: PROG_JAVA_3)");
                    idprova = Console.ReadLine();

                    foreach (prova t in provas)
                    {
                        if (t.idnome.CompareTo(idprova) == 0)
                        {
                            Console.WriteLine("Adicionar participantes à prova {0}:", t.idnome);
                            addParticipantesToProva(t, participantes);
                        }
                        else
                        {
                            provaNaoExiste = true;
                        }
                    }
                }

                if (provas.Count == 0 || provaNaoExiste)
                {
                    if(provaNaoExiste)
                        Console.WriteLine("Prova ainda nao existe, vamos criar!");
                    else if(provas.Count == 0)
                        Console.WriteLine("Aidna não existem provas, vamos criar a primeira!");

                    if (provas.Count == 0)
                    {
                        Console.WriteLine("\nId da prova? (Ex: PROG_JAVA_3)");
                        idprova = Console.ReadLine();
                    }

                    Console.WriteLine("Descrição da prova?");
                    string desc = Console.ReadLine();

                    prova novaProva = new prova(idprova, desc);
                    provas.Add(novaProva);

                    addParticipantesToProva(novaProva, participantes);
                }
            }
            else
            {
                Console.WriteLine("Não pode criar provas: Não existem participantes!");
                Console.ReadKey();
            }
        }

        static void addParticipantesToProva(prova pro, List<participante> participantes)
        {
            int num = 0;

            do
            {
                Console.WriteLine("Participantes a inserir:");
                num = int.Parse(Console.ReadLine());

                if (num > participantes.Count)
                    Console.WriteLine("Erro: Apenas existem {0} participantes!", participantes.Count);
            } while (num <= 0 || num > participantes.Count);

            for (int i=0; i<num;i++)
            {
                bool participanteExiste = false;
                do
                {
                    Console.WriteLine("Insira o bi do participante");
                    int bi = int.Parse(Console.ReadLine());
                    foreach(participante p in participantes)
                    {
                        if (bi == p.id)
                        {
                            participanteExiste = true;

                            if (!pro.listap.ContainsKey(p))
                                pro.listap.Add(p, 0);
                            else
                            {
                                Console.WriteLine("Participante já está inscrito nesta prova!");
                                Console.ReadKey();
                            }

                        }
                    }
                    if (!participanteExiste)
                        Console.WriteLine("Participante não existe!");
                } while (!participanteExiste);
            }
        }

        static void gestaoerros()
        {
           

            int opmenu = 5;
            do
            {
                Console.WriteLine("1 - Remover participante");
                Console.WriteLine("2 - Remover Entidade");
                Console.WriteLine("3 - Remover Inscricao na prova");
                Console.WriteLine("0 - Voltar");

                opmenu = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opmenu)
                {
                    case 1:
                       
                        break;
                    
                }


            } while (opmenu != 0);
        }
    }
}
