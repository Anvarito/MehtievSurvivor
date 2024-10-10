namespace Infrastructure.Services
{
    public interface ISaveLoadService
    {
        public void Save<T>(T data, string path);

        public T Load<T>(string path) where T : new();
    }
}