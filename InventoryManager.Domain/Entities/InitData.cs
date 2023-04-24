﻿using System;
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
                Id = 91202,
                ProductId = 66255,
                WarehouseId = 86348,
                PartialQuantity = 4
            },
            new()
            {
                Id = 91203,
                ProductId = 66256,
                WarehouseId = 86349,
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
                Id = 69044,
                StorageId = 91202,
                Quantity = 3
            },
            new()
            {
                Id = 69045,
                StorageId = 91203,
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
                    UserName = "John",
                    Password = "123456",
                    Email = "john@mail.com",
                    Role = "Administrator"
                },
                new ()
                {
                    Id = 4079,
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
