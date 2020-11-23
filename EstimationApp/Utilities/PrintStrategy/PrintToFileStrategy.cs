using System.IO;

namespace EstimationApp.Utilities.PrintStrategy
{
    public class PrintToFileStrategy : IPrintStrategy
    {
        public void Print(string data)
        {
            if (!File.Exists("Print.txt"))
            {
                using (var stream = File.Create("Print.txt"))
                {

                }
            }
            File.WriteAllText("Print.txt", data);
        }
    }
}
