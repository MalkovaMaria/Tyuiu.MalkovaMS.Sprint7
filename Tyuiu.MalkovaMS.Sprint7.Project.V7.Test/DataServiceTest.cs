using Tyuiu.MalkovaMS.Sprint7.Project.V7.Lib;
namespace Tyuiu.MalkovaMS.Sprint7.Project.V7.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void FileExist()
        {
            string path = @"C:\Users\marim\source\repos\Tyuiu.MalkovaMS.Sprint7\Tyuiu.MalkovaMS.Sprint7.Project.V7\dom2.csv";
            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;
            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void ValidLoadFromFileData()
        {
            DataService ds = new DataService();
            string path = @"C:\DataSprint7\test1.txt";
            string[,] wait = new string[,] { { "1", "5", "dum" }, { "tiu", "15", "ok" } };
            CollectionAssert.AreEqual(wait, ds.LoadFromFileData(path));
        }
    }
}
