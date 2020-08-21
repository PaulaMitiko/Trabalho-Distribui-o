using System;
using System.Linq;
using TrabalhoCRUD.Context;

namespace TrabalhoCRUD.Menu
{
    public class AlterarCampo
    {
        public static void Executar(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    AlterarUmFuncionario();
                    break;
                case 2:
                    AlterarUmCD();
                    break;
                case 3:
                    AlterarUmPatrimonio();
                    break;
            }
        }
        public static void AlterarUmFuncionario()
        {
            bool validacao;
            var context = new DistribuicaoContext();
            var idFuncAlterar = 0;
            var funcionarios = context.Funcionarios;

            Console.WriteLine("\nQual o Id do funcionario que você deseja alterar os dados.");
            idFuncAlterar = Convert.ToInt32(Console.ReadLine());

            do
            {
                validacao = false;
                foreach (var f in funcionarios)
                {
                    if (idFuncAlterar == f.Id)
                    {
                        validacao = true;
                    }
                }
                if (!validacao) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Número inválido!!! ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Informe um novo número: ");
                    idFuncAlterar = Convert.ToInt32(Console.ReadLine());
                }
            } while (validacao == false);

            var func = context.Funcionarios.FirstOrDefault(q => q.Id == idFuncAlterar);

            Console.WriteLine("Qual campo você gostaria de alterar? ");
            Console.WriteLine("1 - Lotação  ");
            Console.WriteLine("2 - Nome");
            Console.WriteLine("3 - CPF");
            Console.WriteLine("4 - Data de Nascimento");
            Console.WriteLine("5 - Função");
            Console.WriteLine("6 - Telefone");
            Console.WriteLine("7 - RG");
            Console.WriteLine("8 - Endereco");
            int opcao = Convert.ToInt32(Console.ReadLine());

            if (func != null)
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o CD a qual pertence: ");
                        var id_CD = Convert.ToInt32(Console.ReadLine());
                        func.IdCentroDistribuicao = id_CD;
                        context.SaveChanges();
                        break;
                    case 2:
                        Console.WriteLine("Informe o Nome: ");
                        var nomeF = Console.ReadLine();
                        func.Nome = nomeF;
                        context.SaveChanges();
                        break;
                    case 3:
                        Console.WriteLine("Informe CPF: ");
                        var cpf = Console.ReadLine();
                        func.Cpf = cpf;
                        context.SaveChanges();
                        break;
                    case 4:
                        Console.WriteLine("Informe Data de Nascimento: ");
                        var dataNasc = Console.ReadLine();
                        func.DataNascimento = dataNasc;
                        context.SaveChanges();
                        break;
                    case 5:
                        Console.WriteLine("Informe Função: ");
                        var funcao = Console.ReadLine();
                        func.Funcao = funcao;
                        context.SaveChanges();
                        break;
                    case 6:
                        Console.WriteLine("Informe Telefone: ");
                        var telefone = Console.ReadLine();
                        func.Telefone = telefone;
                        context.SaveChanges();
                        break;
                    case 7:
                        Console.WriteLine("Informe RG: ");
                        var rgF = Console.ReadLine();
                        func.Rg = rgF;
                        context.SaveChanges();
                        break;
                    case 8:
                        Console.WriteLine("Informe Endereço: ");
                        var endereco = Console.ReadLine();
                        func.Endereco = endereco;
                        context.SaveChanges();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida! ");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                if (opcao <= 8)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("A alteração foi feita com sucesso!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public static void AlterarUmPatrimonio()
        {
            bool validacao;
            var context = new DistribuicaoContext();
            var idPatAlterar = 0;
            var patrimonios = context.Patrimonios;

            Console.WriteLine("\nQual o Id do patrimonio que você deseja alterar os dados.");
            idPatAlterar = Convert.ToInt32(Console.ReadLine());

            do
            {
                validacao = false;
                foreach (var p in patrimonios)
                {
                    if (idPatAlterar == p.Id)
                    {
                        validacao = true;
                    }
                }
                if (!validacao)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Número inválido!!! ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Informe um novo número: ");
                    idPatAlterar = Convert.ToInt32(Console.ReadLine());
                }
            } while (validacao == false);

