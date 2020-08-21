using System;
using System.Linq;

namespace TrabalhoCRUD.Context.Menu
{
    public class Excluir
    {
        public static void Executar(int tabela, int id)
        {
            if (tabela == 1)
            {
                ExcluirFuncionario(id);
            }
            else if (tabela == 3)
            {
                ExcluirPatrimonio(id);
            }
            else if (tabela == 2)
            {
                ExcluirCD(id);
            }
        }
        public static void ExcluirFuncionario(int id)
        {
            var context = new DistribuicaoContext();
            var funcionario = context.Funcionarios.FirstOrDefault(q => q.Id == id);
            if (funcionario != null)
            {
                context.Funcionarios.Remove(funcionario);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Funcionário {id} excluido com sucesso! ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Este código de Funcionário não existe");
                Console.ForegroundColor = ConsoleColor.White;
            }
            context.SaveChanges();
        }
        public static void ExcluirPatrimonio(int id)
        {
            var context = new DistribuicaoContext();

            var patrimonio = context.Patrimonios.FirstOrDefault(q => q.Id == id);
            if (patrimonio != null)
            {
                context.Patrimonios.Remove(patrimonio);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Patrimonio {id} excluido com sucesso! ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Este código de Patrimônio não existe");
                Console.ForegroundColor = ConsoleColor.White;
            }
            context.SaveChanges();
        }
        public static void ExcluirCD(int id)
        {
            Console.Write($"O que você deseja fazer com os funcionários e patrimonios associados ao Centro de Distribuição {id}?\n");
            Console.WriteLine($"1 - Para excluir \n2 - Para alterar");
            var excluir = Convert.ToInt32(Console.ReadLine());
            var context = new DistribuicaoContext();
            Console.Clear();

            var cd = context.CentrosDistribuicao.FirstOrDefault(q => q.Id == id);
            if (excluir == 1)
            {
                if (cd != null)
                {
                    var funcionario = context.Funcionarios.FirstOrDefault(q => q.Id == id);
                    if (funcionario != null)
                        context.Funcionarios.Remove(funcionario);
                    var patrimonio = context.Patrimonios.FirstOrDefault(q => q.Id == id);
                    if (patrimonio != null)
                        context.Patrimonios.Remove(patrimonio);

                    context.CentrosDistribuicao.Remove(cd);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"CD {id} excluido com sucesso! ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Este código de CD não existe");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                context.SaveChanges();
            }
            else if (excluir == 2)
            {
                Console.WriteLine("Alterando....");
                AlterarCDFuncionario(id);
                AlterarCDPatrimonio(id);
                context.CentrosDistribuicao.Remove(cd);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"CD {id} excluido com sucesso! ");
                Console.ForegroundColor = ConsoleColor.White;
                context.SaveChanges();
                // escrever codigo de alterar aqui
            }
        }
        public static void AlterarCDFuncionario(int idAlterar)
        {
            var context = new DistribuicaoContext();

            var func = context.Funcionarios.FirstOrDefault(q => q.IdCentroDistribuicao == idAlterar);
            if (func != null)
            {
                Console.WriteLine("Digite o novo CD que esse funcionário pertence: ");
                var id_CD = Convert.ToInt32(Console.ReadLine());
                func.IdCentroDistribuicao = id_CD;
                context.SaveChanges();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida ou não há funcionários pertencentes a esse CD! ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void AlterarCDPatrimonio(int idAlterar)
        {
            var context = new DistribuicaoContext();

            var patrimonio = context.Patrimonios.FirstOrDefault(q => q.IdCentroDistribuicao == idAlterar);
            if (patrimonio != null)
            {
                Console.WriteLine("Digite o novo CD desse patrimônio: ");
                var id_CD = Convert.ToInt32(Console.ReadLine());
                patrimonio.IdCentroDistribuicao = id_CD;
                context.SaveChanges();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida ou não há patrimonios pertencentes a esse CD! ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
