using Isu.Services;

namespace Isu.Models;

public class GroupName
{
    private const int MaxGroup = 15;

    public GroupName(string groupName)
    {
        CourseNumber = new CourseNumber(Convert.ToUInt16(groupName.Substring(2, 1)));
        GroupNumber = Convert.ToUInt16(groupName.Substring(3, 2));
        GroupChar = Convert.ToChar(groupName.Substring(0, 1));

        if (GroupNumber > MaxGroup)
        {
            throw new ArgumentException("Overflow exception");
        }

        if (string.IsNullOrWhiteSpace(groupName) || string.IsNullOrEmpty(groupName))
        {
            throw new ArgumentNullException("Null exception");
        }
    }

    public uint GroupNumber { get; }
    public char GroupChar { get; }
    public CourseNumber CourseNumber { get; }
}