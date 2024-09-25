namespace Player.PlayerStats
{
    public class PlayerStatsProvider
    {
        private readonly StatsBar _statsBar;
        private readonly PlayerStatsData _playerStatsData;
        private readonly StatsSaveLoader _statsSaveLoader;

        public PlayerStatsProvider(StatsBar statsBar, PlayerStatsData playerStatsData, StatsSaveLoader statsSaveLoader)
        {
            _statsBar = statsBar;
            _playerStatsData = playerStatsData;
            _statsSaveLoader = statsSaveLoader;
        }

        public void ChangeStat()
        {
            
        }
    }
}