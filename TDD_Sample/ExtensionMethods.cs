namespace TDD_Sample
{
    public static class ExtensionMethods
    {
        public static bool EqualsIgnoreCase(this string value, string compareToValue)
        {
            return value.Equals(compareToValue, StringComparison.OrdinalIgnoreCase);
        }
    }
}
