using System;
using UnityEngine;

namespace Towers
{
    public abstract class Tower : MonoBehaviour
    {
        [SerializeField] protected float rateOfFire = 1;
        [SerializeField] protected float range;
        [SerializeField] protected LayerMask layerMask;
        private float _lastAttack = 0;
        private void Update()
        {
            if(_lastAttack+rateOfFire > Time.time) return;
            if(Attack())
                _lastAttack = Time.time;
                
        }

        protected abstract bool Attack();

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
