using Dapper;
using Investx.Infra.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Investx.Infra
{
    public class InvestXRepository
    {
        public List<InvestidoresDTO> RecuperarInvestidores()
        {
            var enderecoConexao = GetConnection();

            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    var investidores = nossaconexao.Query<InvestidoresDTO>("SELECT * FROM [dbinvestimento].[dbo].[investidores]").AsList();
                    return investidores;
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
                        object p = nossaconexao.Execute($"INSERT INTO dbinvestimento.dbo.investidores(nome,cpf,ativo,rg) VALUES ('{investidores.nome}', '{investidores.cpf}', '{investidores.ativo}', '{investidores.rg}');");
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
        public void Atualizar(InvestidoresDTO investidores, int id)

        {
            var enderecoConexao = GetConnection();

            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Query<object>($"UPDATE dbinvestimento.dbo.investidores set nome ='{investidores.nome}', cpf ='{investidores.cpf}', ativo ='{investidores.ativo}', rg = '{investidores.rg}' where id = {id};");
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
