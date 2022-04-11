using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipManager : MonoBehaviour
{
    // Variables
    public GameObject gridManager;

    public int attackZone;

    // Start is called before the first frame update
    void Start()
    {
        gridManager = GameObject.FindGameObjectWithTag("Grid");

        attackZone = gridManager.GetComponent<GenerateGrid>().affectedZone;
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2((attackZone * 2) + 0.5f, (attackZone * 2) + 0.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<ShipManager>().inEnemyRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<ShipManager>().inEnemyRange = false;
        }
    }
}
