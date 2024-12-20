using System.Collections.Generic;
using Enemies;
using UnityEngine;

namespace Towers
{
    /// <summary>
    /// this tower attacks enemies in a radius around itself.
    /// </summary>
    [CreateAssetMenu(fileName = "TowerAOE", menuName = "SoftwareArchitecture/Towers/TowerAOE")]
    public class TowerAoe : TowerType
    {
        [SerializeField] private int damage;
        public override bool Attack(Tower caller)
        {
            Collider[] hits = Physics.OverlapSphere(caller.transform.position, range, layerMask);
            
            if (hits.Length == 0)
                return false;
            
            foreach (Collider hit in hits)
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                if(enemy == null)
                    continue;
                
                if(enemy.IsDead)
                    continue;
                
                enemy.TakeDamage(damage);
            }
            
            
            
            caller.VFX.Play(caller,null);

            return true;
        }
    }
}