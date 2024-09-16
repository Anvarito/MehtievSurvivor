using TIM;

namespace Infrastructure.Services
{
    public class SaveLoadService
    {
        public SaveLoadService()
        {
            SaveSystem.LoadAll();
        }

        public void Save<T>(T data, string name)
        {
            SaveSystem.SaveFile(data, name);
        }

        public T Load<T>(string name) where T : new()
        {
            if (SaveSystem.CheckFile_Disk(name))
            {
                return SaveSystem.LoadFile<T>(name);;
            }
            return new T();
        }
    }
}