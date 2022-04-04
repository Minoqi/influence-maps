using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    // Variables
    public int width, height;
    public float cellSize;
    public Grid grid;

    public int startValue;
    public int affectedZone;
    public int affectedValue;

    public GameObject textHolder;
    public GameObject gridObject;

    public GameObject turretPrefab;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(width, height, cellSize, textHolder, gridObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Variables
            Vector3 mouseClickWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int mouseClickArrayPosition;

            mouseClickArrayPosition = grid.SetCellValue(mouseClickWorldPosition, startValue);

            if (grid.GetCellValue(mouseClickArrayPosition) != startValue)
            {
                grid.CalculateNeighboringCells(mouseClickArrayPosition, affectedZone, affectedValue);
            }

            // Debugs
            //Debug.Log("Mouse World Position: " + mouseClickWorldPosition);
            //Debug.Log("Mouse Array Position: " + mouseClickArrayPosition);
        }
    }

    public Vector2Int GetCurrentGridArrayLocation(Vector2 worldPosition)
    {
        Debug.Log("Current Grid Array Location: " + grid.GetXYPosition(worldPosition));
        return grid.GetXYPosition(worldPosition);
    }

    public int GetValueOfGridArrayLocation(Vector2Int gridLocation)
    {
        Debug.Log("Current Grid Array Location Value Function: (" + gridLocation.x + ", " + gridLocation.y + ")");
        Debug.Log("Current Grid Array Location Value: " + grid.GetCellValue(gridLocation));
        return grid.GetCellValue(gridLocation);
    }
}
