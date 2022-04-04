using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    // Variables
    public int width, height;
    public float cellSize;
    private Grid grid;

    public int startValue;
    public int affectedZone;
    public int affectedValue;

    public GameObject textHolder;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(width, height, cellSize, textHolder);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Variables
            Vector3 mouseClickWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int mouseClickArrayPosition;

            mouseClickArrayPosition = grid.SetCellValue(mouseClickWorldPosition, 15);
            grid.CalculateNeighboringCells(mouseClickArrayPosition, affectedZone, affectedValue);

            // Debugs
            Debug.Log("Mouse World Position: " + mouseClickWorldPosition);
            Debug.Log("Mouse Array Position: " + mouseClickArrayPosition);
        }
    }
}
