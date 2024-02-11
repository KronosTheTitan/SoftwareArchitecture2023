using Towers;
using UnityEngine;

public abstract class TowerVFX : MonoBehaviour
{
    [SerializeField] protected new ParticleSystem particleSystem;
    
    public abstract void Play(Tower source, Enemy target);
}