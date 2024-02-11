using Enemies;

namespace Towers.VFX
{
    /// <summary>
    /// see TowerVFX.cs for info, this is just an implementation.
    /// </summary>
    public class TowerAOE : TowerVFX
    {
        public override void Play(Tower source, Enemy target)
        {
            particleSystem.Play();
        }
    }
}
