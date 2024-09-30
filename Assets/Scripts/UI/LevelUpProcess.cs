using Unity.VisualScripting;
using UnityEngine.Events;

namespace UI
{
    public class LevelUpProcess
    {
        public UnityAction OnComplete;
        private LevelUpMenu _levelUpMenu;

        public LevelUpProcess(LevelUpMenu levelUpMenu)
        {
            _levelUpMenu = levelUpMenu;
            _levelUpMenu.OnPress += Complete;
        }

        public void LaunchLevelUp()
        {
            
            _levelUpMenu.Open();
            
        }

        private void Complete()
        {
            _levelUpMenu.Close();
            
            OnComplete?.Invoke();
        }
    }
}