using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpInciantes.BiblioTerm
{

    /*
            Este é o meu primeiro projeto desenvolvido sozinho(Apenas inspirei-me na ideia do Projeto
        do material que estou estudando csharp). Eu estou sentindo uma necessidade imensa de praticar 
        o que estudo.

        A idéia principal do projeto é implementar uma biblioteca no console do visual code, com algumas
        funções planejadas. Até o momento, no escopo do projeto a qual defini, o acesso ao sistema terá 
        apenas funções de controle direcionadas ao operador da Bibliteca. 

        Funções nesta primeira versão:

            *Cadastro de Livro e vizualização do estoque.    
            *Realização de cadastro de imprestimo bem como vizualização do emprestimo.
            *Ação de devolução
            *...
        
        Tenho como principal objetivo praticar o manuseio de classes, métodos e inferfaces como também a
        a orientação à objetos e algoritmos básicos. 



    */
    internal class Principal_Biblioteca
    {
        static private string opcaoMenu = "";    
        internal static void Main(string [] args)
        {     
        
        //Instanciamento da classe de cadastro predefinido de algumas obras, para vizualização.
        CadastroMaterial materialCadastrado = new CadastroMaterial();
        materialCadastrado.Cadastro();//Chmando o método de Cadastro, que realiza o cadastro de algumas obras para teste..

        //Instânciamento do objeto que contém os menus da biblioteca.
        //Na classe MenuBiblioteca estarão definidos todos os menus do programa.
        MenuBibloteca primeiroMenu = new MenuBibloteca();
        
        //Instânciamento do objeto responsável pelo esmpréstimo.
        ControleEmprestimo ContrEmprestimo = new ControleEmprestimo();

        //Realização de empréstimo teste.
        //ContrEmprestimo.realizacaoEmprestimo(materialCadastrado,"Teste Emprestimo","Zaza",123654);
        
        
            primeiroMenu.MenuBoasVindas();//Iniciação da biblioteca.


                //Essa estrutura de repetição controla a navegação pelo menu. "0" o progama encerra.
                while(opcaoMenu !="0" )
                {
                    //Na repetição, o menu principal sempre será exibido para a escolha da operação a ser realizada.
                    primeiroMenu.MenuPrincipalBibliotca();
                    opcaoMenu = capturaOpcao();//Leitura da opção informada.

                    //A opcao "1" possibilita a pesquisa de material cadastrado. A pesquisa é realizada pelo nome e é retornado uma lista com a ocorrência.
                    if(opcaoMenu =="1")
                    {
                        var outraOpcao ="";
                        primeiroMenu.tipoPesqMaterial();
                        WriteLine("*Insira o tipo de pesquisa: \n*");
                        outraOpcao = capturaOpcao();
                            
                        if(outraOpcao == "1")
                        {
                            WriteLine("Informe o título do livro");
                            string? texto = ReadLine();
                            texto = valor(texto);
                
                            if(!(texto is null))
                            {
                                string [] ocor = vizuMat(materialCadastrado,texto);
                                WriteLine("Obras com este título: ");
                                if(ocor.Length>0)
                                {
                                    WriteLine($"Titulo: {ocor[0]} - Qntd:{ocor.Length}");
                                }else
                                {
                                    WriteLine($"Nenhuma obra encontrada ou disponível");
                                }
                                ReadKey();
                            }
                        }
                        else
                        {
                            WriteLine("Informe uma opção de pesquisa válida");
                        }   
                    }

                    if(opcaoMenu == "2")
                    {
                        string ? opcLocal = "";
                        primeiroMenu.consultarEmprestimo();
                        opcLocal = ReadLine();
                        opcLocal = valor(opcLocal);

                        if(opcLocal == "1")
                        {
                           ContrEmprestimo.ListarEmprestimos(); 
                        }
                    }

                    if(opcaoMenu == "3")
                    {
                        primeiroMenu.realizarEmprestimo();
                        string ? tituloPes = ReadLine();
                        tituloPes = valor(tituloPes);
                        WriteLine("#   Informe o seu nome    #");
                        WriteLine("*                         *");
                        string ? nomeP = ReadLine();
                        nomeP = valor(nomeP);

                        WriteLine("# Informe o sua matricula(NUMÉRICA) #");
                        WriteLine("*                                   *");

                        string mat = ReadLine()??"000";
                        int Mat = valorN(mat);

                        ContrEmprestimo.realizacaoEmprestimo(materialCadastrado,tituloPes,nomeP,Mat);                       
                    }

                    if(opcaoMenu == "4")
                    {
                        string ? matDevolucao = "";
                        string ? escolhaDev = "";
                        primeiroMenu.devolucaoEmp();
                        matDevolucao = ReadLine()??"0";
                        int matDev = valorN(matDevolucao);
                        ContrEmprestimo.devolucaoEmprestimo(matDev);
                        escolhaDev = ReadLine()??"0";
                        int escDev = valorN(escolhaDev);
                        ContrEmprestimo.realizarDevolucao(escDev);

                    }

                    if(opcaoMenu == "5")
                    {
                        Console.Clear();

                        try
                        {
                            RealizaCadastro(materialCadastrado);
                        }
                        catch(FormatException ex){

                            WriteLine("Informe os valores numéricos corretamente :)");
                            WriteLine($"Erro - {ex}");
                        }  
                    }
                }
    }

        //O método capturaOpcao é usado para normalizar as escolhas do menu. O método só irá retornar uma opção no caso da opção informada
        //for não nula e estar entre as listadas de 0 à 5. Nas excessões será retornada a mensagem de informar uma opção válida.
        private static string capturaOpcao()
        {

            string [] opc = {"0","1","2","3","4","5"};


            string? valorOPC = "";
           
                try{
                        valorOPC = ReadLine();              
                        if(opc.Contains(valorOPC) && !(valorOPC is null))
                        {
                        return valorOPC;   
                        }
                        }
                        catch(Exception ex)
                        {
                        WriteLine($"Informe uma opcao válida -  {ex}");
                        }
                             return "Informe uma opção válida";
        }

        //vizuMat -> Método provisório que retorna um array ocorrencia com todos as obras condizentes com a pesquisa.
        internal static string[] vizuMat(CadastroMaterial cad,string nome)
        {
            string[]? ocorrencia = cad.Pesq(nome);
            return ocorrencia;
        }

        internal static void RealizaCadastro(CadastroMaterial Pesq)
        {

            int contOp = 1;

            WriteLine("Cadastrar material");
            
            while(contOp == 1){

                WriteLine("------ Biblioteca V0 ------");
                WriteLine("#     Cadastro de Mat:    #");
                WriteLine("# Informe o título da obra:");
                string? tit = ReadLine();
                tit = valor(tit);

                WriteLine("# Informe o autor: ");
                string? aut = ReadLine();
                aut = valor(aut);

                WriteLine("# Quantidade de paginas: ");
                string Pags = ReadLine()??"0";
                
                int pags = valorN(Pags);
                

                WriteLine("# Quantidade de unidades ");
                string? Quant = ReadLine()??"1";
                int quant = valorN(Quant);

                if(tit != null && aut != null && pags != 0 && quant !=0){
                
                    WriteLine(Pesq.CadastroMat(tit,aut,pags,quant));
                
                    contOp = 0;
                }

                else if(tit == null || aut == null || pags <= 0 || quant <= 0)

                {
                    WriteLine("------ Biblioteca V0 ------");
                    WriteLine("#     Cadastro de Mat:    #");
                    WriteLine("#     Informe os dados    #");
                    WriteLine("#      Corretamente.      #");
                }

            }

        }

        //Método que trata a entrada de texto.
        internal static string valor(string? Verifica)
        { 
            
            var convert = false;
            while(convert == false)
            {
                if(Verifica == "")
                {
                    
                    WriteLine("Informe um texto!");
                    Verifica = ReadLine();

                } 
                else if(Verifica != "" && Verifica != null)
                {
                    convert = true;
                    return Verifica;
                }
            }
            Verifica = "Sem dado";
            return Verifica;
        }
        //Método que trata a entrada "numérica".
        internal  static int valorN(string num)
        { 
            int result = 0;
            var convert = false;
            while(convert == false)
            {
                if(int.TryParse(num, out result) is true && result>0)
                { 
                    convert = true;
                    return result;
                }
                else
                {
                    WriteLine("Informe um valor númerico:");
                    num  = ReadLine()??"0";
                }
            }
            
            return result;
        }

                   
    }
}