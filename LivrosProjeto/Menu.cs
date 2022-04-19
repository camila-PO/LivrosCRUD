using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrosProjeto
{
    class Menu
    {
        DaoDadosCartao daoDadosCartao;
        DaoCatalogo daoCatalogo;
        DaoPedido daoPedido;
        Dao dao;
        public int opcao;
        public int alternativa;
          

        public Menu()
        {
            opcao = 0;
            alternativa = 0;
            dao = new Dao();
            daoPedido = new DaoPedido();
            daoCatalogo = new DaoCatalogo();
            daoDadosCartao = new DaoDadosCartao();
    
        
        } //Fim do metodo construtor

        public void MostrarOpcoes()
        {          
            Console.WriteLine("\n\nEscolha uma das opções abaixo: \n\n" +
            "\n1. Cadastrar" +
            "\n2. Consultar Tudo" +
            "\n3. Consultar Individual" +
            "\n4. Atualizar" +
            "\n5. Excluir" +
            "\n6. Voltar ao menu inicial.");
          

            opcao = Convert.ToInt32(Console.ReadLine());
            if (opcao == 6)
            {
                OpcoesUm();
            }

        }//fim do método Mostrar Opcoes

        public void OpcoesUm()
        {
            Console.WriteLine("\n\nEscolha qual tabela deseja utilizar: \n\n" +
               "\n1.Cliente" +
               "\n2.Pedido" +
               "\n3.Livro" +
               "\n4.Cartão");
             
           alternativa = Convert.ToInt32(Console.ReadLine());

            switch (alternativa)
            {
                case 1:
                    ExecutarCliente();
                    break;
                case 2:
                    ExecutarPedido();
                    break;
                case 3:
                    ExecutarCatalogo();
                    break;
                case 4:
                    ExecutarDadosCartao();
                    break;               

            } // fim do switch case

        }//fim do método OpcoesUm



        public void ExecutarPedido()
        {
            do 
            {
                MostrarOpcoes();
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o valor do pedido: ");
                        decimal valorPedido = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Insira  a data do Pedido: ");
                        DateTime dat = DateTime.Parse(Console.ReadLine());
                        daoPedido.Inserir(valorPedido, dat);
                        break;

                    case 2:
                        Console.WriteLine(daoPedido.ConsultarTudo());
                        break;

                    case 3:
                        Console.WriteLine("Informe o codigo do pedido que deseja consultar: ");
                        int codigo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Valor do Pedido: " + daoPedido.ConsultarValorPedido(codigo));                           
                        break;

                    case 4:
                        //Atualizar
                        Console.WriteLine("Qual campo do pedido deseja atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o código do pedido que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        daoPedido.Atualizar(campo, novoDado, codigo);
                        break;

                    case 5:
                        //Deletar
                        Console.WriteLine("Informe o código do pedido que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //Usar o método da classe DAO
                        daoPedido.Deletar(codigo);
                        break;

                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;

                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;

                } //Fim do switch case

            } while (opcao != 0);
        }//Fim do método Executar Pedido




        public void ExecutarCliente()
        {
            do
            {
                MostrarOpcoes();
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Informe o Telefone: ");
                        string telefone = Console.ReadLine();
                        Console.WriteLine("Informe o endereço: ");
                        string endereco = Console.ReadLine();
                        Console.WriteLine("Informe o Login ");
                        string login = Console.ReadLine();
                        Console.WriteLine("Informe o senha: ");
                        string senha = Console.ReadLine();

                        dao.Inserir(nome, telefone, endereco, login, senha);
                        break;

                    case 2:
                        Console.WriteLine(dao.ConsultarTudo());
                        break;

                    case 3:
                        Console.WriteLine("Informe o codigo que deseja consultar: ");
                        int codigo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Nome: " + dao.ConsultarNome(codigo) +
                            "\nTelefone: " + dao.ConsultarTelefone(codigo) +
                            "\nEndereço: " + dao.ConsultarEndereco(codigo) +
                            "\nLogin: " + dao.ConsultarLogin(codigo) +
                            "\nSenha: " + dao.ConsultarSenha(codigo));

                        break;

                    case 4:
                        //Atualizar
                        Console.WriteLine("Qual campo desejas atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o código da pessoa que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        dao.Atualizar(campo, novoDado, codigo);
                        break;

                    case 5:
                        //Deletar
                        Console.WriteLine("Informe o código que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //Usar o método da classe DAO
                        dao.Deletar(codigo);
                        break;

                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;

                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;

                } //Fim do switch case


            } while (opcao != 0);

        }// fim do metodo executar Cliente

        public void ExecutarCatalogo()
        {
            do
            {
                MostrarOpcoes();
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o ISBN: ");
                        string ISBN = Console.ReadLine();
                        Console.WriteLine("Informe o Titulo: ");
                        string titulo = Console.ReadLine();
                        Console.WriteLine("Informe o autor: ");
                        string autor = Console.ReadLine();
                        Console.WriteLine("Informe o preço: ");
                        double preco= Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Informe a editora: ");
                        string editora = Console.ReadLine();
                        Console.WriteLine("Informe a quantidade em estoque: ");
                        int qtdEstoque = Convert.ToInt32(Console.ReadLine());

                        daoCatalogo.Inserir(ISBN, titulo, autor, preco, editora, qtdEstoque);
                        break;

                    case 2:
                        Console.WriteLine(daoCatalogo.ConsultarTudo());
                        break;

                    case 3:
                        Console.WriteLine("Informe o codigo que deseja consultar: ");
                        int codigo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ISBN: " + daoCatalogo.ConsultarISBN(codigo) +
                            "\nTitulo: " + daoCatalogo.ConsultarTitulo(codigo) +
                            "\nAutor: " + daoCatalogo.ConsultarAutor(codigo) +
                            "\nPreço: " + daoCatalogo.ConsultarPreco(codigo) +
                            "\nEditora: " + daoCatalogo.ConsultarEditora(codigo) +
                            "\nQuantidade em Estoque: " + daoCatalogo.ConsultarQtdEstoque(codigo));
                        break;

                    case 4:
                        //Atualizar
                        Console.WriteLine("Qual campo desejas atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o código do livro que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        daoCatalogo.Atualizar(campo, novoDado, codigo);
                        break;

                    case 5:
                        //Deletar
                        Console.WriteLine("Informe o código do livro que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //Usar o método da classe DAO
                        daoCatalogo.Deletar(codigo);
                        break;

                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;

                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;

                } //Fim do switch case


            } while (opcao != 0);

        }// fim do metodo executar Catalogo

        public void ExecutarDadosCartao()
        {
            do
            {
                MostrarOpcoes();
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o Numero do Cartão: ");
                        string numeroCartao = Console.ReadLine();
                        Console.WriteLine("Informe o nome Do titular do cartão: ");
                        string nomeCartao = Console.ReadLine();
                        Console.WriteLine("Informe o Código de segurança: ");
                        string codSeguranca = Console.ReadLine();                   

                        daoDadosCartao.Inserir(numeroCartao, nomeCartao, codSeguranca);
                        break;

                    case 2:
                        Console.WriteLine(daoDadosCartao.ConsultarTudo());
                        break;

                    case 3:
                        Console.WriteLine("Informe o codigo do cartão que deseja consultar: ");
                        int codigo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Numero do cartão: " + daoDadosCartao.ConsultarNumeroCartao(codigo) +
                            "\nNome do titular: " + daoDadosCartao.ConsultarNomeCartao(codigo) +
                            "\nCódigo de segurança: " + daoDadosCartao.ConsultarCodigoSeguranca(codigo));                 
                        break;

                    case 4:
                        //Atualizar
                        Console.WriteLine("Qual campo deseja atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o código do cartão que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        daoDadosCartao.Atualizar(campo, novoDado, codigo);
                        break;

                    case 5:
                        //Deletar
                        Console.WriteLine("Informe o código do crtão que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //Usar o método da classe DAO
                        daoDadosCartao.Deletar(codigo);
                        break;

                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;

                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;

                } //Fim do switch case


            } while (opcao != 0);

        }// fim do metodo executar Dados do cartão

    }//Fim da classe menu
}//Fim do projeto
