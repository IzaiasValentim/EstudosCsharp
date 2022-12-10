using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
namespace CSharpInciantes.BiblioTerm
{
    //A classe material é responsável pela interação com toda obra que será manejada na biblioteca.
    //Inicialmente só será implementado Livros -> ou seja o Materal ainda não possui um tipo.
    
    internal class CadastroMaterial
    {
        
        int indice = 0;
        //Esse método é com o intuito de cadastro provisório do material.
        ClasseMaterial[] Mat_cad = new ClasseMaterial[30];
               
        public string [] Pesq(string p_Tit_Mat)
        {    
            string [] ocorrencia = new string[indice-1];
        
            int contador = 0;

            if(p_Tit_Mat != null)
            {
                for(int var = 0; var < indice; var++)
                {
                    if((Mat_cad[var].m_Titulo == p_Tit_Mat.ToUpper()) && Mat_cad[var].m_Status == true)
                    {
                        ocorrencia[contador] = Mat_cad[var].m_Titulo;
                        contador++;
                    }
                }
            }
    
                string [] ocorrenciaF = new string[contador];
                
                for(int i = 0; i<contador;i++)
                {
                    if(ocorrencia[i] != null)
                    {
                    ocorrenciaF[i] = ocorrencia[i];
                    }
                } 

            return ocorrenciaF;
       }
        public  void Cadastro()
        {
            //Alguns materiais base já cadastrados por padrão no sitema.
            //Esses livros fazem parte das minhas fontes de estudos atuais.

            Mat_cad[indice] = new ClasseMaterial("Teste Emprestimo","Emprestimo",10,true);
            this.indice++;
            Mat_cad[indice] = new ClasseMaterial("C# PARA INICIANTES","André Carlucci et al.",267,true);
            this.indice++;
            Mat_cad[indice] = new ClasseMaterial("Orientacao a Objetos","Thiago Leite e Carvalho.",245,true);
            this.indice++;
            Mat_cad[indice] = new ClasseMaterial("SQL e modelagem com banco de dados","Alura.",134,true);
            this.indice++;
            Mat_cad[indice] = new ClasseMaterial("Estruturação de páginas usando HTML E CSS","Alura",296,true);
            this.indice++;
            //indice nesse ponto é 5.
            Mat_cad[indice] = new ClasseMaterial("C# e Orientacao à Objetos","Alura",202,true);
            this.indice++;
             Mat_cad[indice] = new ClasseMaterial("Desbravando Java e Orientação a Objetos","Rodrigo Turini",225,true);
            this.indice++;


        }

        //Todo material ao cadastrar, fica disponível.
        public string CadastroMat(string titM,string autM,int pagM,int quantM,bool dispM = true)
        {

            if((Mat_cad.Length - indice) >= quantM)
            {
                for(int contCad = 0;contCad < quantM;contCad++)
                {
                    Mat_cad[indice] = new ClasseMaterial(titM,autM,pagM,dispM);
                    indice++;
                }

                return "Cadastro Realizado com sucesso!";
            }
            else if((Mat_cad.Length - indice) <= quantM)
            {
                return "Sistema sem capacidade para essa quantidade de material";
            }   

            return "Falha no cadastro";        
        }

        public ClasseMaterial? PesqEmp(string p_Tit_Mat)
        {    
            bool statusEncontro = true;//No primeiro encontro o status de encontro será altero, impossibilitando o retorno de outros objetos.
            try
            {
                foreach(ClasseMaterial mat in Mat_cad)
                {
                    if((mat.m_Titulo == p_Tit_Mat.ToUpper()) && mat.m_Status == true && statusEncontro == true)
                    {         
                        statusEncontro = false;
                        return mat;
                    }
                } 
            }
            catch(NullReferenceException)
            {

            }

            return null;
        }
    }   
}