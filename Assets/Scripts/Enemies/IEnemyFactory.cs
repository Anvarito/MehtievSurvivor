using UnityEngine.Events;

namespace Enemies
{
    public interface IEnemyFactory
    {
        public UnityAction<Enemy> OnEnemyDead { get; set; }
        public Enemies.Enemy GetEnemy();
    }
}