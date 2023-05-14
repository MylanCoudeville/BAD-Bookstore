using BookStore.Data;

namespace BookStore.Services
{
    public class OrderService : IOrderService
    {
        private BookstoreDbContext _dbContext;
        public OrderService(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
        public Order GetLastOrderInfo()
        {
            return _dbContext.Orders.OrderByDescending(x => x.Id).LastOrDefault();
        }
        public void AddOrderLine(OrderLine line)
        {
            _dbContext.OrderLines.Add(line);
            _dbContext.SaveChanges();
        }
    }
}
