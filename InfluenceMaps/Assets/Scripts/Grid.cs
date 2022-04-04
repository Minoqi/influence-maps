using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid
{
    // Variables
    private int width, height;
    private float cellSize;
    private int[,] gridArray;
    private int defaultValue = 0;

    private TextMesh[,] debugTextArray;

    // Constructor
    public Grid(int pWidth, int pHeight, float pCellSize, GameObject textHolder, GameObject gridObject)
    {
        // Store variables
        width = pWidth;
        height = pHeight;
        gridArray = new int[width, height];
        cellSize = pCellSize;

        debugTextArray = new TextMesh[width, height];

        // Debug
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Debug.DrawLine(GetWorldPosition((int)gridObject.transform.position.x + x, (int)gridObject.transform.position.y + y), GetWorldPosition((int)gridObject.transform.position.x + x, (int)gridObject.transform.position.y + y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition((int)gridObject.transform.position.x + x, (int)gridObject.transform.position.y + y), GetWorldPosition((int)gridObject.transform.position.x + x + 1, (int)gridObject.transform.position.y + y), Color.white, 100f);

                gridArray[x, y] = defaultValue;

                debugTextArray[x,y] = CreateWorldText(gridArray[x,y].ToString(), GetWorldPosition((int)gridObject.transform.position.x + x, (int)gridObject.transform.position.y + y) + (new Vector3(cellSize, cellSize) * 0.5f), 5, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center, textHolder.transform);
            }
        }
        Debug.DrawLine(GetWorldPosition((int)gridObject.transform.position.x, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, (int)gridObject.transform.position.y), GetWorldPosition(width, height), Color.white, 100f);
    }

    public static TextMesh CreateWorldText(string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, Transform parent = null)
    {
        GameObject textObject = new GameObject("World_Text", typeof(TextMesh));
        
        Transform transform = textObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;

        TextMesh textMesh = textObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        
        return textMesh;
    }

    public int GetCellValue(Vector2Int gridLocation)
    {
        Debug.Log("GetCellValue: " + gridArray[gridLocation.x, gridLocation.y]);
        return gridArray[gridLocation.x, gridLocation.y];
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    public Vector2Int GetXYPosition(Vector3 pWorldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt(pWorldPosition.x / cellSize), Mathf.FloorToInt(pWorldPosition.y / cellSize));
    }

    public void SetCellValue(int x, int y, int value)
    {
        gridArray[x, y] = value;
        //Debug.Log("Array Position (" + x + ", " + y + ") value = " + value);
    }

    public Vector2Int SetCellValue(Vector2 worldPosition, int value)
    {
        Vector2Int cellPosition;
        cellPosition = GetXYPosition(worldPosition);
        SetCellValue((int)cellPosition.x, (int)cellPosition.y, value);
        
        return cellPosition;
    }

    public void CalculateNeighboringCells(Vector2Int centerCell, int affectedZone, int affectedValue)
    {
        // Variables
        Vector2Int currentLoc = new Vector2Int(0, 0);

        // Calculate neighbors
        for (currentLoc.x = centerCell.x - affectedZone; currentLoc.x < centerCell.x + affectedZone + 1; currentLoc.x++)
        {
            //Debug.Log("New X is " + currentLoc.x);

            for (currentLoc.y = centerCell.y - affectedZone; currentLoc.y < centerCell.y + affectedZone + 1; currentLoc.y++)
            {
                //Debug.Log("New Y is " + currentLoc.y);

                if (currentLoc.x < 0 || currentLoc.x >= gridArray.GetLength(0) || currentLoc.y < 0 || currentLoc.y >= gridArray.GetLength(1)) // Out of bounds
                {
                    //Debug.Log("Skip: Either out of bounds OR at center cell");
                }
                else if(currentLoc == centerCell) // Center cell selected
                {
                    gridArray[currentLoc.x, currentLoc.y] = gridArray[centerCell.x, centerCell.y];
                    debugTextArray[currentLoc.x, currentLoc.y].text = gridArray[currentLoc.x, currentLoc.y].ToString();
                }
                else // Adjust values
                {
                    if (gridArray[currentLoc.x, currentLoc.y] != 0)
                    {
                        gridArray[currentLoc.x, currentLoc.y] = gridArray[currentLoc.x, currentLoc.y] - (affectedValue * Mathf.FloorToInt((currentLoc - centerCell).magnitude));
                    }
                    else
                    {
                        gridArray[currentLoc.x, currentLoc.y] = gridArray[centerCell.x, centerCell.y] - (affectedValue * Mathf.FloorToInt((currentLoc - centerCell).magnitude));
                    }
                    //Debug.Log("Array Position (" + currentLoc.x + ", " + currentLoc.y + ") value = " + gridArray[currentLoc.x, currentLoc.y]);
                    debugTextArray[currentLoc.x, currentLoc.y].text = gridArray[currentLoc.x, currentLoc.y].ToString();
                }
            }
        }
    }
}
