using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

// para os using acima > referencia > acicionar MySql.Data

namespace LivrosProjeto
{
    class Dao
    {
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        public int[] cod;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public string[] login;
        public string []senha;
        public int i;
        int contador;
        public string msg;
        public Dao()
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
        
        } //fim metodo dao    

        public void Inserir (string nome, string telefone, string endereco, string login, string senha)
        {
            try
            {
                dados = "('','" + nome + "','" + telefone + "','" + endereco + "','" + login + "','" + senha + "')";
                resultado = "insert into Cliente(cod, nome, telefone, endereco, login, senha) values" + dados;
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
            string query = "select * from Cliente";//Coletando o dado do BD

            //Instanciando os vetores
            cod = new int[100];
            nome = new string[100];
            telefone = new string[100];
            endereco = new string[100];
            login = new string[100];
            senha = new string[100];

            //Dar valores iniciais para ele
            for (i = 0; i < 100; i++)
            {
                cod[i] = 0;
                nome[i] = "";
               

            }//fim da repetição



            //Criar o comando para coleta de dados
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar o comando lendo os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                cod[i] = Convert.ToInt32(leitura["cod"]);
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                login[i] = leitura["login"] + "";
                senha[i] = leitura["senha"] + "";
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
                msg += "\n\nCódigo: " + cod[i]
                + ", Nome: " + nome[i]
                + ", Telefone: " + telefone[i]
                + ", Endereço: " + endereco[i]
                +", Login: " + login[i]
                +", Senha: " + senha[i];
            }//fim do for
            return msg;
        }//fim do consultarTudo

        public string ConsultarNome(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return nome[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarNome

        public string ConsultarTelefone(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return telefone[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarTelefone

        public string ConsultarEndereco(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return endereco[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarEndereço

        public string ConsultarLogin(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return login[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarLogin

        public string ConsultarSenha(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return senha[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarEndereço

        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update Cliente set " + campo + " = '" +
                novoDado + "' where cod = '" + codigo + "'";
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
               resultado = "delete from cliente where cod = '" + codigo + "'";
               //Executar o comando
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                //Mensagem...
                Console.WriteLine("Dados Excluídos com sucesso!");
        }//fim do deletar







    }//Fim da classe
}// Fim do Pojeto
