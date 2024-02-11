using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Towers
{
    /// <summary>
    /// applies a weakness effect to an enemy which doubles the amount of damage they take.
    /// </summary>
    [CreateAssetMenu(fileName = "TowerWeakness", menuName = "SoftwareArchitecture/Towers/TowerWeakness")]
    public class TowerWeakness : TowerType
    {
        public override bool Attack(Tower caller)
        {
            Collider[] hits = Physics.OverlapSphere(caller.transform.position, range, layerMask);
            List<Enemy> enemies = new List<Enemy>();

            foreach (Collider hit in hits)
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                if(enemy == null)
                    continue;
                
                if(enemy.IsWeaknessEffectActive)
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
            
            furthest.ApplyWeakness();
            
            caller.VFX.Play(caller,furthest);
            
            return true;
        }
    }
}
