using Practica.EF.Data;

namespace Practica.EF.Logic
{
    public abstract class BaseLogic
    {
         protected readonly NorthwindContext ctx;

         public BaseLogic()
         {
            ctx = new NorthwindContext();
         }


    }
}
