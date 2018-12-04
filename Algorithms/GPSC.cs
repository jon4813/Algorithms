using System.ComponentModel.DataAnnotations;

namespace Algorithms
{
    public class Gpsc
    {
        private int _ceed;

        public Gpsc(int ceed)
        {
            _ceed = ceed;
        }

        public int Next(int max = 1)
        {
            var tmp =  _ceed = (2 * _ceed + 5);
            var m = 1 + tmp % (max);

            _ceed = (_ceed / m) * (max);
            return _ceed;
        }
    }
}