using Common.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Validators
{
    public static class CategoryValidator
    {
        public static string ValidateCategoryName(string catName)
        {
            while (true)
                if (CharValidateExtension.ValidateBasicString(catName))
                {
                    if (catName.Length <= 15) { return catName; }
                    else
                    {
                        Console.WriteLine(" You entered a name that is too long! It must be less than 15 chars");
                        catName = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine(" You entered something not valid. Remember that special characters are not allowed. \n Please try again.");
                    catName = Console.ReadLine();
                }
        }

        public static string ValidateCategoryDescription(string catDescrip)
        {
            while (true)
                if (CharValidateExtension.ValidateBasicString(catDescrip))
                {
                    if (catDescrip.Length <= 300) { return catDescrip; }
                    else
                    {
                        Console.WriteLine(" You entered a description that is too long! It must be less than 300 chars");
                        catDescrip = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine(" You entered something not valid. Remember that special characters are not allowed. \n Please try again.");
                    catDescrip = Console.ReadLine();
                }
        }
    }
}
