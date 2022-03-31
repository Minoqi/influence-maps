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

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(width, height, cellSize);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseClickWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mouseClickWorldPosition);

            grid.SetCellValue(mouseClickWorldPosition, 15);
        }
    }
}
