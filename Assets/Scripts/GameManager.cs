using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 7f;
    public Text levelDialogue;
    public Player player;
    public Inventory playerInventory;
    public LevelComplete l;
    private bool textActive = true;
    private int wait = 0;
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            levelDialogue.gameObject.SetActive(true);
            levelDialogue.text = "Find the five missing objects.\nPress E to open Inventory";
            wait++;
            if (wait >= 120 || Input.GetKeyDown(KeyCode.E))
            {
                levelDialogue.text = "";
                levelDialogue.gameObject.SetActive(false);
                textActive = false; 
            }
            CompleteLevel1();
        }
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            CompleteLevel2();
        }
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            CompleteLevel3();
        }
        if (SceneManager.GetActiveScene().name == "Level 4")
        {
            CompleteLevel4();
        }
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            levelDialogue.gameObject.SetActive(true);
            levelDialogue.color = Color.red;
            levelDialogue.text = "Game Over";
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /**
     * Explore area and Pick Up items
     */
    void CompleteLevel1()
    {
        if (player.transform.position.x >= -9 && player.transform.position.x <= 1 &&
            player.transform.position.y >= 1 && player.transform.position.y <= 9 &&
            player.transform.position.z >= -5 && player.transform.position.z <= 2)
        {
            if (playerInventory.itemsPickedUp >= 5)
            {
                print("Level 1 Complete");
                levelDialogue.gameObject.SetActive(true);
                levelDialogue.text = "Level 1 Complete";
                wait = 0;
                while (wait < 120)
                {
                    wait++;
                }
                levelDialogue.gameObject.SetActive(false);
                l.LoadNextLevel();
            }
        }

    }

    /**
     * Find non toxic soil abd create an area for plants
     */
    void CompleteLevel2()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    /**
     * Pick Up the Plant and plant it there
     */
    void CompleteLevel3()
    {

    }

    /**
     * Defend the plant
     */
    void CompleteLevel4()
    {

    }
}
