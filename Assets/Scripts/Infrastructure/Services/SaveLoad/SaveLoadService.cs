using TIM;

namespace Infrastructure.Services
{
    public class SaveLoadService : ISaveLoadService
    {
        public SaveLoadService()
        {
            SaveSystem.LoadAll();
        }

        public void Save<T>(T data, string path)
        {
            SaveSystem.SaveFile(data, path);
        }

        public T Load<T>(string path) where T : new()
        {
            if (SaveSystem.CheckFile_Disk(path))
            {
                return SaveSystem.LoadFile<T>(path);;
            }
            return new T();
        }
    }
}