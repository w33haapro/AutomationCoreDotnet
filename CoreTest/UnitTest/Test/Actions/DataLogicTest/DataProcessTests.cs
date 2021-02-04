using Core.UnitTest.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace Core.UnitTest.Test.DataLogicTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class DataProcessTests
    {
        [Test]
        public void JsonProcess_JsonProcess_Successfully()
        {
            Student student = new Student();
            student.Name = "John";
            student.Age = 31;
            student.City = "New York";

            string studentJson = "{ \"Name\":\"John\", \"Age\":31, \"City\":\"New York\"}";
            var actualStudent = studentJson.ToObject<Student>();

            student.AreEqual(actualStudent);

            var actualStudentJson = student.ToJson<Student>();

            studentJson.AreEqualJson(actualStudentJson);

        }

        [Test]
        public void JsonProcess_JsonArrayProcess_Successfully()
        {
            List<Student> students = new List<Student>();

            Student student2 = new Student();
            student2.Name = "John";
            student2.Age = 31;
            student2.City = "New York";
            students.Add(student2);

            Student student = new Student();
            student.Age = 20;
            student.Name = "W33";
            student.City = "Ha Noi";
            students.Add(student);



            string studentJson = "[{ \"Name\":\"W33\", \"Age\":20, \"City\":\"Ha Noi\"}, { \"Name\":\"John\", \"Age\":31, \"City\":\"New York\"}]";
            var actualStudent = studentJson.ToListObject<Student>();

            students.AreEqual(actualStudent);

            var actualStudentJson = students.ToJson<Student>();

            studentJson.AreEqualJson(actualStudentJson);

        }

        [Test]
        public void JsonProcess_JsonObjectGetValue_Successfully()
        {
            string studentJson = "{ \"Name\":\"W33\", \"Age\":20, \"City\":\"Ha Noi\"}";
            var data = studentJson.JsonObjectGetJValue("$..Name");
        }

        [Test]
        public void JsonProcess_JsonArrayGetValue_Successfully()
        {
            string studentJson = "[{ \"Name\":\"W33\", \"Age\":20, \"City\":\"Ha Noi\"},{ \"Name\":\"W33Haa\", \"Age\":30, \"City\":\"Ha Noi 2\"}]";
            var data = studentJson.JsonArrayGetJValue("$..[0].Name");
        }


    }
}
