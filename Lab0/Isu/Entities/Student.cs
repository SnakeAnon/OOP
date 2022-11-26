using Isu.Models;

namespace Isu.Entities;

public class Student
{
    public Student(int id, string name, Group group)
    {
        if (id < 0)
        {
            throw new ArgumentException("Incorrect Id");
        }

        Group = group;
        Id = id;
        FirstName = name.Split(' ')[0];
        LastName = name.Split(' ')[1];
    }

    public int Id { get; }
    public Group Group { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string GetName()
    {
        return string.Concat(FirstName, LastName);
    }

    public int GetId()
    {
        return Id;
    }
}