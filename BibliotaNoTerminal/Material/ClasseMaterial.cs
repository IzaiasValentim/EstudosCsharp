using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpInciantes.BiblioTerm

{
    //A classe material é responsável pela interação com toda obra que será manejada na biblioteca.
    internal class ClasseMaterial
    {

        private string ? M_Titulo;
            internal string  m_Titulo {get;private set;}

        private string ? M_Autor;
            internal string m_Autor{get;private set;}

        private int M_Pags;
            internal int m_Pags{get;private set;}
        private bool M_Status;
            internal bool m_Status{get; private set;}
        
    internal ClasseMaterial(){
        m_Titulo = "";
        m_Autor = "";
        m_Pags = 0;
        m_Status = false;
    }
    internal ClasseMaterial(string refTit,string refAlt,int refPag, bool refStat){
            
            m_Titulo = refTit.Trim().ToUpper();
            m_Autor = refAlt.Trim().ToUpper();
            m_Pags = refPag;
            m_Status = refStat;
    }    
    //Método que altera a disponibilidade do empréstimo.
    internal void disponibilidadeEmp(){
        
        if(this.m_Status == true ){

            this.m_Status = false;  
        }else{

             this.m_Status = true;  

        }
        

    }

        
    }
}