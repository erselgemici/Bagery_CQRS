using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands; 
using MyAcademyCQRS.Entities; 

namespace MyAcademyCQRS.DesignPatterns.ChainOfResponsibility
{
    public abstract class OrderHandlerBase
    {
        protected OrderHandlerBase _nextHandler;

        public void SetNext(OrderHandlerBase nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void Handle(CreateOrderCommand command);
    }
}
