using BookStore.Data;
namespace BookStore.Services
{
    public interface IOrderService
    {
        void AddOrder(Order Order);
        Order GetLastOrderInfo();
        void AddOrderLine(OrderLine OrderLine);
    }
}
