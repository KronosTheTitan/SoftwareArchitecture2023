using UnityEngine;

namespace Towers
{
    public abstract class Tower : MonoBehaviour
    {
        [SerializeField] private float rateOfFire = 1;
        [SerializeField] protected float range;
        private float _lastAttack = 0;
        private void Update()
        {
            if(_lastAttack+rateOfFire > Time.time) return;
            _lastAttack = Time.time;
            Attack();
        }

        protected abstract void Attack();
    }
}
