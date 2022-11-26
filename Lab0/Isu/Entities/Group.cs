using System.Collections.ObjectModel;
using Isu.Models;
using Isu.Services;

namespace Isu.Entities;

public class Group
{
    public const int MaxGroupSize = 30;
    private List<Student> _students;

    public Group(GroupName groupNumber)
    {
        GroupNumber = groupNumber;
        _students = new List<Student>();
    }

    public GroupName GroupNumber { get; }
    public IReadOnlyCollection<Student> Students => _students;

    public void AddStudent(Student student)
    {
        if (Students.Contains(student) || Students.Count > MaxGroupSize)
        {
            throw new ArgumentNullException("Null exception");
        }

        _students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        if (!Students.Contains(student) || Students.Count == 0)
        {
            throw new ArgumentNullException("Null exception");
        }

        _students.Remove(student);
    }

    public GroupName Name()
    {
        return GroupNumber;
    }

    public int Size()
    {
        return Students.Count;
    }
}