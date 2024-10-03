namespace Infrastructure.Extras
{
    public class CubicCalculation : ICurveCalculation
    {
        private int _koeff1 = 2;
        private int _koeff2 = 3;
        private int _startCount = 3;

        public CubicCalculation(int koeff1,int koeff2, int startCount)
        {
            _koeff1 = koeff1;
            _koeff2 = koeff2;
            _startCount = startCount;
        }

        public int Calculate(int value)
        {
            return _koeff1 * value * value + _koeff2 * value + _startCount;
        }
    }
}