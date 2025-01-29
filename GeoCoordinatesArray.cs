namespace lab9;

public class GeoCoordinatesArray
{
    private GeoCoordinates[] array;
    public GeoCoordinatesArray(GeoCoordinates[] geoCoordinates)
    {
        this.array = geoCoordinates;
    }
    public void Initialize(int randomOrNo = 0)
    {
        array = new GeoCoordinates[InputTools.ReadInt("Сколько точек вы желаете добавить в массив?",
            "Ответом должно быть целое число больше нуля.", 0)];
        if (randomOrNo == 0)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Initialize();
                Console.Clear();
                Console.WriteLine("\x1b[3J");
            }
        }
        else
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new GeoCoordinates();
                array[i].Initialize(1);
            }
        }
    }

    public void Show()
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            array[i].Show();
            count++;
            if (count == 10)
            {
                Console.WriteLine("");
            }
        }
    }
}