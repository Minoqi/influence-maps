using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    // Variables
    public GameObject gridManager;

    public Vector2Int gridArrayPosition;
    public Vector2Int lastArrayPosition;

    public int health, speed;
    public Vector2 move;

    public bool inEnemyRange;

    // Start is called before the first frame update
    void Start()
    {
        gridManager = GameObject.FindGameObjectWithTag("Grid");
        inEnemyRange = false;

        gridArrayPosition = gridManager.GetComponent<GenerateGrid>().grid.GetXYPosition(this.gameObject.transform.position);
        lastArrayPosition = gridArrayPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (inEnemyRange)
        {
            // Update Position on Array
            gridArrayPosition = gridManager.GetComponent<GenerateGrid>().grid.GetXYPosition(this.gameObject.transform.position);

            // Update Health
            if (lastArrayPosition != gridArrayPosition)
            {
                lastArrayPosition = gridArrayPosition;
                health -= gridManager.GetComponent<GenerateGrid>().grid.GetCellValue(lastArrayPosition);

                Debug.Log("Ship Took Damage: " + gridManager.GetComponent<GenerateGrid>().grid.GetCellValue(lastArrayPosition));

                if (health <= 0)
                {
                    Debug.Log("Ship Destroyed");
                    gridManager.GetComponent<GenerateGrid>().shipDown = false;
                    Destroy(this.gameObject);
                }
            }
        }

        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        move = new Vector2(moveHorizontal * speed, moveVertical * speed);

        transform.Translate(move * Time.deltaTime);
    }
}
