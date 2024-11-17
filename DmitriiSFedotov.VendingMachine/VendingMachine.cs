public class VendingMachine
{
    private readonly Product[] _products =
    [
        new Product()
        {
            Name = "Добрый Кола",
            Price = 100
        },
        new Product()
        {
            Name = "Вода Черноголовка",
            Price = 80
        },
        new Product()
        {
            Name = "Сок Добрый",
            Price = 120
        },
        new Product()
        {
            Name = "Чипсы Русская Картошка",
            Price = 100
        },
        new Product()
        {
            Name = "Печенье Овсяное",
            Price = 60
        }
    ];
    
    public void Run()
    {
        while (true)
        {
            for (int i = 0; i < _products.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {_products[i].Name} - {_products[i].Price}");
            }

            int selectedIndex = ReadFromConsole("\nВыберите товар: ") - 1;

            if (selectedIndex < 0 || selectedIndex > _products.Length - 1)
            {
                Console.WriteLine("Некорректный выбор! Попробуйте снова!");
                continue;
            }

            Console.WriteLine($"\nВы выбрали {_products[selectedIndex].Name} \nЦена: {_products[selectedIndex].Price} ");

            List<decimal> allowedBanknotes = new List<decimal>() { 5, 10, 50, 100, 500 };

            decimal currentSum = 0;

            while (true)
            {

                Console.WriteLine("\nАвтомат принимает купюры номиналом: ");

                for (int i = 0; i < allowedBanknotes.Count; i++)
                {
                    string m = i == allowedBanknotes.Count - 1
                        ? allowedBanknotes[i].ToString()
                        : $"{allowedBanknotes[i]}, ";
                    Console.Write(m);
                }

                decimal money = ReadFromConsole("\nВнесите купюру: ");

                if (money == 0)
                {
                    currentSum = 0;
                    break;
                }

                if (!allowedBanknotes.Contains(money)) // метод Contains проверяет содержит ли коллекция элемент
                {
                    Console.WriteLine("\nКупюра не распознана! Внесите другую!");
                    continue;
                }
                else
                {
                    currentSum = currentSum + money;
                    Console.WriteLine($"\nТекущая сумма: {currentSum}");
                }

                if (currentSum >= _products[selectedIndex].Price)
                {
                    Console.WriteLine($"\nЗаберите {_products[selectedIndex].Name}");

                    decimal change = currentSum - _products[selectedIndex].Price;

                    if (change > 0)
                    {
                        Console.WriteLine($"Возьмите сдачу: {change}");
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Внесите еще!");
                }
            }

            Console.ReadLine();
        }
    }
    
    private static int ReadFromConsole(string message)
    {
        bool parsed;
        int elementsCount;

        Console.Write(message);

        do
        {
            string? input = Console.ReadLine();
            parsed = int.TryParse(input, out elementsCount);
            if (!parsed)
            {
                Console.WriteLine("Некорректный выбор! Попробуйте снова!");
            }
        } while (!parsed);
        return elementsCount;
    }
}