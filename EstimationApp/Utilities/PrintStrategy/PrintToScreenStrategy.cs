using System.Windows;

namespace EstimationApp.Utilities.PrintStrategy
{
    public class PrintToScreenStrategy : IPrintStrategy
    {
        public void Print(string data)
        {
            MessageBox.Show(data);
        }
    }
}
