using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 30;
    public int currentHealth;

    //UI
    public Text healthText;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
    }

    void Update()
    {
        healthText.text = "HEALTH : " + currentHealth;
       
        if (currentHealth <= 0)
        {
            //Now the player is dead
            anim.SetBool("isDead", true);

            //Asking if player wants to restart?
            //Quit game
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            //Now the player is dead
            anim.SetBool("isDead", true);
           
            //Asking if player wants to restart?
            //Quit game
        }
    }

    void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            Debug.Log("You cant get any more health");
        }
        
            }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "mortimer")
        {
            TakeDamage(5);
            
            Debug.Log("Your current health is now: " + currentHealth);
        }
        if (col.gameObject.name == "Bottle")
        {
            Heal(5);
            Debug.Log("Oh damn! You found a beer!");
            Debug.Log("Your health is now: " + currentHealth);
        }
    }
}
