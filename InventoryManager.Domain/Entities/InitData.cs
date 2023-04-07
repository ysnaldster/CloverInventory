using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Id = "8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb",
                Name = "Inveterate",
                Address = "simply dummy text of the printing and typesetting industry",
            },
            new()
            {
                Id = "8dd1b477-0d2b-42ae-bfd3-0de9d74b7fcc",
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
                Id = "e97de533-9e22-4944-92bc-bdd799b6c785",
                Name = "Sales"
            },
            new()
            {
                Id = "e97de533-9e22-4944-92bc-bdd799b6c786",
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
                Id = "3ee05129-86e3-4fe3-ac97-23510c79d1f6",
                CategoryId = "e97de533-9e22-4944-92bc-bdd799b6c785",
                Name = "Coca-Cola",
                Description = "simply dummy text of the printing and typesetting industry",
                TotalQuantity = 10
            },
            new()
            {
                Id = "3ee05129-86e3-4fe3-ac97-23510c79d1f7",
                CategoryId = "e97de533-9e22-4944-92bc-bdd799b6c786",
                Name = "Frescolita",
                Description = "simply dummy text of the printing and typesetting industry",
                TotalQuantity = 15
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
                Id = "b7d0bbf0-a1e9-4dbd-845b-f8e751160000",
                ProductId = "3ee05129-86e3-4fe3-ac97-23510c79d1f6",
                WarehouseId = "8dd1b477-0d2b-42ae-bfd3-0de9d74b7fbb",
                PartialQuantity = 4
            },
            new()
            {
                Id = "b7d0bbf0-a1e9-4dbd-845b-f8e751160001",
                ProductId = "3ee05129-86e3-4fe3-ac97-23510c79d1f7",
                WarehouseId = "8dd1b477-0d2b-42ae-bfd3-0de9d74b7fcc",
                PartialQuantity = 2
            }
        };
            return stores;
        }

        public static List<TransactionLog> LoadLabelsTransactionLogs()
        {
            var transactionLogs = new List<TransactionLog>
        {
            new()
            {
                Id = "f4670c53-544a-40b7-8fc3-e772edd31725",
                StorageId = "b7d0bbf0-a1e9-4dbd-845b-f8e751160000",
                Quantity = 3
            },
            new()
            {
                Id = "f4670c53-544a-40b7-8fc3-e772edd31726",
                StorageId = "b7d0bbf0-a1e9-4dbd-845b-f8e751160001",
                Quantity = 2
            }
        };
            return transactionLogs;
        }

        public static List<ProductUserPivot> LoadProductUserPivot()
        {
            var productUser = new List<ProductUserPivot>
            {
                new()
                {
                     Id = "f4670c53-544a-40b7-8fc3-e772edd31730",
                     ProductId = "3ee05129-86e3-4fe3-ac97-23510c79d1f6",
                     UserId = "8dd1b477-0d2b-42ae-bfd3-0de9d74b7f88"
                },
                new ()
                {
                     Id = "f4670c53-544a-40b7-8fc3-e772edd31731",
                     ProductId = "3ee05129-86e3-4fe3-ac97-23510c79d1f7",
                     UserId = "8dd1b477-0d2b-42ae-bfd3-0de9d74b7f99"
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
                    Id = "8dd1b477-0d2b-42ae-bfd3-0de9d74b7f88",
                    UserName = "John",
                    Password = "123456",
                    Email = "john@mail.com",
                    Role = "Administrator"
                },
                new ()
                {
                    Id = "8dd1b477-0d2b-42ae-bfd3-0de9d74b7f99",
                    UserName = "Fabiana",
                    Password = "123456",
                    Email = "fabiana@mail.com",
                    Role = "User"
                }
            };
            return users;
        }
    }
}
