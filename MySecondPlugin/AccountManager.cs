using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySecondPlugin
{
    public class AccountManager : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext executionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(executionContext.UserId);
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            Entity conta = (Entity)executionContext.InputParameters["Target"];

            string cpf = conta["dyp_cpf1"].ToString();

            QueryExpression recuperarContaComCpf = new QueryExpression("account");
            recuperarContaComCpf.Criteria.AddCondition("dyp_cpf1", ConditionOperator.Equal, cpf);
            EntityCollection contas = service.RetrieveMultiple(recuperarContaComCpf);

            if (contas.Entities.Count() > 0)
            {
                throw new InvalidPluginExecutionException("Ja existe uma conta com este CPF");
            }
        }
    }
}
