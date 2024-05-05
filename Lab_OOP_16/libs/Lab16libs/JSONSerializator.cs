
using Newtonsoft.Json;

namespace Lab16.Serialization
{
    public class JSONSerializator<T> : ISerializator<T>
    {
        public string FileType => "json";

        public JsonSerializerSettings settings { get; set; } = new JsonSerializerSettings()
        {
            //для полиморфизма, чтобы могла обращаться к атрибутам дочерних классов
            TypeNameHandling = TypeNameHandling.All,
            //разбивает файл из одной строки, чтобы норм было
            Formatting = Formatting.Indented
        };

        public T? Load(string filePath)
        {
            string json = System.IO.File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        public void Save(T objNeedToSave, string filePath)
        {
            string json = JsonConvert.SerializeObject(objNeedToSave, settings);
            System.IO.File.WriteAllText(filePath, json);

        }

        public async void SaveAsync(T objNeedToSave, string filePath)
        {
            await Task.Run(() => Save(objNeedToSave, filePath));
        }
    }
}
