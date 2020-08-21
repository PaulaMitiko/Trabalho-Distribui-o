using System;
using System.Linq;
using TrabalhoCRUD.Context;
using TrabalhoCRUD.Context.Models;

namespace TrabalhoCRUD.Funcoes
{
    public class Inserir
    {
        public static void Executar(int opcao) 
        {
            switch (opcao) 
            {
                case 1:
                    InserirFuncionario();
                    break;
                case 2:
                    InserirCD();
                    break;
                case 3:
                    InserirPatrimonio();
                    break;
            }
        }

        public static void InserirFuncionario()
        {
            var context = new DistribuicaoContext();

            Console.WriteLine("Você selecionou a opção de Inserir Funcionário");
            Console.WriteLine("Informe Nome: ");
            var nomeF = Console.ReadLine();

            Console.WriteLine("Informe RG: ");
            var rgF = Console.ReadLine();

            Console.WriteLine("Informe CPF: ");
            var cpf = Console.ReadLine();

            Console.WriteLine("Informe Data de Nascimento: ");
            var data = Console.ReadLine();

            Console.WriteLine("Informe Endereço: ");
            var endereco = Console.ReadLine();

            Console.WriteLine("Informe Telefone: ");
            var telefone = Console.ReadLine();

            Console.WriteLine("Informe Função: ");
            var funcao = Console.ReadLine();

            Console.WriteLine("Informe o CD a qual pertence: ");
            var id_CD = Convert.ToInt32(Console.ReadLine());

            var func = context.Funcionarios.FirstOrDefault(q => q.Cpf == cpf);

            if (func != null)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Este Funcionario já consta na nossa base de dados!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Deseja inserir Novo funcionário? \n S - Sim / N - Não ");
                var resp = Console.ReadLine();
                if (resp.ToUpper() == "S")
                {
                    Console.Clear();
                    InserirFuncionario();
                }
            }
            else
            {
                var funcionario = new Funcionario
                {
                    Nome = nomeF,
                    Rg = rgF,
                    Cpf = cpf,
                    DataNascimento = data,
                    Endereco = endereco,
                    Telefone = telefone,
                    Funcao = funcao,
                    IdCentroDistribuicao = id_CD
                };
                context.Funcionarios.Add(funcionario);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Funcionário Cadastrado com Sucesso!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            context.SaveChanges();
        }
        public static void InserirCD()
        {
            var context = new DistribuicaoContext();

            Console.WriteLine("Você selecionou a opção de Inserir Centro de Distribuição");
            Console.WriteLine("Informe Razão Social (Nome): ");
            var razao = Console.ReadLine();

            Console.WriteLine("Informe CNPJ: ");
            var cnpj = Console.ReadLine();

            Console.WriteLine("Informe Endereco: ");
            var endereco = Console.ReadLine();

            Console.WriteLine("Informe Telefone: ");
            var telefone = Console.ReadLine();

            Console.WriteLine("Informe Tipo de CD (Ramo): ");
            var tipo = Console.ReadLine();

            var centro = context.CentrosDistribuicao.FirstOrDefault(q => q.Cnpj == cnpj);

            if (centro != null)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Este Centro de Distribução já consta na nossa base de dados!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n Deseja inserir Novo CD ? \n S - Sim / N - Não ");
                var resp = Console.ReadLine();
                if (resp.ToUpper() == "S")
                {
                    Console.Clear();
                    InserirCD();
                }
            }
            else
            {
                var centrosdt = new CentroDistribuicao
                {
                    RazaoSocial = razao,
                    Cnpj = cnpj,
                    Endereco = endereco,
                    Telefone = telefone,
                    Tipo = tipo
                };
                context.CentrosDistribuicao.Add(centrosdt);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Centro de Distribuição cadastrado com sucesso!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            context.SaveChanges();
        }
        public static void InserirPatrimonio()
        {
            var context = new DistribuicaoContext();

            Console.WriteLine("Você selecionou a opção de Inserir Patrimônio");
            Console.WriteLine("Informe o equipamento: ");
            var equipamento = Console.ReadLine();

            Console.WriteLine("Informe o responsável: ");
            var responsavel = Console.ReadLine();

            Console.WriteLine("Informe o setor pertencente: ");
            var setor = Console.ReadLine();

            Console.WriteLine("Informe em qual CD ele está localizado: ");
            var id_CD = Convert.ToInt32(Console.ReadLine());

            var patrimonios = new Patrimonio
            {
                Equipamento = equipamento,
                Responsavel = responsavel,
                Setor = setor,
                IdCentroDistribuicao = id_CD
            };
            context.Patrimonios.Add(patrimonios);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Patrimônio cadastrado com sucesso!");
            Console.ForegroundColor = ConsoleColor.White;
            context.SaveChanges();
        }
    }
}