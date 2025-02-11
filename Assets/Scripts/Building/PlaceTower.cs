﻿using Managers;
using Towers;
using UnityEngine;

namespace Building
{
    /// <summary>
    /// used in the placing of towers.
    /// </summary>
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

        public override bool ToolCanBeUsedOnTile(TowerTile tile)
        {
            return tile.Tower == null;
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