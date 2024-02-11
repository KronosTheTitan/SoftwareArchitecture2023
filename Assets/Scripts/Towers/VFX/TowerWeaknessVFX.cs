using Towers;

public class TowerWeaknessVFX : TowerVFX
{
    public override void Play(Tower source, Enemy target)
    {
        transform.LookAt(target.transform);
        particleSystem.Play();
    }
}
