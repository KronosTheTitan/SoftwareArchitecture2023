using Towers;
using UnityEngine;

public class TowerTile : MonoBehaviour
{
    [SerializeField] private Tower tower;
    public Tower Tower => tower;

    public void SetTower(Tower newTower)
    {
        tower = newTower;
    }
}