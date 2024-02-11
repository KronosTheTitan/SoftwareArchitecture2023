using Towers;
using UnityEngine;

public class TowerDirectVFX : TowerVFX
{
    public override void Play(Tower source, Enemy target)
    {
        transform.LookAt(target.transform);
        particleSystem.Play();
    }
}
