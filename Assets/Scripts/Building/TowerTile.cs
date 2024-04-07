using System;
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

        [SerializeField] private GameObject canUseToolHereMarker;

        private void Start()
        {
            EventBus<OnToolSelected>.OnEvent += OnToolSelectedFunction;
            EventBus<OnToolDeselected>.OnEvent += OnToolDeselectedFunction;
        }

        public void SetTower(Tower newTower)
        {
            tower = newTower;
        }

        private void OnToolSelectedFunction(OnToolSelected onToolSelected)
        {
            canUseToolHereMarker.SetActive(onToolSelected.tool.ToolCanBeUsedOnTile(this));
        }

        private void OnToolDeselectedFunction(OnToolDeselected onToolDeselected)
        {
            canUseToolHereMarker.SetActive(false);
        }
    }
}