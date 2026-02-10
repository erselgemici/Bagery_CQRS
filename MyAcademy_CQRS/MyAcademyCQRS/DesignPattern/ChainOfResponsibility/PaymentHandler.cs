using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;

namespace MyAcademyCQRS.DesignPatterns.ChainOfResponsibility
{
    public class PaymentHandler : OrderHandlerBase
    {
        public override void Handle(CreateOrderCommand command)
        {
            
            bool bakiyeYeterliMi = true;

            if (!bakiyeYeterliMi)
            {
                throw new System.Exception("Ödeme alınamadı, bakiye yetersiz.");
            }

            // Para çekildi, sıradaki işleme geç (Sipariş Kaydı)
            if (_nextHandler != null)
            {
                _nextHandler.Handle(command);
            }
        }
    }
}
