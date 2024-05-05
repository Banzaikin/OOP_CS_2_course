
using Newtonsoft.Json;
using System.Text;

namespace Lab16.Serialization
{
    public class TxtFile<T> : ISerializator<T> where T : new()
    {
        public string FileType { get => "txt"; }

        public T? Load(string filePath)
        {
            return new();
        }
        public void Save(T objNeedToSave, string filePath)
        {
            if (objNeedToSave != null)
            {
                using FileStream fileStream = new(filePath, FileMode.Create);
                byte[] buffer = Encoding.Default.GetBytes(objNeedToSave.ToString());
                fileStream.Write(buffer, 0, buffer.Length);
                fileStream.Close();
            }
        }

        public async void SaveAsync(T objNeedToSave, string filePath)
        {
            await Task.Run(() => Save(objNeedToSave, filePath));
        }
    }
}
