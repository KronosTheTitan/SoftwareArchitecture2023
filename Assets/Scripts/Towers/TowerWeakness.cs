namespace Towers
{
    public class TowerWeakness : Tower
    {
        protected override void Attack()
        {
            Enemy target = EnemyManager.GetInstance().GetFurthestEnemyWithinRange(transform.position, range);
            if(target == null)
                return;
            
            target.ApplyWeakness();
        }
    }
}
