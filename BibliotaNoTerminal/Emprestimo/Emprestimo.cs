using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpInciantes.BiblioTerm
{
    public class Emprestimo
    {
        //Essa classe terá os atributos básicos do emprestimo.        
        internal ClasseMaterial MaterialEmp;

        private string ?  TitularEmp;
        public string ? titularEmp
        {
            get {return TitularEmp;}
    	    internal set {this.TitularEmp = value;}
        }
        
        private int TitularMat;
        public int titularMat
        {
            get {return TitularMat;}
    	    internal set {this.TitularMat = value;}
        }

        internal Emprestimo(ClasseMaterial mat,string titularConstrutor,int matriculaConstrutor){
          
            this.MaterialEmp = mat;
            this.titularEmp = titularConstrutor;
            this.titularMat = matriculaConstrutor;
        }

        //Posteriormente implementar prazo de emprestimo e devolução.
    }
}