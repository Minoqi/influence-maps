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

    public Transform enemyShipPrefab;
    public Transform shipPrefab;
    public bool shipDown;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(width, height, cellSize, textHolder, gridObject);
        shipDown = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Variables
            Vector3 mouseClickWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int mouseClickArrayPosition; 

            mouseClickArrayPosition = grid.SetCellValue(mouseClickWorldPosition, startValue);

            grid.CalculateNeighboringCells(mouseClickArrayPosition, affectedZone, affectedValue);

            // Place Enemy Ship
            mouseClickArrayPosition = grid.GetXYPosition(mouseClickWorldPosition);
            Instantiate(enemyShipPrefab, grid.GetWorldPosition(mouseClickArrayPosition.x, mouseClickArrayPosition.y), Quaternion.identity);
        }
        else if (Input.GetMouseButtonDown(1) && !shipDown)
        {
            // Variables
            Vector3 mouseClickWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int mouseClickArrayPosition;

            // Place Ship
            mouseClickArrayPosition = grid.GetXYPosition(mouseClickWorldPosition);
            Instantiate(shipPrefab, grid.GetWorldPosition(mouseClickArrayPosition.x, mouseClickArrayPosition.y), Quaternion.identity);
            shipDown = true;
        }
    }
}
