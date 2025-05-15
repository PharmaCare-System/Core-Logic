using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.OrderDTOs;
using PharmaCare.DAL.ExtensionMethods;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.Orders;

namespace PharmaCare.BLL.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository  _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task AddAsync(OrderAddDTO order)
        {
            var orderModel = new Order
            {
                OrderType = order.OrderType,
                DeliveryAddress = order.DeliveryAddress,
                TotalPrice = order.TotalPrice,
                OrderStatus = order.OrderStatus,
                CustomerId = order.CustomerId,
                PharmacistId = order.PharmacistId,
                PharmacyId = order.PharmacyId,
                ProductOrders = order.OrderProducts.Select(p => new ProductOrder
                {
                    ProductId = p.ProductId,
                }).ToList()
            };
            await _orderRepository.AddAsync(orderModel);
        }

        public async Task DeleteAsync(int orderId)
        {
            var order = await _orderRepository.GetAsyncById(orderId);
           orderId.CheckIfNull(order);
            await _orderRepository.SoftDelete(order);

        }

        public async Task<IEnumerable<OrderReadDTO>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.Select(x => new OrderReadDTO
            {
                Id = x.Id,
                OrderType = x.OrderType,
                DeliveryAddress = x.DeliveryAddress,
                TotalPrice = x.TotalPrice,
                OrderStatus = x.OrderStatus,
                CustomerId = x.CustomerId,
                PharmacistId = x.PharmacistId,
                PharmacyId = x.PharmacyId,
                OrderProducts = x.ProductOrders.Select(p => new ProductOrderAddDTO
                {
                    ProductId = p.ProductId,

                }).ToList()
            });

        }

        public async Task<OrderReadDTO> GetAsyncById(int orderId)
        {
            var order = await _orderRepository.GetAsyncById(orderId);
            orderId.CheckIfNull(order);
            return new OrderReadDTO
            {
                Id = order.Id,
                OrderType = order.OrderType,
                DeliveryAddress = order.DeliveryAddress,
                TotalPrice = order.TotalPrice,
                OrderStatus = order.OrderStatus,
                CustomerId = order.CustomerId,
                PharmacistId = order.PharmacistId,
                PharmacyId = order.PharmacyId,
                OrderProducts = order.ProductOrders.Select(p => new ProductOrderAddDTO
                {
                    ProductId = p.ProductId,
                }).ToList()
            };


        }

        public async Task<List<OrderDTO>> GetOrderProductsAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderProductsAsync(orderId);
            orderId.CheckIfNull(order);
            return order.Select(x => new OrderDTO
            {
                Id = x.Id,
                OrderType = x.OrderType,
                DeliveryAddress = x.DeliveryAddress,
                TotalPrice = x.TotalPrice,
                OrderStatus = x.OrderStatus,
                CustomerId = x.CustomerId,
                PharmacistId = x.PharmacistId,
                PharmacyId = x.PharmacyId,
                OrderProducts = x.ProductOrders.Select(p => new ProductOrderDTO
                {
                    ProductId = p.ProductId,
                }).ToList()
            }).ToList();

        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByCustomerIdAsync(int customerId)
        {
            var orders = await _orderRepository.GetOrdersByCustomerIdAsync(customerId);
            return orders.Select(x => new OrderDTO
            {
                Id = x.Id,
                OrderType = x.OrderType,
                DeliveryAddress = x.DeliveryAddress,
                TotalPrice = x.TotalPrice,
                OrderStatus = x.OrderStatus,
                CustomerId = x.CustomerId,
                PharmacistId = x.PharmacistId,
                PharmacyId = x.PharmacyId,
                OrderProducts = x.ProductOrders.Select(p => new ProductOrderDTO
                {
                    ProductId = p.ProductId,
                }).ToList()
            });
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByPharmacistIdAsync(int pharmacistId)
        {
            var orders = await _orderRepository.GetOrdersByPharmacistIdAsync(pharmacistId);
            return orders.Select(x => new OrderDTO
            {
                Id = x.Id,
                OrderType = x.OrderType,
                DeliveryAddress = x.DeliveryAddress,
                TotalPrice = x.TotalPrice,
                OrderStatus = x.OrderStatus,
                CustomerId = x.CustomerId,
                PharmacistId = x.PharmacistId,
                PharmacyId = x.PharmacyId,
                OrderProducts = x.ProductOrders.Select(p => new ProductOrderDTO
                {
                    ProductId = p.ProductId,
                }).ToList()
            });
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByPharmacyIdAsync(int pharmacyId)
        {
            var orders = await _orderRepository.GetOrdersByPharmacyIdAsync(pharmacyId);
            return orders.Select(x => new OrderDTO
            {
                Id = x.Id,
                OrderType = x.OrderType,
                DeliveryAddress = x.DeliveryAddress,
                TotalPrice = x.TotalPrice,
                OrderStatus = x.OrderStatus,
                CustomerId = x.CustomerId,
                PharmacistId = x.PharmacistId,
                PharmacyId = x.PharmacyId,
                OrderProducts = x.ProductOrders.Select(p => new ProductOrderDTO
                {
                    ProductId = p.ProductId,
                }).ToList()
            });
        }

        public async Task UpdateAsync(int orderId, OrderUpdateDTO order)
        {
            var orderModel = await _orderRepository.GetAsyncById(orderId);
            orderId.CheckIfNull(orderModel);
            orderModel.OrderType = order.OrderType;
            orderModel.DeliveryAddress = order.DeliveryAddress;
            orderModel.TotalPrice = order.TotalPrice;
            orderModel.OrderStatus = order.OrderStatus;
            await _orderRepository.UpdateAsync(orderModel);

        }
    }
}
