using Towers.VFX;
using UnityEngine;

namespace Towers
{
    /// <summary>
    /// the abstract of a tower type, its just a list of functions and variables that every tower type needs.
    /// </summary>
    public abstract class TowerType : ScriptableObject
    {
        [SerializeField] protected LayerMask layerMask;
        [SerializeField] protected float rateOfFire = 1;
        [SerializeField] protected float range;
        [SerializeField] protected TowerType upgrade;
        [SerializeField] private GameObject gfx;
        [SerializeField] private TowerVFX vfx;

        public float RateOfFire => rateOfFire;
        public float Range => range;
        public TowerType Upgrade => upgrade;
        public GameObject GFX => gfx;
        public TowerVFX VFX => vfx;
    
        public abstract bool Attack(Tower caller);
    }
}
