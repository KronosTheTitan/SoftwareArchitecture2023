using Towers;
using UnityEngine;

namespace BuildTools
{
    [CreateAssetMenu(fileName = "Bulldoze", menuName = "SoftwareArchitecture/Tools/Bulldoze")]
    public class Bulldoze : BuildTool
    {
        public override bool CanSelect()
        {
            return true;
        }

        public override bool UseTool(TowerTile target)
        {
            if (target.Tower == null)
                return false;
            
            Tower tower = target.Tower;
            Destroy(tower);
            target.SetTower(null);

            return true;
        }
    }
}
