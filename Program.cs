namespace lab9;

class Program
{
    static void Menu()
    {
        int choice = 0;
        switch (choice)
        {
            case 1:
                break;
            case 2:
                break;
        }
    }

    static void Main(string[] args)
    {
        GeoCoordinates gc1 = new GeoCoordinates();
        gc1.Initialize(InputTools.ReadInt(
            "Введите способ создания точки (1 - дсч, 0 - вручную)",
            "Импоссибл",
            -1,
            2)
        );
        gc1.Show();
        GeoCoordinates gc2 = new GeoCoordinates();
        gc2.Initialize(InputTools.ReadInt(
            "Введите способ создания точки (1 - дсч, 0 - вручную)",
            "Импоссибл",
            -1,
            2));
        gc2.Show();
        Console.WriteLine(GeoCoordinates.CalculateDistance(gc1, gc2));
        Console.WriteLine(GeoCoordinates.InstanceCount);
    }
}
