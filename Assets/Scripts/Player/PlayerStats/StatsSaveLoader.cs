
using Infrastructure;
using Infrastructure.Services;

public class StatsSaveLoader
{
    private readonly SaveLoadService _saveLoadService;
    private readonly string _saveFilePath = "Save/Stats.json";

    public StatsSaveLoader(SaveLoadService saveLoadService)
    {
        _saveLoadService = saveLoadService;
    }

    public void SaveStats(PlayerConfig playerConfig)
    {
        _saveLoadService.Save(playerConfig, _saveFilePath);
    }

    public PlayerConfig LoadStats()
    {
        PlayerConfig data = _saveLoadService.Load<PlayerConfig>(_saveFilePath);
        return data;
    }
}