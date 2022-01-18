using System.ComponentModel.DataAnnotations;

namespace PizzaAppAngularApi.Models
{
    public class Pizza
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string photoPath { get; set; }
    }
}
