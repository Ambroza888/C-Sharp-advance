using System;
using System.ComponentModel.DataAnnotations;

namespace form_submission.Models
{
 public class User
      {
//--------------------------------------
      [Required]
      [MinLength(4)]
      [Display(Name = "Your Name ? from Models:")]
      public string FirstName {get;set;}

//--------------------------------------
      [Required]
      [MinLength(4)]
      [Display(Name = " What is your last name ?:")]
      public string LastName {get;set;}

//--------------------------------------
      [Required]
      [Range(0,int.MaxValue)]
      [Display(Name= "What is youre age from the MODELS ?:")]
      public int Age {get;set;}
//--------------------------------------
      [Required]
      [EmailAddress]
      [Display(Name= " Hey i am practicing from the models :) :")]
      public string Email { get;set;}

//--------------------------------------
      [Required]
      [DataType(DataType.Password)]
      [Display(Name = "Hey what is youre pasword ?")]
      public string Password {get;set;}

      }
}