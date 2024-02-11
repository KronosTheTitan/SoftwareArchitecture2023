using System;
using Towers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BuildTools
{
    [CreateAssetMenu(fileName = "new PlaceTower", menuName = "SoftwareArchitecture/Tools/PlaceTower")]
    public class PlaceTower : BuildTool
    {
        [SerializeField] private Tower prefab;
        [SerializeField] private TowerType towerType;
        public override bool CanSelect()
        {
            if (GameManager.GetInstance().Money < Cost)
                return false;

            return true;
        }

        public override bool UseTool(TowerTile target)
        {
            if (target.Tower != null)
                return false;

            Transform transform = target.transform;
            target.SetTower(Instantiate(prefab, transform.position, Quaternion.identity, transform));
            target.Tower.SetTowerType(towerType);
            return true;
        }
    }
}