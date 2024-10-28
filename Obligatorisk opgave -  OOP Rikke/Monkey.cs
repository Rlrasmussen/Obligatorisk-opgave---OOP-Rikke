using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Obligatorisk_opgave____OOP_Rikke
{
    internal class Monkey : Animal
    {
        #region field

        #endregion

        #region porporty


        #endregion

        #region constructor

        #endregion

        #region method
        public override void Eat(string food)
        {
            if (food != "banan")
            {
                Console.WriteLine($"The monkey can't eat {food}");
            }
            else
            {
                Console.WriteLine($"The monkey is eating the {food}");
            }
        }
        #endregion

    }
}
