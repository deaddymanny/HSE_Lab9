namespace lab9;

class Program
{
    private static GeoCoordinates currentSelection = new GeoCoordinates();
    private static GeoCoordinatesArray currentArray;
    static void Menu()
    {
        int menuChoice = 1;
        do
        {
            
            switch (menuChoice)
            {
                
                // сгенерировать точки
                case 1:
                    currentArray = new GeoCoordinatesArray([]);
                    currentArray.Initialize();
                    currentArray.Show();
                    break;
                // выбрать точку
                case 2:
                    currentArray.Show();
                    currentSelection = currentArray.ReturnElement((InputTools.ReadInt(
                        "Выберите нужную вам точку из массива.",
                        "",
                        0,
                        currentArray.Length()+1))-1);
                    break;
                case 3:
                {
                    double distance;
                    currentArray.Show();
                    GeoCoordinates secondPoint = currentArray.ReturnElement(InputTools.ReadInt(
                        "Выберите нужную вам точку из массива.",
                        "",
                        0,
                        currentArray.Length())-1);
                    distance = GeoCoordinates.CalculateDistance(currentSelection, secondPoint);
                    Console.WriteLine($"Расстояние между {currentSelection.Show()} и {secondPoint.Show()} = {distance}");
                    break;
                }
                case 4:
                {
                    currentSelection.Append();
                    break;
                }
                case 5:
                {
                    currentSelection.Reverse();
                    break;
                }
                case 6:
                {
                    currentSelection.OnEquator();
                    break;
                }
                case 7:
                {
                    Console.WriteLine(currentSelection.WhatLongtitude());
                    break;
                }
                case 8:
                {
                    currentArray.Show();
                    GeoCoordinates secondPoint = currentArray.ReturnElement(InputTools.ReadInt(
                        "Выберите нужную вам точку из массива.",
                        "",
                        0,
                        currentArray.Length())-1);
                    GeoCoordinates.IsSameParallel(currentSelection, secondPoint);
                    break;
                }
                case 9:
                {
                    currentArray.Show();
                    GeoCoordinates secondPoint = currentArray.ReturnElement(InputTools.ReadInt(
                        "Выберите нужную вам точку из массива.",
                        "",
                        0,
                        currentArray.Length())-1);
                    GeoCoordinates.IsSameMeridian(currentSelection, secondPoint);
                    break;
                }
                case 10:
                {
                    Console.WriteLine(currentArray.CompareToIslandZero());
                    break;
                }
                case 11:
                {
                    Console.WriteLine($"На данный момент было создано {GeoCoordinates.InstanceCount - 1} точек.");
                    break;
                }
                case 12:
                {
                    break;
                }
            }
            MenuIntroduction();
            menuChoice = InputTools.ReadInt("", "Ответом должно быть целое число больше нуля. Вызовите меню с помощью 12.", -1);
            InputTools.ClearLogs();
        } while (menuChoice != 0);
           
    }
    static void MenuIntroduction()
    {
        Console.WriteLine("Лабораторная работа №9");
        Console.WriteLine("Вариант №6 - Географические координаты");
        Console.WriteLine("by Ростислав Катаргин (РИС 24-4-7)");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"На данный момент выбрана точка {currentSelection.Show()}");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Выберите желаемую операцию:");
        Console.WriteLine("");
        Console.WriteLine("0. Выйти из программы.");
        Console.WriteLine("1. Сформировать массив географических точек.");
        Console.WriteLine("2. Выбрать географическую точку для дальнейших действий.");
        Console.WriteLine("3. Высчитать расстояние между двумя точками (Текущая точка + из массива)");
        Console.WriteLine("4. Повысить координаты точки на 0.01 .");
        Console.WriteLine("5. Поменять знак координат выбранной точки.");
        Console.WriteLine("6. Определить, находится ли точка на экваторе.");
        Console.WriteLine("7. Определить, на какой долготе находится точка.");
        Console.WriteLine("8. Сравнить, находятся ли обе точки на одной параллели.");
        Console.WriteLine("9. Сравнить, находятся ли точки на разных меридианах.");
        Console.WriteLine("10. Сравнить расстояние всех точек массива к 'Острову Ноль'.");
        Console.WriteLine("11. Подсчитать количество созданных географических точек.");
    }
    static void Main(string[] args)
    {
        Menu();
        /*
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
        */
    }
}
