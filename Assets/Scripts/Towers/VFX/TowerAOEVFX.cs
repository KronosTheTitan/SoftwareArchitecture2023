using Towers;

public class TowerAOE : TowerVFX
{
    public override void Play(Tower source, Enemy target)
    {
        particleSystem.Play();
    }
}
