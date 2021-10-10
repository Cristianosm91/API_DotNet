using Investx.Infra;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Investx.Infra.DTO;
using Investx.Domain.Entidades;

namespace Investx.Domain
{
    public class DomainInvestidores
    
    {        
            public void Insert([FromForm] Investidores investidores)
            {
            if (investidores.nome != null)
            {
                var classInvestXRepository = new InvestXRepository();
                var investidoresDTO = new InvestidoresDTO();
                investidoresDTO = ConverterCliente(investidores);
                classInvestXRepository.Inserir(investidoresDTO);
            }
            }

        public InvestidoresDTO ConverterCliente(Investidores investidores)
        {
            var cli = new InvestidoresDTO();
            cli.cpf = investidores.cpf;
            cli.nome = investidores.nome;
            
            return cli;
        }

    }
}
