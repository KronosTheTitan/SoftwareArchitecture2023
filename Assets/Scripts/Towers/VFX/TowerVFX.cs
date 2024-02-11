using Enemies;
using UnityEngine;

namespace Towers.VFX
{
    /// <summary>
    /// Handles the various vfx effects of a tower.
    /// </summary>
    public abstract class TowerVFX : MonoBehaviour
    {
        [SerializeField] protected new ParticleSystem particleSystem;
    
        public abstract void Play(Tower source, Enemy target);
    }
}