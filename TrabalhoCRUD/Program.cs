using System;
using TrabalhoCRUD.Context.Menu;
using TrabalhoCRUD.Funcoes;
using TrabalhoCRUD.Menu;

namespace TrabalhoCRUD
{
    class Program
    {
        static void Main()
        {
            /*para criar o banco
            var context = new DistribuicaoContext();

            foreach (var patrimonio in context.Patrimonios)
            {
                Console.WriteLine(patrimonio.Equipamento);
            }*/
            MenuTabelas();

            Console.ReadKey();
        }

        public static void MenuTabelas()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("============================");
                Console.WriteLine("PROJETO DISTRIBUIÇÃO ABINBEV");
                Console.WriteLine("============================\n\n");
                Console.WriteLine("Digite a opção desejada:\n");
                Console.WriteLine("1 - Funcionário");
                Console.WriteLine("2 - Centro Distribuição");
                Console.WriteLine("3 - Patrimônio");
                Console.WriteLine("4 - Sair");
                var opcao = Convert.ToInt32(Console.ReadLine());
                if (opcao >= 4)
                {
                    Console.WriteLine("Preesione a tecla Enter para sair...");
                    Console.ReadKey();
                    break;
                }
                string nomeTabela = "";

                if (opcao == 1)
                {
                    nomeTabela = "Funcionario";
                }
                else if (opcao == 2)
                {
                    nomeTabela = "Centro Distribuição";
                }
                else
                {
                    nomeTabela = "Patrimônio";
                }
                MenuCrud(opcao, nomeTabela);
            } while (true);
        }

        public static void MenuCrud(int opcaoTabela, string nomeTabela)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("============================");
                Console.WriteLine("PROJETO DISTRIBUIÇÃO ABINBEV");
                Console.WriteLine("============================\n\n");
                Console.WriteLine("Digite a opção desejada:\n");
                Console.WriteLine($"1 - Incluir um novo registro em {nomeTabela}");
                Console.WriteLine($"2 - Alterar um registro de {nomeTabela}");
                Console.WriteLine($"3 - Excluir um registro de {nomeTabela}");
                Console.WriteLine($"4 - Listar todos os registros de {nomeTabela}");
                Console.WriteLine($"5 - Listar registros cruzados de {nomeTabela}");
                Console.WriteLine("6 - Sair");
                var opcaoAcao = Convert.ToInt32(Console.ReadLine());
                if (opcaoAcao >= 6) break;

                switch (opcaoAcao)
                {
                    case 1:
                        Console.Clear();
                        Inserir.Executar(opcaoTabela);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Você gostaria de alterar: ");
                        Console.WriteLine("1 - O registro inteiro ");
                        Console.WriteLine("2 - Um único campo do registro ");
                        int alterar = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        if (alterar == 1) AlterarLinha.Executar(opcaoTabela);
                        else if (alterar == 2) AlterarCampo.Executar(opcaoTabela);
                        else 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opção inválida! ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Você sabe o Id do {nomeTabela} que deseja excluir? ");
                        Console.WriteLine("Digite S ou N");
                        string conferirId = Console.ReadLine();
                        Console.Clear();
                        if (conferirId == "n" || conferirId == "N")
                        {
                            ListarGeral.Executar(opcaoTabela);
                        }
                        Console.WriteLine("Informe qual o Id que deseja excluir: ");
                        int opcaoId = Convert.ToInt32(Console.ReadLine());
                        Excluir.Executar(opcaoTabela, opcaoId);
                        break;
                    case 4:
                        Console.Clear();
                        ListarGeral.Executar(opcaoTabela);
                        break;
                    case 5:
                        Console.Clear();
                        ListarDeDois.Executar(opcaoTabela);
                        break;
                }
                Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (true);
        }
    }
}
