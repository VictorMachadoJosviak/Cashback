using Cashback.Domain.Entities;
using Cashback.Infra.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashback.Infra.Presistence
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext db)
        {
            db.Database.EnsureCreated();

            if (!db.StatusSales.Any())
            {
                db.StatusSales.Add(new StatusSale
                {
                    Id = 1,
                    Name = "Em Validação"
                });

                db.StatusSales.Add(new StatusSale
                {
                    Id = 2,
                    Name = "Aprovado"
                });
     
            }

            if (!db.ConfigurationIntegrations.Any())
            {
                db.ConfigurationIntegrations.Add(new ConfigurationIntegration
                {
                    Name = "BOTICARIO_CASHBACK",
                    Token = "ZXPURQOARHiMc6Y0flhRC1LVlZQVFRnm",
                    TokenType = "Bearer",
                    Url = "https://mdaqk8ek5j.execute-api.us-east-1.amazonaws.com"
                });
            }

            if (!db.Resellers.Any())
            {
                db.Resellers.Add(new Reseller
                {
                    CPF = "15350946056",
                    Email = "cashback@boticario.com",
                    Name = "Boticario",
                    LastName = "Perfumes",
                    Password = "123456".ToHash()
                }) ;
            }
            db.SaveChanges();

        }
    }
}
