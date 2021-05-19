using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    GameObject canvas;
    GameObject menu;

    // Uses this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas/Background");
        menu = GameObject.Find("Canvas/MainMenu");
    }

    //Method to load the next scene in the hierachy
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Method to close the game
  public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    //Method to play intro video
    //Invoke function will set the menu and canvas(background) true after the video has finished
    public void Intro()
    {
        SetFalse();
        Invoke("SetTrue", 130.0f);
    }
    //"Removes" the main menu and background (dunno why i called it canvas)
    void SetFalse()
    {
        menu.SetActive(false);
        canvas.SetActive(false);
    }
    //Bring back the menu and background again
    void SetTrue()
    {
        menu.SetActive(true);
        canvas.SetActive(true);
    }
}
