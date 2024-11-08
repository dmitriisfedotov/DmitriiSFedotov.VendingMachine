namespace DmitriiSFedotov.VendingMachine;

internal class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();

            string[] productNames = { "Добрый Кола", "Вода Черноголовка", "Сок Добрый", "Чипсы Русская Картошка", "Печенье Овсяное" };

            decimal[] productPrices = { 100, 80, 120, 100, 60 };

            for (int i = 0; i < productNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {productNames[i]} - {productPrices[i]}");
            }

            int selectedIndex = ReadFromConsole("Выберите товар: ") - 1;

            if (selectedIndex < 0 || selectedIndex > productNames.Length - 1)
            {
                Console.WriteLine("Некорректный выбор! Попробуйте снова!");
                continue;
            }

            Console.WriteLine($"\nВы выбрали {productNames[selectedIndex]} \nЦена: {productPrices[selectedIndex]} ");

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

                if (!allowedBanknotes.Contains(money))   // метод Contains проверяет содержит ли коллекция элемент
                {
                    Console.WriteLine("Купюра не распознана! Внесите другую!");
                    continue;
                }
                else
                {
                    currentSum = currentSum + money;
                    Console.WriteLine($"\nТекущая сумма: {currentSum}");
                }

                if (currentSum >= productPrices[selectedIndex])
                {
                    Console.WriteLine($"Заберите {productNames[selectedIndex]}");

                    decimal change = currentSum - productPrices[selectedIndex];

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

        return;

        static int ReadFromConsole(string message)
        {
            bool parsed;
            int elementsCount;

            Console.Write(message);

            do
            {
                string input = Console.ReadLine();
                parsed = int.TryParse(input, out elementsCount);
                if (!parsed)
                {
                    Console.WriteLine("Некорректный выбор! Попробуйте снова!");
                }
            } while (!parsed);
            return elementsCount;
        }
    }
}