using System.ComponentModel.DataAnnotations;

namespace MVCCoreDemo.Models    
{    
    public class Student    
    {    
        public int StudId { get; set; }    
        [Required]    
        public string Name { get; set; }    
        [Required]    
        public string Gender { get; set; }    
        [Required]    
        public string Department { get; set; }    
        [Required]    
        public string City { get; set; }    
    }    
}