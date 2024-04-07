using System;
using Building;
using UnityEngine;
using UnityEngine.UI;

public class BuildToolBar : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private BuildingManager buildingManager;

    private void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = buildingManager.GetToolSelectCriteria(i);
        }
    }
}
