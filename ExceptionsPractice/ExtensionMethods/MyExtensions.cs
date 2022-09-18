using System.Collections.Generic;

namespace ExceptionsPractice.ExtensionMethods
{
    public static class MyExtensions
    {
        public static List<string> AddBestFruit(this List<string> list)
        {
            string bestFruit = "Strawberry";
            list.Add(bestFruit);
            return list;
        }
    }
}
