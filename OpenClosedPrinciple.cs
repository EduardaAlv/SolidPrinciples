using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class OpenClosedPrinciple
    {
        //Definição: Classes devem estar abertas para extensão, mas fechadas para modificação.
        //Motivação: Evita a necessidade de modificar código já existente ao adicionar novas funcionalidades.
    }


    // Errado: Modificamos a classe para adicionar novos cálculos
    public class CalculadoraSalarioErrado
    {
        public double CalcularSalario(string tipo, double valor)
        {
            if (tipo == "CLT")
                return valor - (valor * 0.2);
            else if (tipo == "PJ")
                return valor;
            else
                throw new Exception("Tipo inválido");
        }
    }

    // Correto: Utilizamos polimorfismo para estender o comportamento sem modificar a classe original
    public interface ICalculadoraSalario
    {
        double Calcular(double valor);
    }

    public class SalarioCLT : ICalculadoraSalario
    {
        public double Calcular(double valor) => valor - (valor * 0.2);
    }

    public class SalarioPJ : ICalculadoraSalario
    {
        public double Calcular(double valor) => valor;
    }

    public class CalculadoraSalario
    {
        public double CalcularSalario(ICalculadoraSalario tipo, double valor)
        {
            return tipo.Calcular(valor);
        }
    }

}
