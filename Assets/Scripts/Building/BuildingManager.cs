using Managers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Building
{
    /// <summary>
    /// Manages the placement and interaction of building tiles on the game map. Determines the targeted tile and then runs the code of the potential selected tool.
    /// </summary>
    public class BuildingManager : MonoBehaviour
    {
        /// <summary>
        /// The currently targeted hex tile.
        /// </summary>
        [FormerlySerializedAs("targetedTile")] public TowerTile targetedTowerTile;

        private BuildTool _selectedTool;

        [SerializeField] private BuildTool[] tools;

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

            _selectedTool = null;
            EventBus<OnToolDeselected>.Publish(new OnToolDeselected());
        }

        private void DeselectToolSuccess()
        {
            if (_selectedTool == null)
                return;
        
            GameManager.GetInstance().SpendMoney(_selectedTool.Cost);
        
            _selectedTool = null;
            EventBus<OnToolDeselected>.Publish(new OnToolDeselected());
        }

        /// <summary>
        /// Selects a random tile from the potential tiles list and prepares to place it.
        /// </summary>
        public void SelectTool(int tool)
        {
            if(!tools[tool].CanSelect())
                return;
        
            if (_selectedTool != null)
            {
                DeselectToolCancel();
            }
        
            _selectedTool = tools[tool];
            EventBus<OnToolSelected>.Publish(new OnToolSelected(_selectedTool));
        }

        public bool GetToolSelectCriteria(int tool)
        {
            return tools[tool].CanSelect();
        }
    }
}