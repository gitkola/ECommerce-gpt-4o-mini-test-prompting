// ECommerce.Api.Customers/Models/Customer.cs
using System;
using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}