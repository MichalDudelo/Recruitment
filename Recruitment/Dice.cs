using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment
{
    public class Dice
    {
        private Random _random { get; init; }
        public int Roll() => _random.Next(1, 6);
        public Dice()
        {
            _random = new Random();
        }
       
    }
}
