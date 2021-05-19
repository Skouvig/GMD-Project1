using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateStateController : MonoBehaviour
{
    //Animations
    Animator animator;
    int IsWalkingHash;
    int isRunningHash;
    int isCrouchingHash;
    int isCrawlingHash;
    int isPunchingHash;
    int isKickingHash;
    int isDanceingHash;
    int isWalkingRightHash;
    int isWalkingLeftHash;
    int isRunningRightHash;
    int isRunningLeftHash;
    int isJumpingHash;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        //For increased performance instead of calling GetKey every time
        IsWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isCrouchingHash = Animator.StringToHash("isCrouching");
        isCrawlingHash = Animator.StringToHash("isCrawling");
        isPunchingHash = Animator.StringToHash("isPunching");
        isKickingHash = Animator.StringToHash("isKicking");
        isDanceingHash = Animator.StringToHash("isDancing");
        isWalkingRightHash = Animator.StringToHash("isWalkingRight");
        isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
        isRunningRightHash = Animator.StringToHash("isRunningRight");
        isRunningLeftHash = Animator.StringToHash("isRunningLeft");
        isJumpingHash = Animator.StringToHash("isJumping");
    }
    
    // Update is called once per frame
    void Update()
    {
        bool IsWalking = animator.GetBool(IsWalkingHash);
        bool isrunning = animator.GetBool(isRunningHash);
        bool isCrouching = animator.GetBool(isCrouchingHash);
        bool isCrawling = animator.GetBool(isCrawlingHash);
        bool isPunching = animator.GetBool(isPunchingHash);
        bool isKicking = animator.GetBool(isKickingHash);
        bool isDancing = animator.GetBool(isDanceingHash);
        bool isWalkingRight = animator.GetBool(isWalkingRightHash);
        bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
        bool isRunningRight = animator.GetBool(isRunningRightHash);
        bool isRunningLeft = animator.GetBool(isRunningLeftHash);
        bool isJumping = animator.GetBool(isJumpingHash);

        bool wPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool crouchPressed = Input.GetKey(KeyCode.LeftControl);
        bool crawlingPressed = (wPressed && crouchPressed);
        bool isPunchingPressed = Input.GetKey(KeyCode.Mouse0);
        bool isKickingPressed = Input.GetKey(KeyCode.Mouse1);
        bool isDancePressed = Input.GetKey("z");
        bool isWalkingRightPressed = Input.GetKey("d");
        bool isWalkingLeftPressed = Input.GetKey("a");
        bool isRunningRightPressed = Input.GetKey("d") && runPressed;
        bool isRunningLeftPressed = Input.GetKey ("a") && runPressed;
        bool isJumpingPressed = Input.GetKey("space");

        // If W is pressed
        if(!IsWalking && wPressed)
         // then set the IsWalking boolean to true
        {
            animator.SetBool(IsWalkingHash, true);
        }

        //If w is not pressed
        if(IsWalking && !wPressed)
         //Then set IsWalking boolean to false
        {  
            animator.SetBool(IsWalkingHash, false);
        }

        //If a is pressed
        if(!isWalkingLeft && isWalkingLeftPressed)
            //Then set isWalkingLeft bool to true
        {
            animator.SetBool(isWalkingLeftHash, true);
        }
        //If a is not pressed
        if(isWalkingLeft && !isWalkingLeftPressed)
            // set isWalkingLeft bool to false
        {
            animator.SetBool(isWalkingLeftHash, false);
        }

        //If d is pressed
        if (!isWalkingRight && isWalkingRightPressed)
        //Then set isWalkingRight bool to true
        {
            animator.SetBool(isWalkingRightHash, true);
        }
        //If d is not pressed
        if (isWalkingRight && !isWalkingRightPressed)
        // set isWalkingRight bool to false
        {
            animator.SetBool(isWalkingRightHash, false);
        }


        // If player is walking and not running and presses left shift
        if (!isrunning && (wPressed && runPressed))
               // then set the runPressed boolean to be true
        {
            animator.SetBool(isRunningHash, true);
            
        }

        //If player is running and stops running or stops walking
        if (isrunning && (!wPressed || !runPressed))
            //Then set the isRunning boolean to be false
        {
            animator.SetBool(isRunningHash, false);
        }

        //If LeftControl is pressed
        if (!isCrouching && crouchPressed)
            //Then set isCrouching bool to true
        {
            animator.SetBool(isCrouchingHash, true);
        }
        //If LeftControl is not pressed
        if (isCrouching && !crouchPressed)
            //Then set isCrouching bool to false
        {
            animator.SetBool(isCrouchingHash, false);
        }
        //If player is walking and not crouched and presses isCrouching
        if(!isCrouching && (wPressed && crouchPressed))
            //Then set isCrouching bool to true
        {
            animator.SetBool(isCrouchingHash, true);
        }

        //If player is crouching and wPressed is pressed 
        if(!isCrawling && (wPressed&&crouchPressed))
            //Then set isCrawling bool to true
        {
            animator.SetBool(isCrawlingHash, true);
        }
        
        //If player is crawling and wPressed is not pressed
        if(isCrawling && !wPressed)
            //Then set isCrawling bool to false
        {
            animator.SetBool(isCrawlingHash, false);
        }

        //If player is crawling and crouchPressed is not pressed
        if (isCrawling && !isCrouching)
            //Then set isCrawling bool to false
        { 
            animator.SetBool(isCrawlingHash, false);
        }
        
        //If the player is pressing left mouse click
        if (isPunchingPressed)
            //Then set isPunchingBool to true
        {
            animator.SetBool(isPunchingHash, true);
        }
        
        //If player is walking and isPunching is pressed
        if(wPressed && isPunchingPressed)
            //Then set isPunching bool to true
        {
            animator.SetBool(isPunchingHash, true);
        }
        
        //If player punches, but releases left mouse click 
        if (!isPunchingPressed)
            //Then set isPunching bool to false
        {
            animator.SetBool(isPunchingHash, false);
        }

        //If player presses isKickingPress
        if(isKickingPressed)
            //Then set isKicking bool to true
        {
            animator.SetBool(isKickingHash, true);
        }

        //If player is kicking and isKickingPress is released
        if(!isKickingPressed)
            //Then set isKicking bool to false
        {
            animator.SetBool(isKickingHash, false);
        }

        //If isDancePressed is pressed
        if (isDancePressed)
            //Then set isDancing bool to true
        {
            animator.SetBool(isDanceingHash, true);
        }

        //If player is dancing but isDancePressed is released
        if(!isDancePressed)
            //Then set isDancing bool to false
        {
            animator.SetBool(isDanceingHash, false);
        }

        //If player is running and presses isRunningRightPressed
        if(runPressed && isRunningRightPressed)
            //Then set isRunningRight bool to true
        {
            animator.SetBool(isRunningRightHash, true);
        }
        //If player is running right and releases isRunningRightPressed
        if(!runPressed && !isRunningRightPressed)
            //Then set isRunningRightPressed bool to false
        {
            animator.SetBool(isRunningRightHash, false);
            animator.SetBool(isRunningHash, false);
        }

        //If player is running and presses isRunningLeftPressed
        if (runPressed && isRunningLeftPressed)
        //Then set isRunningLeft bool to true
        {
            animator.SetBool(isRunningLeftHash, true);
        }
        //If player is running left and releases isRunningLeftPressed
        if (!runPressed && !isRunningLeftPressed)
        //Then set isRunningLeftPressed bool to false
        {
            animator.SetBool(isRunningLeftHash, false);
            animator.SetBool(isRunningHash, false);
        }

        //If player presses isJumpingPress
        if(isJumpingPressed)
            //Then set isJumping bool to true
        {
            animator.SetBool(isJumpingHash, true);
        }

        //If player is jumping but releases isJumpingPressed
        if(!isJumpingPressed)
            //Then set isJumping bool to false
        {
            animator.SetBool(isJumpingHash, false);
        }
    }
}
