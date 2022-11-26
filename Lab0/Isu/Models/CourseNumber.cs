using Isu.Services;

namespace Isu.Models;

public class CourseNumber
{
    public const int MaxCourse = 6;
    public const int MinCourse = 1;
    public CourseNumber(int number)
    {
        if (number > MaxCourse || number < MinCourse)
        {
            throw new ArgumentException("Incorrect course number");
        }

        Number = number;
    }

    public int Number { get; }
}