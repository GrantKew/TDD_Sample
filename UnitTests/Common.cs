namespace UnitTests
{
    internal static class Common
    {
        internal static T RandomEnumValue<T>()
        {
            var random = new Random();
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(random.Next(values.Length));
        }

        internal static int RandomIntValue(int maxNumber)
        {
            var random = new Random();
            return random.Next(0, maxNumber);
        }
    }
}
