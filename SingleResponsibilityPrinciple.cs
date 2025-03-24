using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;

namespace SolidPrinciples
{
    public class SingleResponsibilityPrinciple
    {
        //Definição: Uma classe deve ter apenas uma razão para mudar, ou seja, deve ter apenas uma responsabilidade.
        //Motivação: Evita que uma única classe tenha múltiplas responsabilidades, facilitando a manutenção e testes.
    }

    // Errado: As responsabilidades (Cadastrar usuário e fazer o log) estão na mesma classe
    public class UsuarioServiceJeitoErrado
    {
        public void CadastrarUsuario(string nome, string email)
        {
            Console.WriteLine("Usuário cadastrado com sucesso!");
            SalvarLog("Usuário cadastrado.");
        }

        private void SalvarLog(string mensagem)
        {
            Console.WriteLine("Log: " + mensagem);
        }
    }

    // Correto: Separando as responsabilidades (Cadastrar usuário e fazer o log)
    public class UsuarioService
    {
        private readonly LogService _logService;

        public UsuarioService(LogService logService)
        {
            _logService = logService;
        }

        public void CadastrarUsuario(string nome, string email)
        {
            Console.WriteLine("Usuário cadastrado com sucesso!");
            _logService.SalvarLog("Usuário cadastrado.");
        }
    }

    public class LogService
    {
        public void SalvarLog(string mensagem)
        {
            Console.WriteLine("Log: " + mensagem);
        }
    }
}
