// ---- C# II (Dor Ben Dor) ----
// Wael Abd Elal
// -----------------------------

class Program
{
    static void Main(string[] args)
    {
        ObservableLimitedList list = new ObservableLimitedList(item => item.Contains("s") || item.Contains("S"), 10);

        list.ListChanged += (sender, e) =>
        {
            var listSender = sender as ObservableLimitedList;
            if (listSender != null)
            {
                var items = listSender.GetItems().ToList();
                Console.Write($"List changed: ");
                for (int i = 0; i < items.Count(); i++)
                {
                    var item = items[i];

                    if (item == e.ItemChanged)
                    {
                        for (int j = 0; j < item.Length; j++)
                        {
                            char c = item[j];
                            // Highlight 's' or 'S' in Cyan
                            if (char.ToLower(c) == 's')
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(c);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(c);
                                Console.ResetColor();
                            }
                        }
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        // default
                        Console.Write($"{item}, ");
                    }
                }
                Console.WriteLine();
            }
        };

        string[] itemsToAdd = { "tokyo", "Tuxedo", "List", "intel", "Doc", "testers", "demo", "array", "Strings", "end" };
        foreach (var item in itemsToAdd)
        {
            list.TryAdd(item);
        }
    }
}