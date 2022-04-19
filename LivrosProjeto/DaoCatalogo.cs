using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LivrosProjeto
{
    class DaoCatalogo
    {
        MySqlConnection conexao;
        public string dados;
        public string resultado;

        public int[] codLivro;
        public string[] ISBN;
        public string[] titulo;
        public string[] autor;
        public double[] preco;
        public string[] editora;
        public int[] qtdEstoque;

        public int i;
        public int contador = 0;
        public string msg;

        public DaoCatalogo()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=livros;Uid=root;Password=;");
            try
            {
                conexao.Open();
                Console.WriteLine("Conexão bem sucedida!");
            }
            catch (Exception e)
            { 
                Console.WriteLine("Algo deu errado!");
            }//fim da tentativa de conexao
        }//fim do método

        public void Inserir(string ISBN, string titulo, string autor, double preco, string editora, int qtdEstoque)
        {
            try
            {
                dados = "('','" + ISBN + "','" + titulo + "','" + autor + "','" + preco + "','" + editora + "','" + qtdEstoque + "')";
                resultado = "insert into catalogo(codLivro, ISBN, titulo, autor, preco, editora, qtdEstoque) values" + dados;

                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + " Linha(s) afetada(s)!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
            }//fim do catch
        }//fim do inserir

        public void PreencherVetor()
        {
            string query = "select * from catalogo";

            codLivro = new int[100];
            ISBN = new string[100];
            titulo = new string[100];
            autor = new string[100];
            preco = new double[100];
            editora = new string[100];
            qtdEstoque = new int[100];

            for (i = 0; i < 100; i++)
            {
                codLivro[i] = 0;
                ISBN[i] = "";
                titulo[i] = "";
                autor[i] = "";
                preco[i] = 0;
                editora[i] = "";
                qtdEstoque[i] = 0;
            }//fim da repetição

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                codLivro[i] = Convert.ToInt32(leitura["codLivro"]);
                ISBN[i] = leitura["ISBN"] + "";
                titulo[i] = leitura["titulo"] + "";
                autor[i] = leitura["autor"] + "";
                preco[i] = Convert.ToDouble(leitura["preco"]);
                editora[i] = leitura["editora"] + "";
                qtdEstoque[i] = Convert.ToInt32(leitura["qtdEstoque"]);
                i++;
                contador++;
            }//fim do while

            leitura.Close();
        }//fim do preencher vetor

        public string ConsultarTudo()
        {
            PreencherVetor();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\nCodigo do livro: " + codLivro[i] +
                    ", ISBN: " + ISBN[i] +
                    ", titulo: " + titulo[i] +
                    ", autor: " + autor[i] +
                    ", preco: " + preco[i] +
                    ", editora: " + editora[i] +
                    ", qtdEstoque: " + qtdEstoque[i];
            }//fim do for
            return msg;
        }//fim do consultarTudo

        public string ConsultarISBN(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codLivro[i])
                {
                    return Convert.ToString(ISBN[i]);
                }
            }//fim do for
            return "código não encontrado!";
        }//fim do consultarISBN

        public string ConsultarTitulo(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codLivro[i])
                {
                    return titulo[i];
                }
            }//fim do for
            return "código não encontrado!";
        }//fim do consultarTitulo

        public string ConsultarAutor(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codLivro[i])
                {
                    return autor[i];
                }
            }//fim do for
            return "código não encontrado!";
        }//fim do consultarAutor

        public string ConsultarPreco(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codLivro[i])
                {
                    return Convert.ToString(preco[i]);
                }
            }//fim do for
            return "código não encontrado!";
        }//fim do consultarPreco

        public string ConsultarEditora(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codLivro[i])
                {
                    return editora[i];
                }
            }//fim do for
            return "código não encontrado!";
        }//fim do consultarEditora

        public string ConsultarQtdEstoque(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codLivro[i])
                {
                    return Convert.ToString(qtdEstoque[i]);
                }
            }//fim do for
            return "código não encontrado!";
        }//fim do consultarQtdEstoque

        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update catalogo set " + campo + " = '" +
                    novoDado + "' where codLivro = '" + codigo + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!");
            }
        }//fim do atualizar

        public void Deletar(int codigo)
        {
            resultado = "delete from catalogo where codLivro = '" + codigo + "'";
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            Console.WriteLine("Dados excluídos com sucesso!");

        }//fim do deletar
    }//fim da classe
}//fim do projeto
