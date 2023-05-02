namespace InventoryManager.Domain.Entities
{
    public abstract class InitData
    {
        public static List<Warehouse> LoadWineries()
        {
            var wineries = new List<Warehouse>
        {
            new()
            {
                Id = 86348,
                Name = "Inveterate",
                Address = "simply dummy text of the printing and typesetting industry",
            },
            new()
            {
                Id = 86349,
                Name = "The Dilston",
                Address = "simply dummy text of the printing and typesetting industry",

            }
        };
            return wineries;
        }

        public static List<Category> LoadCategories()
        {
            var categories = new List<Category>
        {
            new()
            {
                Id = 72206,
                Name = "Sales"
            },
            new()
            {
                Id = 72207,
                Name = "Distribution"
            }
        };
            return categories;
        }

        public static List<Product> LoadProducts()
        {
            var products = new List<Product>
        {
            new()
            {
                Id = 66255,
                CategoryId = 72206,
                Name = "Coca-Cola",
                Description = "simply dummy text of the printing and typesetting industry",
                TotalQuantity = 10
            },
            new()
            {
                Id = 66256,
                CategoryId = 72207,
                Name = "Frescolita",
                Description = "simply dummy text of the printing and typesetting industry",
                TotalQuantity = 10
            }
        };
            return products;
        }

        public static List<Storage> LoadStores()
        {
            var stores = new List<Storage>
        {
            new()
            {
                Id = 91202,
                ProductId = 66255,
                WarehouseId = 86348,
                PartialQuantity = 10
            },
            new()
            {
                Id = 91203,
                ProductId = 66256,
                WarehouseId = 86349,
                PartialQuantity = 10
            }
        };
            return stores;
        }

        public static List<ProductUserPivot> LoadProductUserPivot()
        {
            var productUser = new List<ProductUserPivot>
            {
                new()
                {
                     Id = 83976,
                     ProductId = 66255,
                     UserId = 4078
                },
                new ()
                {
                     Id = 83977,
                     ProductId = 66256,
                     UserId = 4079
                }
            };
            return productUser;
        }

        public static List<User> LoadUsers()
        {
            var users = new List<User>
            {
                new()
                {
                    Id = 4078,
                    UserName = "Admin",
                    Password = "admin",
                    Email = "admin@mail.com",
                    Role = "Administrator"
                },
                new ()
                {
                    Id = 4079,
                    UserName = "Test",
                    Password = "test",
                    Email = "test@mail.com",
                    Role = "User"
                }
            };
            return users;
        }
    }
}
