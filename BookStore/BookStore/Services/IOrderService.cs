using BookStore.Data;
namespace BookStore.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Add order to the database
        /// </summary>
        /// <param name="Order">Object of the type Order</param>
        void AddOrder(Order Order);
        /// <summary>
        /// Get information the last order
        /// </summary>
        /// <returns>The last order made (in the database)</returns>
        Order GetLastOrderInfo();
        /// <summary>
        /// Add an orderline to the database
        /// </summary>
        /// <param name="OrderLine"></param>
        void AddOrderLine(OrderLine OrderLine);
    }
}
