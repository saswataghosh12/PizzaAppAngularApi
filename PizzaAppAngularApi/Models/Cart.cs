using System.ComponentModel.DataAnnotations;

namespace PizzaAppAngularApi.Models
{
    public class Cart
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public int pizzaId { get; set; }
        public string pizzaName { get; set; }
        public string pizzaImage { get; set; }
        public string pizzaDescriptionImage { get; set; }
        public int count { get; set; }
        public int  pizzaPrice { get; set; }
    }
}
