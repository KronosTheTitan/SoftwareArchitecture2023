using BuildTools;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Manages the placement and interaction of building tiles on the game map.
/// </summary>
public class BuildingManager : MonoBehaviour
{
    /// <summary>
    /// The currently targeted hex tile.
    /// </summary>
    [FormerlySerializedAs("targetedTile")] public TowerTile targetedTowerTile;

    private BuildTool _selectedTool;

    [SerializeField] private PlaceTower placeTowerDirect;
    [SerializeField] private PlaceTower placeTowerAoe;
    [SerializeField] private PlaceTower placeTowerWeakness;

    private void Update()
    {
        GetTargetedTile();
            
        if (_selectedTool == null) // No tool currently selected
            return;

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            DeselectToolCancel();
            return;
        }

        if (!Input.GetMouseButton(0)) // No mouse input
            return;

        if (targetedTowerTile == null) // No tile targeted by mouse
            return;

        if (_selectedTool.UseTool(targetedTowerTile))
            DeselectToolSuccess();
    }

    private void GetTargetedTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        targetedTowerTile = null;

        if(!Physics.Raycast(ray, out hit))
            return;

        TowerTile target = hit.collider.gameObject.GetComponent<TowerTile>();

        if (target == null)
            return;

        targetedTowerTile = target;
    }

    private void DeselectToolCancel()
    {
        if (_selectedTool == null)
            return;

        _selectedTool.OnDeselect();
        _selectedTool = null;
    }

    private void DeselectToolSuccess()
    {
        _selectedTool.OnDeselect();
    }

    /// <summary>
    /// Selects a random tile from the potential tiles list and prepares to place it.
    /// </summary>
    public void SelectPlaceTowerDirect()
    {
        Debug.Log("Selected Direct Attack Tower");
        
        if(!placeTowerDirect.CanSelect())
            return;
        
        if (_selectedTool != null)
        {
            DeselectToolCancel();
            return;
        }
        
        _selectedTool = placeTowerDirect;
        _selectedTool.OnSelect();
    }
    public void SelectPlaceTowerAOE()
    {
        Debug.Log("Selected Direct Attack Tower");
        
        if(!placeTowerDirect.CanSelect())
            return;
        
        if (_selectedTool != null)
        {
            DeselectToolCancel();
            return;
        }
        
        _selectedTool = placeTowerAoe;
        _selectedTool.OnSelect();
    }
    public void SelectPlaceTowerWeakness()
    {
        Debug.Log("Selected Direct Attack Tower");
        
        if(!placeTowerDirect.CanSelect())
            return;
        
        if (_selectedTool != null)
        {
            DeselectToolCancel();
            return;
        }
        
        _selectedTool = placeTowerWeakness;
        _selectedTool.OnSelect();
    }
}