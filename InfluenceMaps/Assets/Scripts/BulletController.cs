using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Variables
    public GameObject player;
    public GameObject gridManager;

    public float speed;
    public int damage;
    public Vector3 targetLocation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gridManager = GameObject.FindGameObjectWithTag("Grid");

        targetLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, targetLocation, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            int cellValue = gridManager.gameObject.GetComponent<GenerateGrid>().GetValueOfGridArrayLocation(collision.gameObject.GetComponent<PlayerController>().gridArrayLocation);
            Debug.Log("Cell Value: " + cellValue.ToString());

            collision.gameObject.GetComponent<PlayerController>().health -= (damage + cellValue);
            Debug.Log("Calculated Damage: " + (damage + cellValue).ToString());

            Destroy(this.gameObject);
        }
        else if(collision.collider.CompareTag("Bullet") || collision.collider.CompareTag("Turret"))
        {
            Destroy(this.gameObject);
        }
    }
}
