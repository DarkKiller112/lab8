using System;
using System.Collections.Generic;

class Client
{
    public string Name { get; set; }
    public bool IsRegularCustomer { get; set; }

    internal Program Program
    {
        get => default;
        set
        {
        }
    }

    internal TravelAgency TravelAgency
    {
        get => default;
        set
        {
        }
    }

    public Client(string name, bool isRegularCustomer)
    {
        Name = name;
        IsRegularCustomer = isRegularCustomer;
    }
}

class Tour
{
    public string Type { get; set; }
    public double Price { get; set; }
    public bool IsHot { get; set; }

    internal Program Program
    {
        get => default;
        set
        {
        }
    }

    internal TravelAgency TravelAgency
    {
        get => default;
        set
        {
        }
    }

    public Tour(string type, double price, bool isHot)
    {
        Type = type;
        Price = price;
        IsHot = isHot;
    }
}

class TravelAgency
{
    private List<Tour> tours = new List<Tour>();
    private List<Client> clients = new List<Client>();

    internal Program Program
    {
        get => default;
        set
        {
        }
    }

    internal Tour Tour
    {
        get => default;
        set
        {
        }
    }

    internal Client Client
    {
        get => default;
        set
        {
        }
    }

    public void AddTour(Tour tour)
    {
        tours.Add(tour);
    }

    public void AddClient(Client client)
    {
        clients.Add(client);
    }

    public double GenerateBill(Client client, Tour tour)
    {
        double discount = client.IsRegularCustomer ? 0.1 : 0;
        double finalPrice = tour.Price * (1 - discount);
        if (tour.IsHot)
        {
            finalPrice *= 0.9; // дополнительная скидка на горящий тур
        }
        return finalPrice;
    }

    public Client FindClient(string name)
    {
        return clients.Find(c => c.Name == name);
    }

    public Tour FindTour(string type)
    {
        return tours.Find(t => t.Type == type);
    }
}
class Program
{
    static void Main(string[] args)
    {
        TravelAgency agency = new TravelAgency();
        while (true)
        {
            Console.WriteLine("\nГлавное меню");
            Console.WriteLine("1. Добавить тур");
            Console.WriteLine("2. Добавить клиента");
            Console.WriteLine("3. Оформить заказ");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите опцию: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите тип тура (отдых, экскурсия, шоппинг): ");
                    string type = Console.ReadLine();
                    Console.Write("Введите цену тура: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write("Тур является горящим? (да/нет): ");
                    bool isHot = Console.ReadLine().ToLower() == "да";
                    Tour tour = new Tour(type, price, isHot);
                    agency.AddTour(tour);
                    Console.WriteLine("Тур добавлен!");
                    break;
                case "2":
                    Console.Write("Введите имя клиента: ");
                    string name = Console.ReadLine();
                    Console.Write("Клиент постоянный? (да/нет): ");
                    bool isRegularCustomer = Console.ReadLine().ToLower() == "да";
                    Client client = new Client(name, isRegularCustomer);
                    agency.AddClient(client);
                    Console.WriteLine("Клиент добавлен!");
                    break;
                case "3":
                    Console.Write("Введите имя клиента: ");
                    string clientName = Console.ReadLine();
                    Console.Write("Введите тип тура: ");
                    string tourType = Console.ReadLine();
                    Client foundClient = agency.FindClient(clientName);
                    Tour foundTour = agency.FindTour(tourType);
                    if (foundClient != null && foundTour != null)
                    {
                        double bill = agency.GenerateBill(foundClient, foundTour);
                        Console.WriteLine($"Счёт для {foundClient.Name}: {bill}");
                    }
                    else
                    {
                        Console.WriteLine("Клиент или тур не найдены.");
                    }
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неправильный выбор. Пожалуйста, попробуйте снова.");
                    break;
            }
        }
    }
}
