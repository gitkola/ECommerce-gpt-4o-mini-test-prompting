// ECommerce.Api.Orders/Models/Order.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Order
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public Guid CustomerId { get; set; }
    
    [Required]
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}