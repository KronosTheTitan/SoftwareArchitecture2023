using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public class TowerAoe : Tower
    {
        [SerializeField] private int damage;
        protected override bool Attack()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, range, layerMask);
            
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

            return true;
        }
    }
}