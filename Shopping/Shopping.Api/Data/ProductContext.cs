using Shopping.Api.Models;
using MongoDB.Driver;
namespace Shopping.Api.Data
{
    public class ProductContext
    {
        

        public IMongoCollection<Product> Products { get; set; }

        public ProductContext(IConfiguration config)
        {
            var client = new MongoClient(config["DatabaseSettings:ConnectionString"]);
            var productdb = client.GetDatabase(config["DatabaseSettings:DatabaseName"]);
            var products = productdb.GetCollection<Product>(config["DatabaseSettings:CollectionName"]);
            SeedData(products);
        }

        private void SeedData(IMongoCollection<Product> products)
        {
            bool productExist = products.Find(p=> true).Any();

            if(!productExist)
            {
                products.InsertMany(GetPreconfiguredProducts());
            }
        }

        private IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product()
                    {
                        Name = "IPhone X",
                        Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                        ImageFile = "product-1.png",
                        Price = 950.00M,
                        Category = "Smart Phone"
                    },
                new Product()
                {
                    Name = "Samsung 10",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Huawei Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "Xiaomi Mi 9",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Name = "HTC U11+ Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "LG G7 ThinQ EndofCourse",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = "Home Kitchen"
                }
            };
        
        }
    }
}
     

