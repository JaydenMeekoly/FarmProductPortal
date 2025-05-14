using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using FarmProductPortal.Models;


public class Farmer
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    // Navigation property
   // public ICollection<Product> Products { get; set; }
    
}
