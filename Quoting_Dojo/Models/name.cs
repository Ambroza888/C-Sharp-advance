using System;
using System.ComponentModel.DataAnnotations;
namespace Quoting_Dojo.Models
{
    public class Name
    {
      [Display(Name = "Name")]
      [Required]
      [MinLength(1)]
      public string name {get;set;}

      [Display(Name="Quote")]
      [Required]
      [MinLength(1)]
      public string quote {get;set;}
    }
}