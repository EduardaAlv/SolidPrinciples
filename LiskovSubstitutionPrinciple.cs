using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class LiskovSubstitutionPrinciple
    {
        //Definição: Uma classe derivada deve poder ser substituída pela sua classe base sem alterar o comportamento esperado do programa.

        //Motivação: Evita que uma subclasse quebre a lógica da classe base.
    }

    // Errado: O Pinguim não pode voar, mas herdou o método Voar da classe base
    public class AveErrado
    {
        public virtual void Voar()
        {
            Console.WriteLine("Voando...");
        }
    }

    public class PinguimErrado : AveErrado
    {
        public override void Voar()
        {
            throw new Exception("Pinguins não voam!");
        }
    }

    // Correto: Criamos uma interface para distinguir aves que voam e aves que não voam
    public interface IAve
    {
        void Comer();
    }

    public interface IAveVoadora : IAve
    {
        void Voar();
    }

    public class Pardal : IAveVoadora
    {
        public void Comer() => Console.WriteLine("Pardal comendo...");
        public void Voar() => Console.WriteLine("Pardal voando...");
    }

    public class Pinguim : IAve
    {
        public void Comer() => Console.WriteLine("Pinguim comendo...");
    }

}
