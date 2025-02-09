namespace lab9;

public class GeoCoordinates
{
    private static int instanceCount = 0; // поле счетчик созданных объектов класса
    private double latitude; // поле широты
    private double longtitude; // поле долготы

    public double Latitude // метод для изменения широты
    {
        get => latitude;
        set
        {
            if (value < -90 || value > 90)
            {
                throw new Exception("Неверные данные");
            }
            latitude = value;
        }
    }
    
    public double Longtitude
    {
        get => longtitude;
        set
        {
            if (value < -180 || value > 180)
            {
                throw new Exception("Неверные данные");
            }

            longtitude = value;
        }
    } // метод для изменения долготы

    public static int InstanceCount
    {
        get => instanceCount;
    } // метод, возвращающий значание того, сколько объектов было создано

    private static readonly Random Rnd = new Random(); 
    // полагаю, что используемые классы лучше инициализировать вначале
    public GeoCoordinates() // строчки кода, инициализирующиеся при создании нового объекта для подсчета их количества
    {
        latitude = 0;
        longtitude = 0;
        instanceCount++;
    }
    public void Initialize(int randomOrNo = 0) // определение координат точки 
    {
        if (randomOrNo == 0)
        {
            Latitude = InputTools.ReadDouble(
                "Введите широту координаты.", 
                "Ошибка! Широтой координаты должно быть число в формате XX.XX .", 
                -91, 91);
            Longtitude = InputTools.ReadDouble(
                "Введите долготу координаты.", 
                "Ошибка! Долготой координаты должно быть число в формате XX.XX .", 
                -181, 181);
            // у них одз не стоит епт или стоит??
        }
        else
        {
            Latitude = Rnd.Next(-90, 90);
            Longtitude = Rnd.Next(-180, 180);
        }
    }

    public string Show() // вывод координат точки
    {
        return ($"{this.Latitude};{this.Longtitude}");
    }
    // distancebetweentwo+
    // append +
    // reverse +
    // onequator?
    // whatlongtitudeon +
    // same parallel (2)+
    // different meridians (2)+

    public static double CalculateDistance(GeoCoordinates gc1, GeoCoordinates gc2)
    {
        // радиус земли - константа
        double earthRadius = 6371;
        
        // перевод широты и долготы обоих точек в радианы для использования формулы гаверсинусов
        double lat1 = gc1.Latitude * Math.PI / 180;
        double lat2 = gc2.Latitude * Math.PI / 180;
        double long1 = gc1.Longtitude * Math.PI / 180;
        double long2 = gc2.Longtitude * Math.PI / 180;
        
        // высчитывание тригонометрических функций для использования формулы гаверсинусов
        double cosLat1 = Math.Cos(lat1);
        double cosLat2 = Math.Cos(lat2);
        double sinLat1 = Math.Sin(lat1);
        double sinLat2 = Math.Sin(lat2);

        double delta = long2 - long1;
        double cosDelta = Math.Cos(delta);
        double sinDelta = Math.Sin(delta);
        // формула гаверсинусов для двуъ точек
        double y = Math.Sqrt(Math.Pow(cosLat2 * sinDelta, 2) +
                             Math.Pow(cosLat1 * sinLat2 - sinLat1 * cosLat2 * cosDelta, 2));
        double x = (sinLat1 * sinLat2) + (cosLat1 * cosLat2 * cosDelta);

        double ad = Math.Atan2(y, x);
        // возвращение расстояния между двумя точками в километрах
        return (ad * earthRadius);
    }
    
    public void Append() // увеличение широты и долготы точки на 0.01
    {
        if (Latitude != 90 || Longtitude != 180)
        {
            Latitude += 0.01;
            Longtitude += 0.01;
        }
    }

    /// <summary>
    /// "переворот" знаков кординат точки
    /// </summary>
    public void Reverse()
    {
        Latitude *= -1;
        Longtitude *= -1;
    }

    public bool OnEquator()
    {
        if (Latitude == 0)
        {
            return true;
        }
        return false;
    } // проверка нахождения точки на экваторе

    public string WhatLongtitude() // проверка на каком меридиане находится точка
    {
        if (Longtitude > 0)
        {
            return ("Точка находится на восточном меридиане.");
        }
        if (Longtitude < 0)
        {
            return ("Точка находится на западном меридиане.");
        }
        return ("Точка находится на нулевом меридиане.");
    }
    
    public Meridian WhatLongtitudeEnum() // проверка на каком меридиане находится точка
    {
        if (Longtitude > 0)
        {
            return Meridian.Eastern;
        }
        if (Longtitude < 0)
        {
            return Meridian.Western;
        }
        return Meridian.Zero;
    }

    // public void OutputMeridian(Meridian meridian)
    // {
    //     switch (meridian)
    //     {
    //         case Meridian.Eastern:
    //             Console.WriteLine("Восточный")
    //     }
    // }
    

    public static bool IsSameMeridian(GeoCoordinates point1, GeoCoordinates point2) // проверка находятся ли точки на
    // одном и том же меридиане
    {
        if (point1.Longtitude == point2.Longtitude)
        {
            return true;
        }
        return false;
    }

    public static bool IsSameParallel(GeoCoordinates point1, GeoCoordinates point2) // проверка находятся ли точки
    // на одной и той же параллели
    {
        return point1.Latitude == point2.Latitude;
    }

    public void CopyData(GeoCoordinates whatToCopy)
    {
        this.Longtitude = whatToCopy.Longtitude;
        this.Latitude = whatToCopy.Latitude;
    }
}