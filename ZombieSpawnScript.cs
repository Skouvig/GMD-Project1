using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnScript : MonoBehaviour
{
    public Object zombie; // Zombie prefabs to instantiate
    public float spawninterval; // delay between spawns
    public float nextspawn; // when next spawn is due

    // Use this for initialization
    void Start()
    {
        nextspawn = Time.time + spawninterval; // set initial next spawn time
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawninterval; // set next spawn time
            SpawnZombie(); // call spawn method
        }
    }

    void SpawnZombie()
    {
        Instantiate(zombie, transform.position, transform.rotation); // create zombie
    }
}