using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public int UsrID { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }
    }

    public enum ProductType
    {
        BAKED_GOODS,
        BERRIES,
        DAIRY,
        DRINKS,
        EGGS,
        FRUITS,
        GRAINS,
        LEGUMES,
        MEAT,
        NUTS_AND_SEEDS,
        SEAFOOD,
        VEGETABLES,
        FISH
    }
}
