using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
namespace CSharpInciantes.BiblioTerm
{
    internal class MenuBibloteca

    {        
        //Método responsável pela simulação da inicialização do sistema.
        internal void MenuBoasVindas(){
        
            WriteLine("---- Bem vindo(a) ao projeto Bliblioteca V0 ----");
            
            //Realizará as próximas instruções após a ação de uma tecla.
            
            ReadKey();

            Thread.Sleep(400);
            WriteLine("Entrando - 3");
            Thread.Sleep(300);
            WriteLine("Entrando - 2");
            Thread.Sleep(200);
            WriteLine("Entrando - 1");
            Thread.Sleep(200);
            
            //Limpar o terminal.
            Console.Clear();
           
        }

        //Método com o visual do menu principal de operação.
        internal void MenuPrincipalBibliotca()
        {
            
            WriteLine("------ Biblioteca V0 ------");
            WriteLine("#       Opções:           #");
            WriteLine("# 1.Pesquisar acervo;     #"); //Implementado.
            WriteLine("# 2.Consultar Emprestimo; #"); 
            WriteLine("# 3.Realizar Emprestimo;  #");
            WriteLine("# 4.Devolução;            #");
            WriteLine("# 5.Cadastro material;    #"); //Implementado. 
            WriteLine("# 0.Sair.                 #"); //Implementado.   
            WriteLine("***************************");
            
        }       

        internal void tipoPesqMaterial()
        {
            Console.Clear();
            WriteLine("------ Biblioteca V0 ------");
            WriteLine("#    Pesquisar acervo:    #");
            WriteLine("# 1.Pesq. por titulo      #");
            WriteLine("# 2.Pesq. futura          #");
            WriteLine("# 3.Voltar                #");
            WriteLine("***************************");

        }

        internal void realizarEmprestimo()
        {
            Console.Clear();
            WriteLine("------ Biblioteca V0 ------");
            WriteLine("#   Realizar emprestimo:  #");
            WriteLine("#                         #");
            WriteLine("#   Informe o título da   #");
            WriteLine("#          obra:          #");
            WriteLine("*                         *");
        }

         internal void consultarEmprestimo()
        {
            
            WriteLine("------ Biblioteca V0 ------");
            WriteLine("#   Consultar Emprestimo  #");
            WriteLine("# 1 - Listar ativos:      #");
           
        }

        internal void devolucaoEmp()
        {
            Console.Clear();
            WriteLine("------ Biblioteca V0 ------");
            WriteLine("#       Devolução:        #");
            WriteLine("#                         #");
            WriteLine("#   Informe a matrícula   #");
            WriteLine("#            :            #");
            WriteLine("*                         *");
        }


    }
}