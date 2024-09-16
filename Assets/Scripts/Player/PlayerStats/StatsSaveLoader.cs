
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

    public void SaveStats(PlayerStatsData playerStatsData)
    {
        _saveLoadService.Save(playerStatsData, _saveFilePath);
    }

    public PlayerStatsData LoadStats()
    {
        PlayerStatsData data = _saveLoadService.Load<PlayerStatsData>(_saveFilePath);
        return data;
    }
}