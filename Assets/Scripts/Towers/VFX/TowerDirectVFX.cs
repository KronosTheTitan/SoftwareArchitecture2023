using Enemies;

namespace Towers.VFX
{
    /// <summary>
    /// see TowerVFX.cs for info, this is just an implementation.
    /// </summary>
    public class TowerDirectVFX : TowerVFX
    {
        public override void Play(Tower source, Enemy target)
        {
            transform.LookAt(target.transform);
            particleSystem.Play();
        }
    }
}
