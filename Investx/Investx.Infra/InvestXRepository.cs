using Dapper;
using Investx.Infra.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Investx.Infra
{
    public class InvestXRepository
    {
        public string RecuperarInvestidores()
        {
            var enderecoConexao = GetConnection();

            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    var investidores = nossaconexao.Query<object>("SELECT * FROM [dbinvestimento].[dbo].[Cliente]").ToList();
                    return investidores.ToString();
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
        public void Inserir([FromForm] InvestidoresDTO investidores)

        
        {
            if(investidores.nome!=null) 
            { 
                var enderecoConexao = GetConnection();

                using (var nossaconexao = new SqlConnection((string)enderecoConexao))
                {
                    try
                    {
                        nossaconexao.Open();
                        object p = nossaconexao.Execute("INSERT INTO [dbinvestimento].[dbo].[investidores] VALUES ('" + investidores.nome + "','" + investidores.cpf + "');");
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
        }
        public void Delete(int id)
        
        {
            var enderecoConexao = GetConnection();

            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    var investidores = nossaconexao.Query<object>("DELETE FROM [dbinvestimento].[dbo].[investidores]" + " where id = " + @id).ToList();
                    //investidores.RemoveAt(id);

                    //"DELETE FROM backup" + "WHERE Fitas = " + fita.getText());
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
        public void Atualizar()

        {
            var enderecoConexao = GetConnection();

            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    var investidores = nossaconexao.Query<object>("UPDATE [dbinvestimento].[dbo].[investidores] " + "set cidadeNatal = " + "'Salvador'" + " where id = " + "22").ToList();
                    //"update clientes set nome = @nome, data_nascimento = @data_nascimento, email = @email where id = @id";
                    //"DELETE FROM [dbinvestimento].[dbo].[investidores]" +" where id = " + "21").ToList();
                    //UPDATE investidores set cidade= 'Salvador'  where id = 9
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

        private object GetConnection()
        {
            var connection = "Data Source=CRISTIANO-DELL\\SQLEXPRESS;Database=dbinvestimento;user id=sa;password=90989905;";
            return connection;
        }

    }

}
