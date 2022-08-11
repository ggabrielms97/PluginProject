using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Models
{
    internal class Contato
    {
        public IOrganizationService Service { get; set; }

        public Contato(IOrganizationService service)
        {
            this.Service = service;
        }

        private void Create( Guid accontId)
        {
            Entity contato = new Entity("contact");
            contato["firstname"] = "Gabriel";
            contato["lastname"] = "Dos Santos";
            contato["jobtitle"] = "Desenvolvedor Junior";
            contato["parentcustomerid"] = new EntityReference("account", accontId);

            this.Service.Create(contato);
        }
    }
}
