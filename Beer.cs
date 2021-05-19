using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    public GameObject Bottle;

    public Vector3 center;
    public Vector3 size;


    // Start is called before the first frame update
    void Start()
    {
        SpawnBeer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            SpawnBeer();
            Debug.Log("A beer has been spawned");
        }
    }

    public void SpawnBeer()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x/2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        // Quaternions are used to represent rotations
        Instantiate(Bottle, pos, Quaternion.identity);
    }

    //Draw a cube where beers can spawn within 
    //The size and position has been set in the inspector
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(center, size);
    }
    void OnCollisionEnter(Collision col)
    {
        //If a bottle collides with adam, the bottle will be removed.
        if (col.gameObject.name == "adam")
        {
            Debug.Log("You just found a beer");
            Destroy(gameObject, .1f);
        }
        //If two bottles collides, the bottle is destroyed
        if (col.gameObject.name=="Bottle")
        {
            Destroy(gameObject);
        }
    }
}
