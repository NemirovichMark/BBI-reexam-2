using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task1
    {
        public Task1() 
        { 

        }
    }
}


class SimpleDate
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public bool IsLeapYear()
    {
        if (Year % 4 == 0)
        {
            if (Year % 100 == 0)
            {
                if (Year % 400 == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    public string ToDateString()
    {
        return $"{Day:D2}.{Month:D2}.{Year}";
    }
}

class Program
{
    static void Main()
    {
        SimpleDate[] dates = new SimpleDate[10]
        {
            new SimpleDate() { Day = 1, Month = 3, Year = 2020 },
            new SimpleDate() { Day = 15, Month = 5, Year = 2021 },
            new SimpleDate() { Day = 10, Month = 7, Year = 2022 },
            new SimpleDate() { Day = 12, Month = 6, Year = 2023 },
            new SimpleDate() { Day = 25, Month = 12, Year = 2019 },
            new SimpleDate() { Day = 5, Month = 9, Year = 2022 },
            new SimpleDate() { Day = 2, Month = 1, Year = 2021 },
            new SimpleDate() { Day = 30, Month = 4, Year = 2020 },
            new SimpleDate() { Day = 18, Month = 8, Year = 2023 },
            new SimpleDate() { Day = 6, Month = 11, Year = 2021 }
        };

        for (int i = 0; i < dates.Length - 1; i++)
        {
            for (int j = i + 1; j < dates.Length; j++)
            {
                if (CompareDates(dates[i], dates[j]) > 0)
                {
                    SimpleDate temp = dates[i];
                    dates[i] = dates[j];
                    dates[j] = temp;
                }
            }
        }

        Console.WriteLine("Даты в хронологическом порядке:");
        Console.WriteLine("Дата");
        foreach (var date in dates)
        {
            Console.WriteLine(date.ToDateString());
        }
    }

    static int CompareDates(SimpleDate date1, SimpleDate date2)
    {
        if (date1.Year != date2.Year)
            return date1.Year.CompareTo(date2.Year);
        if (date1.Month != date2.Month)
            return date1.Month.CompareTo(date2.Month);
        return date1.Day.CompareTo(date2.Day);
    }
}
