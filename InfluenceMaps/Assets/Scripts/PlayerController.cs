using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public GameObject gridManager;

    public int health;
    public Vector2Int gridArrayLocation;


    // Start is called before the first frame update
    void Start()
    {
        gridManager = GameObject.FindGameObjectWithTag("Grid");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gridArrayLocation = gridManager.GetComponent<GenerateGrid>().GetCurrentGridArrayLocation(new Vector2(this.transform.position.x, this.transform.position.y));
        }
    }
}
