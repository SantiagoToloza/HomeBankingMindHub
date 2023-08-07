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

            if (!context.Transactions.Any())
            {
                var account1 = context.Accounts.FirstOrDefault(c => c.Number == "VIN001");

                if (account1 != null)
                {
                    var transactions = new Transaction[]
                    {
                        new Transaction { AccountId = account1.Id, Amount = 100000, Date = DateTime.Now.AddHours(-4), Description = "Transferencia recibida", Type = TransactionType.CREDIT.ToString() },
                        new Transaction { AccountId = account1.Id, Amount = -20000, Date = DateTime.Now.AddHours(-6), Description = "Compra en tienda mercado libre por un auto", Type = TransactionType.DEBIT.ToString() },
                        new Transaction { AccountId = account1.Id, Amount = -300, Date = DateTime.Now.AddHours(-8), Description = "Compra en tienda amazon", Type = TransactionType.DEBIT.ToString() },
                    };

                    foreach (Transaction transaction in transactions)
                    {
                        context.Transactions.Add(transaction);
                    }

                    context.SaveChanges();
                }
            }

            if (!context.Clients.Any())
            {
                var clients = new Client[]
                {
                    new Client { Email = "vcoronado@gmail.com", FirstName = "Victor", LastName = "Coronado", Password = "123456" },
                    new Client { Email = "santiago.b.toloza@gmail.com", FirstName = "Santiago", LastName = "Toloza", Password = "abcdef" },
                    new Client { Email = "ErnestoPerez@gmail.com", FirstName = "Ernesto", LastName = "Perez", Password = "abcdef" },
                    new Client { Email = "abc@gmail.com", FirstName = "ab", LastName = "c", Password = "qwerty" },
                };

                foreach (Client client in clients)
                {
                    context.Clients.Add(client);
                }

                //guardamos
                context.SaveChanges();
            }

            if (!context.Transactions.Any())
            {
                var account1 = context.Accounts.FirstOrDefault(c => c.Number == "VIN001");

                if (account1 != null)
                {
                    var transactions = new Transaction[]
                    {
                        new Transaction { AccountId = account1.Id, Amount = 10000, Date = DateTime.Now.AddHours(-5), Description = "Transferencia recibida", Type = TransactionType.CREDIT.ToString() },
                        new Transaction { AccountId = account1.Id, Amount = -2000, Date = DateTime.Now.AddHours(-6), Description = "Compra en tienda mercado libre", Type = TransactionType.DEBIT.ToString() },
                        new Transaction { AccountId = account1.Id, Amount = -3000, Date = DateTime.Now.AddHours(-7), Description = "Compra en tienda xxxx", Type = TransactionType.DEBIT.ToString() },
                    };

                    foreach (Transaction transaction in transactions)
                    {
                        context.Transactions.Add(transaction);
                    }

                    context.SaveChanges();
                }
            }
            if (!context.Loans.Any())
            {
                //crearemos 3 prestamos Hipotecario, Personal y Automotriz
                var loans = new Loan[]
                {
                    new Loan { Name = "Hipotecario", MaxAmount = 500000, Payments = "12,24,36,48,60" },
                    new Loan { Name = "Personal", MaxAmount = 100000, Payments = "6,12,24" },
                    new Loan { Name = "Automotriz", MaxAmount = 300000, Payments = "6,12,24,36" },
                };

                foreach (Loan loan in loans)
                {
                    context.Loans.Add(loan);
                }

                context.SaveChanges();

                //ahora agregaremos los clientloan (Prestamos del cliente)
                //usaremos al único cliente que tenemos y le agregaremos un préstamo de cada item
                var client1 = context.Clients.FirstOrDefault(c => c.Email == "vcoronado@gmail.com");
                if (client1 != null)
                {
                    //ahora usaremos los 3 tipos de prestamos
                    var loan1 = context.Loans.FirstOrDefault(l => l.Name == "Hipotecario");
                    if (loan1 != null)
                    {
                        var clientLoan1 = new ClientLoan
                        {
                            Amount = 400000,
                            ClientId = client1.Id,
                            LoanId = loan1.Id,
                            Payments = "60"
                        };
                        context.ClientLoans.Add(clientLoan1);
                    }

                    var loan2 = context.Loans.FirstOrDefault(l => l.Name == "Personal");
                    if (loan2 != null)
                    {
                        var clientLoan2 = new ClientLoan
                        {
                            Amount = 50000,
                            ClientId = client1.Id,
                            LoanId = loan2.Id,
                            Payments = "12"
                        };
                        context.ClientLoans.Add(clientLoan2);
                    }

                    var loan3 = context.Loans.FirstOrDefault(l => l.Name == "Automotriz");
                    if (loan3 != null)
                    {
                        var clientLoan3 = new ClientLoan
                        {
                            Amount = 100000,
                            ClientId = client1.Id,
                            LoanId = loan3.Id,
                            Payments = "24"
                        };
                        context.ClientLoans.Add(clientLoan3);
                    }

                    //guardamos todos los prestamos
                    context.SaveChanges();

                }
                var client4 = context.Clients.FirstOrDefault(c => c.Email == "eduardomendoza@gmail.com");
                if (client4 != null)
                {
                    //ahora usaremos los 3 tipos de prestamos
                    var loan4 = context.Loans.FirstOrDefault(l => l.Name == "Hipotecario");
                    if (loan4 != null)
                    {
                        var clientLoan4 = new ClientLoan
                        {
                            Amount = 400000,
                            ClientId = client4.Id,
                            LoanId = loan4.Id,
                            Payments = "60"
                        };
                        context.ClientLoans.Add(clientLoan4);
                    }
                    context.SaveChanges();


                }

            }
            if (!context.Cards.Any())
            {
                //buscamos al unico cliente y toma al primero que coincida con el email q pusimos
                var client1 = context.Clients.FirstOrDefault(c => c.Email == "eduardomendoza@gmail.com");
                if (client1 != null)
                {
                    //le agregamos 2 tarjetas de crédito una GOLD y una TITANIUM, de tipo DEBITO Y CREDITO RESPECTIVAMENTE
                    var cards = new Card[]
                    {
                        new Card {
                            ClientId= client1.Id,
                            CardHolder = client1.FirstName + " " + client1.LastName,
                            Type = CardType.DEBIT.ToString(),
                            Color = CardColor.GOLD.ToString(),
                            Number = "3325-6745-7876-4445",
                            Cvv = 990,
                            FromDate= DateTime.Now,
                            ThruDate= DateTime.Now.AddYears(4),
                        },
                        new Card {
                            ClientId= client1.Id,
                            CardHolder = client1.FirstName + " " + client1.LastName,
                            Type = CardType.CREDIT.ToString(),
                            Color = CardColor.TITANIUM.ToString(),
                            Number = "2234-6745-552-7888",
                            Cvv = 750,
                            FromDate= DateTime.Now,
                            ThruDate= DateTime.Now.AddYears(5),
                        },
                    };

                    foreach (Card card in cards)
                    {
                        context.Cards.Add(card);
                    }
                    context.SaveChanges();
                }

            }
        }
    }
}
