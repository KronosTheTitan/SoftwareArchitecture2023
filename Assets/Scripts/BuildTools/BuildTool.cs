using System;
using UnityEngine;
using UnityEngine.UI;

namespace BuildTools
{
    [Serializable]
    public abstract class BuildTool
    {
        [SerializeField] private int cost;
        public int Cost => cost;
        public abstract bool CanSelect();
        public abstract bool UseTool(TowerTile target);
        public abstract void OnDeselect();

        public abstract void OnSelect();
        public abstract void Charge(TowerTile towerTile);
    }
}