namespace ArgusMedia.Restaurant.Models
{
    public class ProductsSeedData
    {
        public ProductsSeedData()
        {
        }

        public IEnumerable<Product> ProductsData 
            => new List<Product> 
                {
                    Mains,
                    Starters,
                    Drinks
                };

        private Product Mains
            => new Product
            {
                Id = new Guid("25254a12-e89e-4eb5-8e21-a5fc38625d01"),
                Name = "Mains",
                Price = 7,
                IsDrink = false
            };

        private Product Starters
            => new Product
            {
                Id = new Guid("25254a12-e89e-4eb5-8e21-a5fc38625d02"),
                Name = "Starters",
                Price = 4,
                IsDrink = false
            };

        private Product Drinks
            => new Product
            {
                Id = new Guid("25254a12-e89e-4eb5-8e21-a5fc38625d03"),
                Name = "Drinks",
                Price = 2.5m,
                IsDrink = true
            };
    }
}
