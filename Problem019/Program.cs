using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem019
{
    /// <summary>
    /// From 0 to 11
    /// </summary>
    public class Month
    {
        public Day[] Days { get; set; }
    }
    public class Day
    {
        /// <summary>
        /// Start with 0
        /// </summary>
        public int IndexOfYear { get; set; }
        /// <summary>
        /// Sun 0 , Mon 1, Tus 2, Wen 3 , Ths, 4, Fri 5, Sat 6
        /// </summary>
        public int IndexOfWeek { get; set; }
    }
    public class Year
    {
        public bool LeapYear { get; private set; }
        public Month[] Months { get; private set; }
        private Year() { }
        public Year(bool leapYear)
        {
            this.LeapYear = leapYear;
            this.Months = new Month[12];
            for (int i = 0; i < Months.Length; i++)
            {
                this.Months[i] = new Month();
                if (i == 8 || i == 3 || i == 10 || i == 5)
                {
                    this.Months[i].Days = new Day[30];
                    continue;
                }
                if (i == 1)
                {
                    if (leapYear)
                    {
                        this.Months[i].Days = new Day[29];
                        continue;
                    }
                    this.Months[i].Days = new Day[28];
                    continue;
                }
                this.Months[i].Days = new Day[31];
            }
        }
    }
    class Program
    {
        static void BuildLeapYears()
        {
            for (int i = 1; i <= 2000; i++)
            {
                if (i % 400 == 0)
                {
                    leapYears[i] = new Year(true);
                    continue;
                }
                if (i % 100 == 0)
                {
                    leapYears[i] = new Year(false);
                    continue;
                }
                if (i % 4 == 0)
                {
                    leapYears[i] = new Year(true);
                    continue;
                }
                leapYears[i] = new Year(false);
            }
        }
        static void LoopDays(int startYear, int startMonth, int startDay, int startWeekDay)
        {
            int tmpWeekDay = startWeekDay;
            int year = startYear;
            int month = startMonth;
            int day = startDay;
            for (; year <= 2000; year++)
            {
                for (; month < 12; month++)
                {
                    for (; day < leapYears[year].Months[month].Days.Length; day++)
                    {
                        leapYears[year].Months[month].Days[day] = new Day() { IndexOfWeek = tmpWeekDay };
                        tmpWeekDay = (tmpWeekDay + 1) % 7;
                    }
                    day = 0;
                }
                month = 0;
            }
        }
        static int CountResult()
        {
            int result = 0;
            for (int year = 1901; year <= 2000; year++)
            {
                for (int month = 0; month < 12; month++)
                {
                    if (leapYears[year].Months[month].Days[0].IndexOfWeek == 0)
                        result++;
                }
            }
            return result;
        }
        static Year[] leapYears;

        static void Main(string[] args)
        {
            leapYears = new Year[2001];
            BuildLeapYears();
            LoopDays(1900, 0, 0, 1);
            int result = CountResult();
            Debug.WriteLine(result);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
