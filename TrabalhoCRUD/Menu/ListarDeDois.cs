using System;
using TrabalhoCRUD.Context;

namespace TrabalhoCRUD
{
    public class ListarDeDois
    {
        public static void Executar(int opcaoTabela)
        {
            if (opcaoTabela == 2)
            {
                var ativo = true;
                do
                {
                    Console.WriteLine("Qual lista deseja ver:\n" +
                        "1 - Funcionario - Centro de Distribuicao\n" +
                        "2 - Patrimonio - Centro de Distribuicao\n" +
                        "3 - Sair");
                    var opcao = Console.ReadLine();
                    var context = new DistribuicaoContext();
                    switch (opcao)
                    {
                        case "1":
                            var funcionarios = context.Funcionarios;
                            Console.WriteLine($"{"ID".PadRight(3)}{"CPF".PadRight(14)}{"NOME".PadRight(30)}" +
                                    $"{"ID".PadRight(3)}{"RAZÃO SOCIAL".PadRight(30)}ENDEREÇO" +
                                    $"\n{new string('-', 110)}");

                            foreach (var funcionario in funcionarios)
                            {
                                string cpf = funcionario.Cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                                Console.WriteLine($"{funcionario.Id.ToString().PadRight(3)}{cpf.PadRight(13)} {funcionario.Nome.PadRight(30)}" +
                                    $"{funcionario.CentrosDistribuicao.Id.ToString().PadRight(3)}{funcionario.CentrosDistribuicao.RazaoSocial.PadRight(30)}{funcionario.CentrosDistribuicao.Endereco}");
                            }
                            Console.WriteLine("\nPressione uma tecla para voltar\n");
                            break;
                        case "2":
                            var patrimonios = context.Patrimonios;
                            Console.WriteLine($"{"ID".PadRight(3)}{"EQUIPAMENTO".PadRight(20)}{"RESPONSAVEL".PadRight(30)}" +
                                    $"{"ID".PadRight(3)}{"RAZÃO SOCIAL".PadRight(30)}ENDEREÇO" +
                                    $"\n{new string('-', 110)}");

                            foreach (var item in patrimonios)
                            {
                                Console.WriteLine($"{item.Id.ToString().PadRight(3)}{item.Equipamento.PadRight(20)}{item.Responsavel.PadRight(30)}" +
                                    $"{item.CentrosDistribuicao.Id.ToString().PadRight(3)}{item.CentrosDistribuicao.RazaoSocial.PadRight(30)}{item.CentrosDistribuicao.Endereco}");
                            }
                            Console.WriteLine("\nPressione uma tecla para voltar\n");
                            break;
                        case "3":
                            ativo = false;
                            return;
                    }
                    Console.ReadKey();
                    Console.Clear();
                } while (ativo);
            }
            else if (opcaoTabela == 1)
            {
                var context = new DistribuicaoContext();
                var funcionarios = context.Funcionarios;
                Console.WriteLine($"{"ID".PadRight(3)}{"CPF".PadRight(14)}{"NOME".PadRight(30)}" +
                        $"{"ID".PadRight(3)}{"RAZÃO SOCIAL".PadRight(30)}ENDEREÇO" +
                        $"\n{new string('-', 110)}");
                foreach (var funcionario in funcionarios)
                {
                    string cpf = funcionario.Cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                    Console.WriteLine($"{funcionario.Id.ToString().PadRight(3)}{cpf.PadRight(13)} {funcionario.Nome.PadRight(30)}" +
                            $"{funcionario.CentrosDistribuicao.Id.ToString().PadRight(3)}{funcionario.CentrosDistribuicao.RazaoSocial.PadRight(30)}{funcionario.CentrosDistribuicao.Endereco}");
                }
            }
            else if (opcaoTabela == 3)
            {
                var context = new DistribuicaoContext();
                var patrimonios = context.Patrimonios;
                Console.WriteLine($"{"ID".PadRight(3)}{"EQUIPAMENTO".PadRight(20)}{"RESPONSAVEL".PadRight(30)}" +
                        $"{"ID".PadRight(3)}{"RAZÃO SOCIAL".PadRight(30)}ENDEREÇO" +
                        $"\n{new string('-', 110)}");

                foreach (var item in patrimonios)
                {
                    Console.WriteLine($"{item.Id.ToString().PadRight(3)}{item.Equipamento.PadRight(20)}{item.Responsavel.PadRight(30)}" +
                        $"{item.CentrosDistribuicao.Id.ToString().PadRight(3)}{item.CentrosDistribuicao.RazaoSocial.PadRight(30)}{item.CentrosDistribuicao.Endereco}");
                }
            }
        }
    }
}