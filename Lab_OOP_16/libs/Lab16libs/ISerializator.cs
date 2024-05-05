

namespace Lab16.Serialization
{ 
    public interface ISerializator<T>
    {
        public string FileType { get; }

        public T? Load(string filePath);

        public void Save(T objNeedToSave, string filePath);
    }

}
