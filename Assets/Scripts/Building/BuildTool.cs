using UnityEngine;

namespace Building
{
    /// <summary>
    /// the abstract class that contains the generalized functionality and data of a build tool.
    /// </summary>
    public abstract class BuildTool : ScriptableObject
    {
        [SerializeField] private int cost;
        public int Cost => cost;
        public abstract bool CanSelect();
        public abstract bool ToolCanBeUsedOnTile(TowerTile tile);
        public abstract bool UseTool(TowerTile target);
    }
}