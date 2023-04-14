using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour

{

    public GameObject GameOverPanel;
    public GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {

        GameManager.SetActive(true);
        Cursor.visible= false;
        Cursor.lockState = CursorLockMode.Locked;   
        GameOverPanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverPanel.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void gameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restart");
    }

    public void mAinMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Menu");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
