using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    // Variables
    private int width, height;
    private float cellSize;
    private int[,] gridArray;

    // Constructor
    public Grid(int pWidth, int pHeight, float pCellSize)
    {
        // Store variables
        width = pWidth;
        height = pHeight;
        gridArray = new int[width, height];
        cellSize = pCellSize;

        // Debug
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                Debug.Log("X: " + x + " // Y: " + y);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        Debug.Log("Grid Size: " + width + ", " + height);

        //new Vector3(cellSize, cellSize) * 0.5
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    private Vector2Int GetXYPosition(Vector3 pWorldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt(pWorldPosition.x / cellSize), Mathf.FloorToInt(pWorldPosition.y / cellSize));
    }

    private void GetCellValue(int x, int y, int value)
    {
        gridArray[x, y] = value;
    }
}
