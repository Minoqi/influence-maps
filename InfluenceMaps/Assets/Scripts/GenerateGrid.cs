using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    // Variables
    public int width, height;
    public float cellSize;

    // Start is called before the first frame update
    void Start()
    {
        Grid grid = new Grid(width, height, cellSize);
    }
}
