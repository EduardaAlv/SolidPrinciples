using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class DependencyInversionPrinciple
    {
        //Definição: Módulos de alto nível não devem depender de módulos de baixo nível.Ambos devem depender de abstrações.

        //Motivação: Reduz o acoplamento e facilita a manutenção.
    }

    // Errado: A classe de alto nível depende diretamente da classe de baixo nível
    public class EmailServiceErrado
    {
        public void EnviarEmail(string mensagem)
        {
            Console.WriteLine("Email enviado: " + mensagem);
        }
    }

    public class PedidoServiceErrado
    {
        private EmailServiceErrado _emailService = new EmailServiceErrado();

        public void ProcessarPedido()
        {
            Console.WriteLine("Pedido processado.");
            _emailService.EnviarEmail("Seu pedido foi processado.");
        }
    }

    // Correto: Dependemos de uma abstração
    public interface INotificacaoService
    {
        void Notificar(string mensagem);
    }

    public class EmailService : INotificacaoService
    {
        public void Notificar(string mensagem)
        {
            Console.WriteLine("Email enviado: " + mensagem);
        }
    }

    public class PedidoService
    {
        private readonly INotificacaoService _notificacaoService;

        public PedidoService(INotificacaoService notificacaoService)
        {
            _notificacaoService = notificacaoService;
        }

        public void ProcessarPedido()
        {
            Console.WriteLine("Pedido processado.");
            _notificacaoService.Notificar("Seu pedido foi processado.");
        }
    }

    class Program
    {
        static void Main()
        {
            // Criamos uma instância do serviço de notificação (por e-mail)
            INotificacaoService emailService = new EmailService();

            // Passamos a instância para o PedidoService
            PedidoService pedidoService = new PedidoService(emailService);

            // Processamos um pedido
            pedidoService.ProcessarPedido();
        }
    }

}
