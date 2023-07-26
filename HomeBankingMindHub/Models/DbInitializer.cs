using System;
using System.Linq;

namespace HomeBankingMindHub.Models
{
    public class DBInitializer
    {
        public static void Initialize(HomeBankingContext context)
        {
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