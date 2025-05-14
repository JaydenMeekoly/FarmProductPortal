using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class ProductFilterViewModel
{
    public string Category { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }
    public string FarmerId { get; set; }  // selected filter value
    public List<ApplicationUser> AllFarmers { get; set; }  // for dropdown

    public List<Product> Results { get; set; }
}
