using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Models
{
    internal class Conta
    {

        public IOrganizationService Service { get; set; }

        public string LogicalName = "account";

        public Conta(IOrganizationService service)
        {
            this.Service = service;
        }

        private static void Create(IOrganizationService service)
        {
            Entity conta = new Entity("account");
            conta["name"] = "Nova Conta - Campos personalizados";
            conta["telephone1"] = "(22)99928-6332";
            conta["fax"] = "13516848864";
            conta["websiteurl"] = "dynacoop.com.br";

            Guid accontId = service.Create(conta);
        }

        public bool Update(Guid accountId)
        {
            Entity conta = new Entity(this.LogicalName);
            conta.Id = accountId;
            conta["name"] = "Conta Atualizada";
            this.Service.Update(conta);
            return true;
        }

        public void Delete(Guid accountId)
        {
            this.Service.Delete(this.LogicalName, accountId);
        }
        private static void CriarEdicao(IOrganizationService service)
        {
            Console.WriteLine("Você deseja atualizar ou deletar uma conta? Digite A para atualizar e D para deletar (A/D)");
            var respostaDoUsuario = Console.ReadLine();

            if (respostaDoUsuario == "A")
            {
                UpdateAccount(service);
            }
            else
            {
                if (respostaDoUsuario == "D")
                {
                    DeleteAccount(service);
                }
                else
                {
                    Console.WriteLine("Não foi Possivel entender a sua digitação. Tente novamente");
                }
            }
        }
        private static void DeleteAccount(IOrganizationService service)
        {
            Console.WriteLine("Digite o id que você deseja deletar");
            var idParaDeletar = Console.ReadLine();

            if (ValidateGuid(idParaDeletar))
            {
                Conta conta = new Conta(service);
                conta.Delete(new Guid(idParaDeletar));
            }
        }

        private static bool ValidateGuid(string id)
        {
            if (id.ToString().Count() == 36)
            {
                Console.WriteLine("Id validado com sucesso");
                return true;
            }
            else
            {
                Console.WriteLine("Falha ao validar o id");
                return false;
            }
        }

        private static void UpdateAccount(IOrganizationService service)
        {
            Console.WriteLine("Por favor informa o nome da Conta que será atualizado");
            var nomeDaConta = Console.ReadLine();

            Console.WriteLine("Por favor informe o id da conta");
            var idDaConta = Console.ReadLine();

            if (ValidateGuid(idDaConta))
            {
                Console.WriteLine("Informações validadas. Atualizando Conta...");
                Conta conta = new Conta(service);
                conta.LogicalName = nomeDaConta;
                bool success = conta.Update(new Guid(idDaConta));

                if (success)
                {
                    Console.WriteLine("Conta atualizada com socesso");
                }
                else
                {
                    Console.WriteLine("Erro ao atualizar a conta");
                }
            }
        }
    }
}
