using Towers;
using UnityEngine;

namespace Building
{
    /// <summary>
    /// A tile on which a tower can be placed, no tile can contain more than 1 tower.
    /// </summary>
    public class TowerTile : MonoBehaviour
    {
        [SerializeField] private Tower tower;
        public Tower Tower => tower;

        public void SetTower(Tower newTower)
        {
            tower = newTower;
        }
    }
}