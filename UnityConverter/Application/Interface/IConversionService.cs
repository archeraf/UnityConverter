namespace UnityConverter.Application.Interface
{
    public interface IConversionService
    {
        public double Convert(double value, string fromUnit, string toUnit);
    }
}
