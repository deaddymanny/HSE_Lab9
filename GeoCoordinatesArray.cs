using System.Xml;

namespace lab9;

public class GeoCoordinatesArray(GeoCoordinates[] geoCoordinates)
{
    private GeoCoordinates[] array = geoCoordinates;

    public void Initialize(int randomOrNo = 0)
    {
        array = new GeoCoordinates[InputTools.ReadInt("Сколько точек вы желаете добавить в массив?",
            "Ответом должно быть целое число больше нуля.", 0)];
        randomOrNo = InputTools.ReadInt("Как вы хотите создать точки? 0 - вручную, 1 - ДСЧ .", "", -1, 2);
        if (randomOrNo == 0)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new GeoCoordinates();
                array[i].Initialize();
                InputTools.ClearLogs();
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
            InputTools.MenuOutputNotALine($" | {(i+1)}. {array[i].Show()} | ");
            count++;
            if (count == 5)
            {
                InputTools.MenuOutputLine("");
                InputTools.MenuOutputLine("__________");
                count = 0;
            }
        }
    }

    public int Length()
    {
        return array.Length;
    }

    public GeoCoordinates ReturnElement(int elementToReturn)
    {
        return array[elementToReturn];
    }

    public string CompareToIslandZero()
    {
        GeoCoordinates islandZero = new GeoCoordinates();
        double closestDistanceToIsland = Double.MaxValue;
        int whatPointClosest = 0;
        for (int i = 0; i < array.Length; i++)
        {
            InputTools.MenuOutputLine($"{array[i].Show()} => {GeoCoordinates.CalculateDistance(array[i], islandZero)}");
            if (GeoCoordinates.CalculateDistance(array[i], islandZero) < closestDistanceToIsland)
            {
                closestDistanceToIsland = GeoCoordinates.CalculateDistance(array[i], islandZero);
                whatPointClosest = i;
            }
        }

        return $"Ближайшим к Острову 'Ноль' оказалась точка {array[whatPointClosest].Show()} на расстоянии {closestDistanceToIsland}";
    }
    
}