            var pat = context.Patrimonios.FirstOrDefault(q => q.Id == idPatAlterar);

            Console.WriteLine("Qual campo você gostaria de alterar? ");
            Console.WriteLine("1 - Lotação");
            Console.WriteLine("2 - Equipamento");
            Console.WriteLine("3 - Setor");
            Console.WriteLine("4 - Responsável");
            int opcao = Convert.ToInt32(Console.ReadLine());

            if (pat != null)
            {
                switch (opcao) 
                {
                    case 1:
                        Console.WriteLine("Informe em qual CD ele está localizado: ");
                        var id_CD = Convert.ToInt32(Console.ReadLine());
                        pat.IdCentroDistribuicao = id_CD;
                        context.SaveChanges();
                        break;
                    case 2:
                        Console.WriteLine("Informe o equipamento: ");
                        var equipamento = Console.ReadLine();
                        pat.Equipamento = equipamento;
                        context.SaveChanges();
                        break;
                    case 3:
                        Console.WriteLine("Informe o setor pertencente: ");
                        var setor = Console.ReadLine();
                        pat.Setor = setor;
                        context.SaveChanges();
                        break;
                    case 4:
                        Console.WriteLine("Informe o responsável: ");
                        var responsavel = Console.ReadLine();
                        pat.Responsavel = responsavel;
                        context.SaveChanges();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida! ");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                if (opcao <= 4) 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("A alteração foi feita com sucesso!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public static void AlterarUmCD()
        {
            bool validacao;
            var context = new DistribuicaoContext();
            var idCDAlterar = 0;
            var centrosdistribuicao = context.CentrosDistribuicao;

            Console.WriteLine("\nQual o Id do centro de distribuição que você deseja alterar os dados.");
            idCDAlterar = Convert.ToInt32(Console.ReadLine());

            do
            {
                validacao = false;
                foreach (var cd in centrosdistribuicao)
                {
                    if (idCDAlterar == cd.Id)
                    {
                        validacao = true;
                    }
                }
                if (!validacao)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Número inválido!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Informe um novo número: ");
                    idCDAlterar = Convert.ToInt32(Console.ReadLine());
                }
            } while (validacao == false);

            var cent = context.CentrosDistribuicao.FirstOrDefault(q => q.Id == idCDAlterar);

            Console.WriteLine("Qual campo você gostaria de alterar? ");
            Console.WriteLine("1 - CNPJ");
            Console.WriteLine("2 - Razao Social");
            Console.WriteLine("3 - Telefone");
            Console.WriteLine("4 - Tipo");
            Console.WriteLine("5 - Endereco");
            int opcao = Convert.ToInt32(Console.ReadLine());

            if (cent != null)
            {
                switch (opcao) 
                {
                    case 1:
                        Console.WriteLine("Informe CNPJ: ");
                        var cnpj = Console.ReadLine();
                        cent.Cnpj = cnpj;
                        context.SaveChanges();
                        break;
                    case 2:
                        Console.WriteLine("Informe Razão Social (Nome): ");
                        var razao = Console.ReadLine();
                        cent.RazaoSocial = razao;
                        context.SaveChanges();
                        break;
                    case 3:
                        Console.WriteLine("Informe Telefone: ");
                        var telefone = Console.ReadLine();
                        cent.Telefone = telefone;
                        context.SaveChanges();
                        break;
                    case 4:
                        Console.WriteLine("Informe Tipo de CD (Ramo): ");
                        var tipo = Console.ReadLine();
                        cent.Tipo = tipo;
                        context.SaveChanges();
                        break;
                    case 5:
                        Console.WriteLine("Informe Endereco: ");
                        var endereco = Console.ReadLine();
                        cent.Endereco = endereco;
                        context.SaveChanges();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida! ");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                if (opcao <= 5)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("A alteração foi feita com sucesso!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
