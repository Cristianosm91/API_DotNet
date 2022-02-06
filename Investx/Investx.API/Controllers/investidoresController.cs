using Caelum.Stella.CSharp.Validation;
using Dapper;
//using Investx.Infra;
using Investx.Domain;
using Investx.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Investx.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class investidoresController : ControllerBase
    {

        private readonly ILogger<investidoresController> _logger;
        private readonly IConfiguration _configuration;

        public investidoresController(ILogger<investidoresController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

        }

        [HttpGet]
        public List<Investidores> RecuperarInvestidores()
        {
            List<Investidores> listaInvestidores = new List<Investidores>();
            var classDomainInvestidores = new DomainInvestidores();
            listaInvestidores = classDomainInvestidores.RecuperarInvestidores();
            return listaInvestidores;
        }
        //public string RecuperarInvestidores()
        //{
        //  var classInvestXRepository = new InvestXRepository();
        //  var lista = classInvestXRepository.RecuperarInvestidores();
        //  return lista;
        //}
        //até aqui

        //{
        //    var classInvestXRepository = new InvestXRepository();
        //    classInvestXRepository.RecuperarInvestidores();
        //}
        //public string RecuperarInvestidores()
        //{
        //    var enderecoConexao = GetConnection();

        //    using (var nossaconexao = new SqlConnection(enderecoConexao))
        //    {
        //        try
        //        {
        //            nossaconexao.Open();
        //            var investidores = nossaconexao.Query<object>("SELECT * FROM [dbinvestimento].[dbo].[investidores]").ToList();
        //            return investidores.ToString();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        finally
        //        {
        //            nossaconexao.Close();
        //        }

        //    }

        //}


        //private string GetConnection()
        //{
        //    var connection = _configuration.GetSection("DefaultConnection").
        //                    GetSection("ConnectionString").Value;
        //    return connection;
        //}

        [HttpDelete]
        // DELETE api/values/5
        //daqui
        public void Delete([FromForm] int id)
        {

            var classDomainInvestidores = new DomainInvestidores();
            classDomainInvestidores.Deletar(id);
        }
        //aqui
        //public void Delete(int id)
        //{
        //    var enderecoConexao = GetConnection();

        //    using (var nossaconexao = new SqlConnection(enderecoConexao))
        //    {
        //        try
        //        {
        //            nossaconexao.Open();
        //            var investidores = nossaconexao.Query<object>("DELETE FROM [dbinvestimento].[dbo].[investidores]" +" where id = " + @id).ToList();
        //            //investidores.RemoveAt(id);

        //            //"DELETE FROM backup" + "WHERE Fitas = " + fita.getText());
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        finally
        //        {
        //            nossaconexao.Close();
        //        }

        //    }

        //}


        [HttpPost]

            public void Insert([FromForm] Investidores investidores)
        {

            var classDomainInvestidores = new DomainInvestidores();
            classDomainInvestidores.Insert(investidores);
        }
        //    public void Inserir([FromForm] Investidores investidores)
        //{
        //    var classInvestXRepository = new InvestXRepository();
        //    classInvestXRepository.Inserir(investidores);
        //}

       /*   public void Inserir([FromForm]Investidores investidores)
        
        {
            var enderecoConexao = GetConnection();

            using (var nossaconexao = new SqlConnection(enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("INSERT INTO [dbinvestimento].[dbo].[investidores] VALUES ('" + investidores.nome + "','" + investidores.cpf + "');");
                    //var investidores = nossaconexao.Query<object>("INSERT INTO [dbinvestimento].[dbo].[investidores](nome,cpf) " + "VALUES ('Pedro', 97885412311)").ToList();
                    //"insert into clientes(nome, data_nascimento, email) values(@nome, @data_nascimento, @email)"
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    nossaconexao.Close();
                }

            }

        }
     */
        [HttpPut]
        public void Atualizar(Investidores investidores, int id)

        {
            var classDomainInvestidores = new DomainInvestidores();
            classDomainInvestidores.Atualizar(investidores, id);
        
            }
            //    var enderecoConexao = GetConnection();

            //    using (var nossaconexao = new SqlConnection(enderecoConexao))
            //    {
            //        try
            //        {
            //            nossaconexao.Open();
            //            var investidores = nossaconexao.Query<object>("UPDATE [dbinvestimento].[dbo].[investidores] " + "set cidadeNatal = " +"'Salvador'" + " where id = " + "22").ToList();
            //            //"update clientes set nome = @nome, data_nascimento = @data_nascimento, email = @email where id = @id";
            //            //"DELETE FROM [dbinvestimento].[dbo].[investidores]" +" where id = " + "21").ToList();
            //            //UPDATE investidores set cidade= 'Salvador'  where id = 9
            //        }
            //        catch (Exception ex)
            //        {
            //            throw new Exception(ex.Message);
            //        }
            //        finally
            //        {
            //            nossaconexao.Close();
            //        }

            //    }

            //}

        }
}
