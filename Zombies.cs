using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombies : MonoBehaviour
{
    public float deathDistance = 0.5f;
    public float distanceAway;
    public Transform thisObject;
    public Transform target;
    private NavMeshAgent navComponent;
    public float dist;
    public int maxHealth = 2;
    public int currentHealth;
    Animator anim;

    //SoundEffects
    public AudioSource AudioSource;
    public AudioClip audioClip; //Collision effects
    public AudioClip audioClip1; //Background music
    public AudioClip audioClip2; //Faster background music

    //I wanted all the sounds to play regarding zombie position,
    //which is why they are all combines in the zombieScript
    //Perhaps it would have been more readable code if i did create
    //a sound/music manager

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        EnimiesNear();
    }
    
    
    private void EnimiesNear ()
    {
        dist = Vector3.Distance(target.position, transform.position);

        if (dist <= 30)
        {
            AudioSource.PlayOneShot(audioClip1);
            navComponent.SetDestination(target.position);

            if (dist >= 30)
            {
                AudioSource.PlayOneShot(audioClip2);
                target = null;
            }
        }

        else
        {
            if (target = null)
            {
                target = this.gameObject.GetComponent<Transform>();
            }
            else
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
    }
    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            //anim.SetBool("isDead", true);
            //Destroy(gameObject, 2.5f); //Time for animation when it'll work
            Destroy(gameObject, .5f);
            AudioSource.PlayOneShot(audioClip);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "adam")
        {
            TakeDamage(5);
        }
    }

}
