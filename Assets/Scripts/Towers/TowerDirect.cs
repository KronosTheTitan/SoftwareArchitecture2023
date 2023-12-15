using UnityEngine;

namespace Towers
{
    public class TowerDirect : Tower
    {
        [SerializeField] private int damage;
        protected override void Attack()
        {
            Enemy target = EnemyManager.GetInstance().GetFurthestEnemyWithinRange(transform.position, range);
            if(target == null)
                return;
            
            target.TakeDamage(damage);
        }
    }
}