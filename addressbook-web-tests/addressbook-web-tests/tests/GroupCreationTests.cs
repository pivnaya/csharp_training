using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < 5; i ++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();

            string fileName = Path.Combine(AppContext.BaseDirectory, "groups.csv");
            string[] lines = File.ReadAllLines(fileName);
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0]) 
                { 
                    Header = parts[1],
                    Footer = parts[2]
                });
            }

            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            string fileName = Path.Combine(AppContext.BaseDirectory, "groups.xml");
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(fileName));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            string fileName = Path.Combine(AppContext.BaseDirectory, "groups.json");
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(fileName));
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();

            string fileName = Path.Combine(AppContext.BaseDirectory, "groups.xlsx");
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(fileName);
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;

            for (int i = 1; i <= range.Rows.Count; i++ )
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                }); ;
            }
            wb.Close();
            app.Quit();

            return groups;
        }

        [Test, TestCaseSource("GroupDataFromExcelFile")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

