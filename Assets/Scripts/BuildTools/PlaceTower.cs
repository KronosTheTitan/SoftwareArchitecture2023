using System;
using Towers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BuildTools
{
    [Serializable]
    public class PlaceTower : BuildTool
    {
        [SerializeField] private Tower prefab;
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
            target.SetTower(Object.Instantiate(prefab, transform.position, Quaternion.identity, transform));
            return true;
        }

        public override void OnDeselect()
        {
            
        }

        public override void OnSelect()
        {
            
        }

        public override void Charge(TowerTile towerTile)
        {
            
        }
    }
}