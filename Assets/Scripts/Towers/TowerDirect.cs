using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Towers
{
    /// <summary>
    /// this tower deals damage to a single enemy at longer distances.
    /// </summary>
    [CreateAssetMenu(fileName = "TowerDirect", menuName = "SoftwareArchitecture/Towers/TowerDirect")]
    public class TowerDirect : TowerType
    {
        [SerializeField] private int damage;
        public override bool Attack(Tower caller)
        {
            Collider[] hits = Physics.OverlapSphere(caller.transform.position, range, layerMask);
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
            
            caller.VFX.Play(caller,furthest);

            return true;
        }
    }
}