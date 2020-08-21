using System;
using TrabalhoCRUD.Context;

namespace TrabalhoCRUD.Menu
{
    public class ListarGeral
    {
        public static void Executar(int tabelaEscolhida) 
        {
            var context = new DistribuicaoContext();
            switch (tabelaEscolhida)
            {
                case 1:
                    var funcionarios = context.Funcionarios;
                    Console.WriteLine("FUNCIONÁRIOS");
                    Console.WriteLine("===================================================================\n");
                    Console.Write("ID".PadRight(4));
                    Console.Write("Lotação  ");
                    Console.Write("Nome".PadRight(32));
                    Console.Write("CPF".PadRight(16));
                    Console.Write("Data de Nascimento".PadRight(20));
                    Console.Write("Função".PadRight(22));
                    Console.Write("Telefone".PadRight(22));
                    Console.Write("RG".PadRight(17));
                    Console.WriteLine("Endereco");
                    foreach (var f in funcionarios)
                    {
                        Console.Write($"{f.Id}".PadRight(4));
                        Console.Write($"{f.IdCentroDistribuicao}".PadRight(9));
                        Console.Write($"{f.Nome}".PadRight(32));
                        string cpf = f.Cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
                        Console.Write($"{cpf}".PadRight(16));
                        Console.Write($"{f.DataNascimento}".PadRight(20));
                        Console.Write($"{f.Funcao}".PadRight(22));
                        Console.Write($"{f.Telefone}".PadRight(22));
                        Console.Write($"{f.Rg}".PadRight(17));
                        Console.WriteLine($"{f.Endereco}");
                    }
                    break;
                case 2:
                    var centrosDistribuicao = context.CentrosDistribuicao;
                    Console.WriteLine("CENTROS DE DISTRIBUIÇÃO");
                    Console.WriteLine("===================================================================\n");
                    Console.Write("ID".PadRight(4));
                    Console.Write("CNPJ".PadRight(20));
                    Console.Write("Razao Social".PadRight(32));
                    Console.Write("Telefone".PadRight(22));
                    Console.Write("Tipo".PadRight(22));
                    Console.WriteLine("Endereco");
                    foreach (var c in centrosDistribuicao)
                    {
                        Console.Write($"{c.Id}".PadRight(4));
                        string cnpj = c.Cnpj.Insert(2, ".").Insert(6, ".").Insert(10, "/").Insert(15, "-");
                        Console.Write($"{cnpj}  ");
                        Console.Write($"{c.RazaoSocial}  ".PadRight(32));
                        Console.Write($"{c.Telefone}  ".PadRight(22));
                        Console.Write($"{c.Tipo}  ".PadRight(22));
                        Console.WriteLine($"{c.Endereco}");
                    }
                    break;
                case 3:
                    var patrimonios = context.Patrimonios;
                    Console.WriteLine("PATRIMÔNIOS");
                    Console.WriteLine("===================================================================\n");
                    Console.Write("ID".PadRight(4));
                    Console.Write("Lotação".PadRight(9));
                    Console.Write("Equipamento".PadRight(32));
                    Console.Write("Setor".PadRight(22));
                    Console.WriteLine("Responsável");
                    foreach (var p in patrimonios)
                    {
                        Console.Write($"{p.Id}".PadRight(4));
                        Console.Write($"{p.IdCentroDistribuicao}".PadRight(9));
                        Console.Write($"{p.Equipamento}".PadRight(32));
                        Console.Write($"{p.Setor}".PadRight(22));
                        Console.WriteLine($"{p.Responsavel}");
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção de tabela inválida! ");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
