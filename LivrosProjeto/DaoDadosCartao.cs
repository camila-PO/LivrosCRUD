using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LivrosProjeto
{
    class DaoDadosCartao
    {
        public string dados;
        public string resultado;
        MySqlConnection conexao;
        public int[] codigoCartao;
        public string[] numeroCartao;
        public string[] nomeCartao;
        public string[] codSeguranca;
        public int i;
        public int contador;
        public string msg;

            public DaoDadosCartao()
            {
                conexao = new MySqlConnection("server=localhost;DataBase=livros;Uid=root;password=;");
                try
                {
                    conexao.Open();
                    Console.WriteLine("Conexão bem sucedida!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Algo deu errado!\n\n" + e);
                    conexao.Close();
                }

            } //fim metodo dao dados cartao

        public void Inserir(string numeroCartao, string nomeCartao, string CodSeguranca)
        {
            try
            {
                dados = "('','" + numeroCartao + "','" + nomeCartao + "','" + codSeguranca + "')";
                resultado = "Insert into DadosCartao(codigoCartao, numeroCartao, nomeCartao, codSeguranca) values" + dados;
                //Executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + " Linha(s) Afetada(s)!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
            }//fim do catch
        }//fim do método inserir

        public void PreencherVetor()
        {
            string query = "select * from dadosCartao";//Coletando o dado do BD

            //Instanciando os vetores
            codigoCartao = new int[100];
            numeroCartao = new string[100];
            nomeCartao = new string[100];
            codSeguranca = new string[100];
           

            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++)
            {
                codigoCartao[i] = 0;
                numeroCartao[i] = "";
                nomeCartao[i] = "";
                codSeguranca[i] = "";

            }//fim da repetição


            //Criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                codigoCartao[i] = Convert.ToInt32(leitura["codigoCartao"]);
                numeroCartao[i] = leitura["numeroCartao"] + "";
                nomeCartao[i] = leitura["nomeCartao"] + "";
                codSeguranca[i] = leitura["codSeguranca"] + "";               
                i++;
                contador++;
            }//fim do while

            //Fechar o dataReader
            leitura.Close();
        }//fim do preencher Vetor


        public string ConsultarTudo()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\nCódigo: " + codigoCartao[i]
                + ", Numero do cartao: " + numeroCartao[i]
                + ", nome no cartao: " + nomeCartao[i]
                + ", Codigo de segurança: " + codSeguranca[i];
               
            }//fim do for
            return msg;
        }//fim do consultarTudo

        public string ConsultarNumeroCartao(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codigoCartao[i])
                {
                    return numeroCartao[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultar numero do cartao

        public string ConsultarNomeCartao(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codigoCartao[i])
                {
                    return nomeCartao[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultar nome no cartao

        public string ConsultarCodigoSeguranca(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codigoCartao[i])
                {
                    return codSeguranca[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultar codigo de segurança

        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update DadosCartao set " + campo + " = '" +
                novoDado + "' where codigoCartao = '" + codigo + "'";
                //Executar o script
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizado com Sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!" + e);
            }
        }//fim do atualizar

        public void Deletar(int codigo)
        {
            resultado = "delete from DadosCartao where codigoCartao = '" + codigo + "'";
            //Executar o comando
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem...
            Console.WriteLine("Dados Excluídos com sucesso!");
        }//fim do deletar


















    }//fim da classe dao dados cartao
}//fi do projeto
