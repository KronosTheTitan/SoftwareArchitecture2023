using System;
using Unity.Mathematics;
using UnityEngine;

namespace Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerType towerType;
        [SerializeField] private GameObject GFX;
        [SerializeField] private TowerVFX vfx;
        private float _lastAttack = 0;

        public TowerVFX VFX => vfx;
        private void Update()
        {
            if(_lastAttack+towerType.RateOfFire > Time.time) return;
            if(towerType.Attack(this))
                _lastAttack = Time.time;
                
        }

        public bool CanUpgrade()
        {
            return (towerType.Upgrade != null);
        }

        public TowerType TowerType => towerType;

        public void SetTowerType(TowerType pTowerType)
        {
            towerType = pTowerType;

            if (GFX != null)
            {
                Destroy(GFX);
            }

            vfx = Instantiate(towerType.VFX, transform.position, quaternion.identity, transform);
            GFX = Instantiate(towerType.GFX, transform.position, quaternion.identity, transform);
        }

        private void OnDestroy()
        {
            Destroy(GFX);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, towerType.Range);
        }
    }
}
