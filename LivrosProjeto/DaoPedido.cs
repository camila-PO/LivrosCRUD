using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LivrosProjeto
{
    class DaoPedido
    {
        public string dados;
        public string resultado;
        MySqlConnection conexao;
        public int []codigoPedido;
        public decimal[] valorPedido;
        public int i;
        public int contador;
        public string msg;
        public DateTime[] dat;
        MySqlParameter parameter;
        public DateTime data;

        public DaoPedido()
        {
            parameter = new MySqlParameter();
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

        } //fim metodo dao

        public void Inserir(decimal valorPedido, DateTime dat)
        {
            try
            {
               
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = dat.Year + "-" + dat.Month + "-" + dat.Day;
                dados = "('','" + valorPedido +"','" + parameter.Value + "')";
                resultado = "Insert into pedido(codigoPedido, valorPedido, dataPedido) values" + dados;
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
            string query = "select * from pedido";//Coletando o dado do BD

            //Instanciando os vetores
            codigoPedido = new int[100];
            valorPedido = new decimal[100];
            dat = new DateTime[100];
           

            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++)
            {
                codigoPedido[i] = 0;
                valorPedido[i] = 0;
                dat[i] = new DateTime();

            }//fim da repetição

            //Criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            parameter.ParameterName = "@Date";
            parameter.MySqlDbType = MySqlDbType.Date;
            

            i = 0;
            while (leitura.Read())
            {
                codigoPedido[i] = Convert.ToInt32(leitura["codigoPedido"]);
                valorPedido[i] = Convert.ToDecimal(leitura["valorPedido"]);
                parameter.Value = leitura["dataPedido"];
                dat[i] = Convert.ToDateTime(parameter.Value);
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
                msg += "\n\nCódigo do pedido: " + codigoPedido[i]            
                + ", Valor do pedido: " + valorPedido[i] +
                ", Data do Pedido: " + dat[i];

            }//fim do for
            return msg;
        }//fim do consultarTudo
    
        public string ConsultarValorPedido(int codigo)
        {
            PreencherVetor();
            for ( i = 0; i < contador; i++)
            {
                if (codigo == codigoPedido[i])
                {
                    return Convert.ToString(valorPedido[i]);
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultar Valor do Pedido

        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update Pedido set " + campo + " = '" +
                novoDado + "' where codigoPedido = '" + codigo + "'";
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
            resultado = "delete from pedido where codigoPedido = '" + codigo + "'";
            //Executar o comando
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem...
            Console.WriteLine("Dados Excluídos com sucesso!");
        }//fim do deletar









    }//Fim da classe DaoPedido
}//Fim do projeto
