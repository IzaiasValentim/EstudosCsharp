using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpInciantes.BiblioTerm
{
    public class ControleEmprestimo
    {
        //Classe que irá realizar o controle dos empréstimos, tal como cadastro dele e devolução.
        
        
        internal List<Emprestimo>EmprestimosAtivos = new List<Emprestimo>();
        //Lista que é armazena apenas os empréstimos ativos.
        List<Emprestimo>pesqListaEmp = new List<Emprestimo>();
        //Lista reserva, para troca entre métodos.
        internal void ListaAddEmp(Emprestimo Emp){

            EmprestimosAtivos.Add(Emp);

        }

        internal void realizacaoEmprestimo(CadastroMaterial Empt,string titMat,string nomeTit,int Matricula)
        {
                
            ClasseMaterial ? matEmprestimo = new ClasseMaterial();
            Emprestimo NovoEmp;
    
            try        
            {
                var teste = Empt.PesqEmp(titMat);
                matEmprestimo = Empt.PesqEmp(titMat);

                if(matEmprestimo is not null)
                {
                    NovoEmp = new Emprestimo(matEmprestimo,nomeTit,Matricula);   
                    matEmprestimo.disponibilidadeEmp();
                    WriteLine("#  Emprestimo realizado!  #");
                    WriteLine($"*  Nome: {nomeTit}       *");
                    WriteLine($"*  Matricula: {Matricula}*");
                    WriteLine("*  Validade: {DataEmp}    *");
                    ListaAddEmp(NovoEmp);
                        ReadKey();
                } 
            }
            catch(NullReferenceException)
            {
                    WriteLine("Não foi encontrada uma obra correspondende ao titulo informado.");
            }    
        }
        //Método referente a função de listar todos os emprestimos ativos.
        internal void ListarEmprestimos()
        {
            WriteLine("------ Biblioteca V0 ------");
            WriteLine("#   Emprestimos ativos:   #");

            foreach(var E in EmprestimosAtivos)
            {   
                WriteLine($"Obra: {E.MaterialEmp.m_Titulo} - Titular: {E.titularEmp} - Matricula: {E.titularMat}");
               
            } 
             ReadKey();
        }

        //Realização da devolução.
        internal void devolucaoEmprestimo(int matriculaEmp)
        {
        
            int contadorE = 0;
            //Este foreach percorre todos os emprestimos cadastrados, se houver algum emprestimo - 
            //- na matricula correspondente, será armazenado em uma lista secundária.
            foreach(var pesqEmp in EmprestimosAtivos)
            {
                if(pesqEmp.titularMat == matriculaEmp){
                    pesqListaEmp.Add(pesqEmp);
                    contadorE++;   
                }
            }
            
            if(contadorE == 0)
            {
                WriteLine("Nenhum empréstimo realizado com essa matrícula!");
            }
            else if(contadorE>0)
            {
                var cont = 0;
                foreach(var Emp in pesqListaEmp)
                {
                    
                     WriteLine($"Opcao-> {cont+1} - Obra: {Emp.MaterialEmp.m_Titulo} - Titular: {Emp.titularEmp} - Matricula: {Emp.titularMat}");
                     cont++;

                }
                WriteLine("Informe a opção a devolver: ");
            }
        }  
        //Método que realiza a devolução de acordo com as obras emprestadas ao portador
        // da n matrícula.
        public void realizarDevolucao(int opcaoDev)
        {
            try
            {
                pesqListaEmp[opcaoDev-1].MaterialEmp.disponibilidadeEmp();
                EmprestimosAtivos.Remove(pesqListaEmp[opcaoDev-1]);
                pesqListaEmp.Clear();
                WriteLine("Devolvido com sucesso!");
            }
            catch(ArgumentNullException)
            {
                WriteLine("Erro ao devolver.");
            }
        }
    }
}
