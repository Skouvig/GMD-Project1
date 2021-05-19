using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isPunchingHash;
    int isHitHash;
    int isDeadHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isPunchingHash = Animator.StringToHash("isPunching");
        isHitHash = Animator.StringToHash("isHit");
        isDeadHash = Animator.StringToHash("isDead");

        animator.SetBool(isWalkingHash, true);
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isPunching = animator.GetBool(isPunchingHash);
        bool isHit = animator.GetBool(isHitHash);
        bool isDead = animator.GetBool(isDeadHash);

        

        if(!isPunching && !isHit && !isDead)
            //Set is walking bool to true;
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isPunching)
            //Then set is Walking bool to false
        {
            animator.SetBool(isWalkingHash, false);
        }
        if (isDead)
            //Set all other bools to false
        {
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isHitHash, false);
            animator.SetBool(isPunchingHash, false);
        }
    }
}
