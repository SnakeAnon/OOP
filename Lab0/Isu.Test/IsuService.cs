using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;
using Xunit;
namespace Isu.Test
{
    public class IsuService
    {
        [Fact]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            var isu = new Services.IsuService();
            var group = isu.AddGroup(new GroupName("M32081"));
            var student = isu.AddStudent(group, "Vova Pupkin");
            Assert.NotEmpty(group.Students);
            Assert.Equal(group, student.Group);
        }

        [Fact]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            var isu = new Services.IsuService();
            var group = isu.AddGroup(new GroupName("M3108"));
            for (int i = 0; i < Group.MaxGroupSize + 1; i++)
            {
                isu.AddStudent(group, "Test Test");
            }

            Assert.Throws<ArgumentNullException>(() => isu.AddStudent(group, "Artyom Test"));
        }

        [Fact]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Throws<FormatException>(() => new GroupName("gfsdndgxhjrg"));
        }

        [Fact]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            var isu = new Services.IsuService();
            var group1 = isu.AddGroup(new GroupName("M3108"));
            var group2 = isu.AddGroup(new GroupName("M3109"));
            var student = isu.AddStudent(group1, "Aboba Aboba") ?? throw new Exception();
            if (student != null)
            {
                isu.ChangeStudentGroup(student, group2);
                Assert.Contains(isu.FindStudents(group2.Name()), student2 => student2 == student);
            }
        }
    }
}
