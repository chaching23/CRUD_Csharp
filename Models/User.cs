using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace dishes.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        public string Name {get;set;}
        [Required]
        public string Chef {get;set;}
        [Required]
        [Range(1,5)]
        public int Taste {get;set;}
        [Required]
        [Range(1,5000000)]
        public int Calories {get;set;}
        [Required]
        public string Description {get;set;}
                
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public void Update(User formObject)
        {
            this.Name = formObject.Name;
            this.Chef = formObject.Chef;
            this.Taste = formObject.Taste;
            this.Calories = formObject.Calories;
            this.Description = formObject.Description;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}