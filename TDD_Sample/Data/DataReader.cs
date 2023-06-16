using Newtonsoft.Json;

namespace TDD_Sample.Data
{
    public static class DataReader
    {
        public static T ReadAndonvertData<T>(string file)
        {
            using (var reader = new StreamReader($@"Data\{file}.json"))
            {
                var data = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(data);
            }
        }
    }
}
