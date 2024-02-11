using Managers;
using UnityEngine;

namespace Building
{
    /// <summary>
    /// upgrades an existing tower to a higher level if possible, this level is determined by the towertype scriptable object.
    /// </summary>
    [CreateAssetMenu(fileName = "Upgrade", menuName = "SoftwareArchitecture/Tools/Upgrade")]
    public class Upgrade : BuildTool
    {
        public override bool CanSelect()
        {
            if (GameManager.GetInstance().Money < Cost)
                return false;

            return true;
        }

        public override bool UseTool(TowerTile target)
        {
            if (target.Tower == null)
                return false;
        
            if (!target.Tower.CanUpgrade())
                return false;
        
            target.Tower.SetTowerType(target.Tower.TowerType.Upgrade);
        
            return true;
        }
    }
}