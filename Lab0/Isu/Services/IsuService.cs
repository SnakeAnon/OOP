using Isu.Entities;
using Isu.Models;

namespace Isu.Services;

public class IsuService : IIsuService
{
    private readonly List<Group> _listOfGroups;
    private int id = 0;

    public IsuService()
    {
        _listOfGroups = new List<Group>();
    }

    public IReadOnlyCollection<Group> GroupsList => _listOfGroups;

    public Group AddGroup(GroupName name)
    {
        ArgumentNullException.ThrowIfNull(name);
        var groupNew = new Group(name);
        _listOfGroups.Add(groupNew);
        return groupNew;
    }

    public Student AddStudent(Group group, string name)
    {
        ArgumentNullException.ThrowIfNull(group);
        ArgumentNullException.ThrowIfNull(name);
        var student = new Student(++id, name, group);
        group.AddStudent(student);
        return student;
    }

    public Student FindStudent(int id)
    {
        ArgumentNullException.ThrowIfNull(id);
        int i = 0;
        Student temporaryStudentArgument = null;
        while (i < _listOfGroups.Capacity && temporaryStudentArgument == null)
        {
            temporaryStudentArgument = _listOfGroups[i].Students.SingleOrDefault(x => x.GetId() == id);
            ++i;
        }

        return temporaryStudentArgument;
    }

    public Student GetStudent(int id)
    {
        return FindStudent(id) ?? throw new ArgumentNullException("Null");
    }

    public List<Student> FindStudents(GroupName groupName)
    {
        ArgumentNullException.ThrowIfNull(groupName);
        return (List<Student>)_listOfGroups.SingleOrDefault(x => x.Name() == groupName)?.Students;
    }

    public List<Student> FindStudents(CourseNumber courseNumber)
    {
        ArgumentNullException.ThrowIfNull(courseNumber);
        return (List<Student>)_listOfGroups.SingleOrDefault(x => x.Name().ToString() ![2] == (char)courseNumber.Number)
            ?.Students;
    }

    public Group FindGroup(GroupName groupName)
    {
        ArgumentNullException.ThrowIfNull(groupName);
        return _listOfGroups.SingleOrDefault(x => x.Name() == groupName);
    }

    public List<Group> FindGroups(CourseNumber courseNumber)
    {
        ArgumentNullException.ThrowIfNull(courseNumber);
        return _listOfGroups.FindAll(x => x.Name().ToString() ![2] == (char)courseNumber.Number);
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        ArgumentNullException.ThrowIfNull(student);
        ArgumentNullException.ThrowIfNull(newGroup);
        newGroup.AddStudent(student);
        _listOfGroups.FirstOrDefault(x => x.Students.Contains(student))?.RemoveStudent(student);
    }
}