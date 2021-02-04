using Core.UnitTest.Model;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;

namespace Core.UnitTest.Test.Data.DataAccess
{
    [TestFixture]
    public class FileTests : BaseFixture
    {
        [Test]
        public void ReadCsv_ValidPath_Successfully()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\..\CoreTest\UnitTest\DataTest\User.csv";
            var data = FileAccess.ReadCsv(filePath).ToList<User>();
            data.Count.AreEqual(2);
        }

        [Test]
        public void ReadCsv_ValidPathAndFileDoNotHaveHeaders_Successfully()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\..\CoreTest\UnitTest\DataTest\User.csv";
            var data = FileAccess.ReadCsv(filePath, false);
            data.Rows.Count.AreEqual(3);
        }

        [Test]
        public void ReadJson_ValidPath_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadJson(currentDirectory + @"..\..\..\..\..\CoreTest\UnitTest\DataTest\student.json");
            data.IsNotNull();
        }

        [Test]
        public void ReadExcel_ValidPath_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadExcel(currentDirectory + @"..\..\..\..\..\CoreTest\UnitTest\DataTest\User.xlsx").ToList<User>();
            data.Count.AreEqual(2);
        }


        [Test]
        public void ReadExcel_ValidPathWIthWorksheetIndexAndHaveHeaders_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadExcel(currentDirectory + @"..\..\..\..\..\CoreTest\UnitTest\DataTest\User.xlsx", 0).ToList<User>();
            data.Count.AreEqual(2);
        }

        [Test]
        public void ReadExcel_ValidPathWIthWorksheetIndexAndDonotHaveHeaders_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadExcel(currentDirectory + @"..\..\..\..\..\CoreTest\UnitTest\DataTest\User.xlsx", 0, false);
            data.Rows.Count.AreEqual(3);
        }

        [Test]
        public void ReadExcel_ValidPathWIthWorksheetName_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadExcel(currentDirectory + @"..\..\..\..\..\CoreTest\UnitTest\DataTest\User.xlsx", "User").ToList<User>();
            data.Count.AreEqual(2);
        }

        [Test]
        public void ReadExcel_ValidPathWIthWorksheetNameAndDonotHaveHeaders_Successfully()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var data = FileAccess.ReadExcel(currentDirectory + @"..\..\..\..\..\CoreTest\UnitTest\DataTest\User.xlsx", "User", false);
            data.Rows.Count.AreEqual(3);
        }

    }
}
