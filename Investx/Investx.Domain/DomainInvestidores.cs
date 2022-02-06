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
            cli.nome = investidores.nome;
            cli.cpf = investidores.cpf;
            cli.ativo = investidores.ativo;
            cli.rg = investidores.rg;
            return cli;
        }

        public void Atualizar(Investidores investidores, int id) {

            var classInvestXRepository = new InvestXRepository();
            var investidoresDTO = new InvestidoresDTO();
            investidoresDTO = ConverterCliente(investidores);
            classInvestXRepository.Atualizar(investidoresDTO, id);
        }

        public List<Investidores> RecuperarInvestidores()
        {
            List<Investidores> listaInvestidores;
            var classInvestXRepository = new InvestXRepository();

            listaInvestidores = ConverterLista(classInvestXRepository.RecuperarInvestidores());
            return listaInvestidores;
        }

        public static List<Investidores> ConverterLista(List<InvestidoresDTO> listaInvestidoresDTO)
        {
            List<Investidores> listaInvestidores = new();

            var InvestidoresConvertidos = new Investidores();

            for (int i = 0; i < listaInvestidoresDTO.Count; i++)
            {
                InvestidoresConvertidos.nome = listaInvestidoresDTO[i].nome;
                InvestidoresConvertidos.cpf = listaInvestidoresDTO[i].cpf;
                InvestidoresConvertidos.rg = listaInvestidoresDTO[i].rg;
                InvestidoresConvertidos.ativo = listaInvestidoresDTO[i].ativo;

                listaInvestidores.Add(InvestidoresConvertidos);
            }
            return listaInvestidores;
        }

        public void Deletar(int id)
        {
            var classInvestXRepository = new InvestXRepository();
            //var investidoresDTO = new InvestidoresDTO();
            //investidoresDTO = ConverterCliente(investidores);
            classInvestXRepository.Delete(id);
        }
    }
}
