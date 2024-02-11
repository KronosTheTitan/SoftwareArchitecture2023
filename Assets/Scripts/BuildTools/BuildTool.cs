using System;
using UnityEngine;
using UnityEngine.UI;

namespace BuildTools
{
    public abstract class BuildTool : ScriptableObject
    {
        [SerializeField] private int cost;
        public int Cost => cost;
        public abstract bool CanSelect();
        public abstract bool UseTool(TowerTile target);
    }
}