using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class TowerDirect : Tower
    {
        [SerializeField] private int damage;
        protected override bool Attack()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, range, layerMask);
            List<Enemy> enemies = new List<Enemy>();
            
            foreach (Collider hit in hits)
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                if(enemy == null)
                    continue;
                
                if(enemy.IsDead)
                    continue;
                
                enemies.Add(enemy);
            }
            
            if(enemies.Count == 0)
                return false;

            Enemy furthest = null;
            float progress = float.NegativeInfinity;

            foreach (Enemy enemy in enemies)
            {
                if (enemy.Position > progress)
                {
                    furthest = enemy;
                    progress = enemy.Position;
                }
            }
            
            if(furthest == null)
                return false;
            
            furthest.TakeDamage(damage);

            return true;
        }
    }
}