namespace JsonSerializerBenchmarks
{
    internal static class RandomString
    {
        private static readonly Random Random = new();
        internal static string Generate(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Range(1, length).Select(_ => chars[Random.Next(chars.Length)]).ToArray());
        }
    }
}
