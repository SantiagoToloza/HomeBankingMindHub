using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeBankingMindHub.Models
{
    public class DBInitializer
    {
        public static void Initialize(HomeBankingContext context)

        {
            if (!context.Accounts.Any())
            {
                var accountVictor = context.Clients.FirstOrDefault(c => c.Email == "vcoronado@gmail.com");
                if (accountVictor != null)
                {
                    var accounts = new Account[]
                    {
                        new Account {ClientId = accountVictor.Id, CreationDate = DateTime.Now, Number = string.Empty, Balance = 0 }
                    };
                    foreach (Account account in accounts)
                    {
                        context.Accounts.Add(account);
                    }
                    context.SaveChanges();

                }
            }


            if (!context.Accounts.Any())
            {
                if (!context.Accounts.Any())
                {
                    var random = new Random();

                    // Obtener todos los clientes de la base de datos
                    var clients = context.Clients.ToList();

                    foreach (var client in clients)
                    {
                        int numberClient = random.Next(1, 5); // Generar un número aleatorio de cuentas por cliente

                        var accounts = new List<Account>();

                        for (int i = 0; i < numberClient; i++)
                        {
                            string accountNumber = random.Next(100, 1000).ToString();

                            var account = new Account
                            {
                                ClientId = client.Id,
                                CreationDate = DateTime.Now,
                                Number = accountNumber,
                                Balance = 10000
                            };

                            accounts.Add(account);
                        }

                        // Agregar todas las cuentas del cliente actual al contexto
                        context.Accounts.AddRange(accounts);
                    }

                    // Guardar todos los cambios en la base de datos
                    context.SaveChanges();
                }
            }
            if (!context.Clients.Any())
            {
                var clients = new Client[]
                {
                    new Client { Email = "vcoronado@gmail.com", FirstName="Victor", LastName="Coronado", Password="123456"},
                    new Client { Email = "santiago.b.toloza@gmail.com", FirstName="Santiago", LastName="Toloza", Password="abcdef"},
                    new Client { Email = "ErnestoPerez@gmail.com", FirstName="Ernesto", LastName="Perez", Password="abcdef"},
                    new Client { Email = "abc@gmail.com", FirstName="ab", LastName="c", Password="qwerty"},

                };

                foreach (Client client in clients)
                {
                    context.Clients.Add(client);
                }





                //guardamos
                context.SaveChanges();
            }

        }
    }
}