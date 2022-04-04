using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // Variables
    public GameObject gridManager;
    public GameObject bullet;

    public int attackZone;

    // Start is called before the first frame update
    void Start()
    {
        gridManager = GameObject.FindGameObjectWithTag("Grid");

        attackZone = gridManager.GetComponent<GenerateGrid>().affectedZone;
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2((attackZone * 2) + 0.5f, (attackZone * 2) + 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit something");

                if (hit.collider.gameObject == this.gameObject)
                {
                    Debug.Log("Turret was clicked");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation);
        }
    }
}
