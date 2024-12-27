// ECommerce.Api.Search/Models/Customer.cs
using System;
using System.Collections.Generic;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

// ECommerce.Api.Search/Models/Order.cs
public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime OrderDateTime { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}

// ECommerce.Api.Search/Models/OrderItem.cs
public class OrderItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

// ECommerce.Api.Search/Models/Product.cs
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}