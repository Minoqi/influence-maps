using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    // Variables
    private int width, height;
    private float cellSize;
    private int[,] gridArray;
    private int defaultValue = 0;

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

                gridArray[x, y] = defaultValue;
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

    public void SetCellValue(int x, int y, int value)
    {
        gridArray[x, y] = value;
    }

    public void SetCellValue(Vector2 worldPosition, int value)
    {
        Vector2 cellPosition;
        cellPosition = GetXYPosition(worldPosition);
        SetCellValue((int)cellPosition.x, (int)cellPosition.y, value);
        Debug.Log("X: " + (int)cellPosition.x + " // Y: " + (int)cellPosition.y + " // Value: " + gridArray[(int)cellPosition.x, (int)cellPosition.y]);
    }

    public void CalculateNeighboringCells(int pX, int pY, int affectedZone, int affectedValue)
    {
        bool doneLooping = false;
        int totalAffectZone = (int)Mathf.Pow(affectedZone, 2);
        int minusX = affectedZone;
        int minusY = affectedZone;
        Vector2 startLocation = new Vector2(pX - minusX, pY - minusY);
        int xMark = 0;
        int yMark = 0;

        while (!doneLooping)
        {
            int multipleAffect = 0;

            for (int i = 0; i < (affectedZone * 2) + 1; i++)
            {
                
            }

            multipleAffect += pX - minusX;
            multipleAffect += pY - minusY;

            gridArray[(int)startLocation.x, (int)startLocation.y] = affectedValue * multipleAffect;
            Debug.Log("Location (" + startLocation.x + ", " + startLocation.y + ") value is " + gridArray[(int)startLocation.x, (int)startLocation.y]);
        }
    }
}
