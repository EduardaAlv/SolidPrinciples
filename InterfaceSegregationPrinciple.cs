using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
namespace SolidPrinciples
{
    public class InterfaceSegregationPrinciple
    {
        //Definição: Uma classe não deve ser forçada a implementar métodos que não usa.
        //Motivação: Evita interfaces muito grandes e classes sobrecarregadas.
    }

    // Errado: A interface obriga classes a implementarem métodos desnecessários
    public interface ITrabalho
    {
        void Trabalhar();
        void Gerenciar();
    }

    public class DesenvolvedorErrado : ITrabalho
    {
        public void Trabalhar() => Console.WriteLine("Codando...");
        public void Gerenciar() => throw new Exception("Desenvolvedores não gerenciam!");
    }

    // Correto: Criamos interfaces menores e mais específicas
    public interface ITrabalhador
    {
        void Trabalhar();
    }

    public interface IGerente
    {
        void Gerenciar();
    }

    public class Desenvolvedor : ITrabalhador
    {
        public void Trabalhar() => Console.WriteLine("Codando...");
    }

    public class Gestor : IGerente
    {
        public void Gerenciar() => Console.WriteLine("Gerenciando equipe...");
    }

}
