using BuildTools;
using UnityEngine;

/// <summary>
/// Manages the placement and interaction of building tiles on the game map.
/// </summary>
public class BuildingManager : MonoBehaviour
{
    /// <summary>
    /// The currently targeted hex tile.
    /// </summary>
    public Tile targetedTile;

    private BuildTool _selectedTool;

    [SerializeField] private PlaceTowerDirect placeTowerDirect;

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

        if (targetedTile == null) // No tile targeted by mouse
            return;

        if (_selectedTool.UseTool(targetedTile))
            DeselectToolSuccess();
    }

    private void GetTargetedTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        targetedTile = null;

        if(!Physics.Raycast(ray, out hit))
            return;

        Tile target = hit.collider.gameObject.GetComponent<Tile>();

        if (target == null)
            return;

        targetedTile = target;
    }

    private void DeselectToolCancel()
    {
        if (_selectedTool == null)
            return;

        _selectedTool.OnDeselect();
        _selectedTool.ToggleOff();
        _selectedTool = null;
    }

    private void DeselectToolSuccess()
    {
        _selectedTool.Charge(targetedTile);
        _selectedTool.OnDeselect();
    }

    /// <summary>
    /// Selects a random tile from the potential tiles list and prepares to place it.
    /// </summary>
    public void SelectPlaceTowerDirect(bool toolSelect)
    {
        if (!toolSelect)
        {
            DeselectToolCancel();
            return;
        }

        _selectedTool = placeTowerDirect;
    }
}