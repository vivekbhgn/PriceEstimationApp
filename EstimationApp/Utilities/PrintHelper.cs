using EstimationApp.Utilities.PrintStrategy;


namespace EstimationApp.Utilities
{
    public static class PrintHelper
    {
        public static IPrintStrategy GetPrintStrategy(string printType)
        {
            switch(printType)
            {
                case "Screen":
                    return new PrintToScreenStrategy();
                case "File":
                    return new PrintToFileStrategy();
                case "Paper":
                    return new PrintToPaperStrategy();
                default:
                    return null;
            }
        }
    }
}
