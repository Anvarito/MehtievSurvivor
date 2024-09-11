using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class StatsSaveLoader
{
    private readonly SaveLoadService _saveLoadService;
    private string _saveFilePath;

    public StatsSaveLoader(SaveLoadService saveLoadService)
    {
        _saveLoadService = saveLoadService;

        string saveDirectoryPath = Path.Combine(Application.persistentDataPath, "Save");

        if (!Directory.Exists(saveDirectoryPath))
            Directory.CreateDirectory(saveDirectoryPath);

        _saveFilePath = Path.Combine(saveDirectoryPath, "Stats.json");
    }

    public async Task SaveStats(PlayerStatsData playerStatsData)
    {
        await _saveLoadService.Save(playerStatsData, _saveFilePath);
    }

    public async Task<PlayerStatsData> LoadStats()
    {
        PlayerStatsData data = await _saveLoadService.Load<PlayerStatsData>(_saveFilePath);
        return data;
    }
}