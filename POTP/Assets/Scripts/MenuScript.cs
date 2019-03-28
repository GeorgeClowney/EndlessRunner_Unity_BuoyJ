using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//JacobBuoy 2019
//This is the script that controls all the menus in the game
public class MenuScript : MonoBehaviour
{
    PlayerRun playerRef;
    public static bool GameHasStarted = false;
    public static bool GameIsPaused = false;
    public Slider VolBar;
	public Slider VolBar2;
    public GameObject pauseMenuUI; // this is the var connected to the pause menu itself
    public GameObject deathScreenUI; // this is the var connected to the pause menu itself
    public GameObject mainMenuUI;
    public float myVolume;
    AudioSource song1;
    public Text fSCORE;
    // Start is called before the first frame update
    void Start()
    {
        song1 = GetComponent<AudioSource>();
        playerRef = GameObject.Find("Player").GetComponent<PlayerRun>();
    }
    // Update is called once per frame
    void Update()
    {
        fSCORE.text = "Final SCORE:" + playerRef.score;
		if (playerRef.gameHasStarted == false) {
			myVolume = VolBar.value;
		} else {
			myVolume = VolBar2.value;
		}
        //Makes the volume of the Audio match the Slider value
        song1.volume = myVolume;
        if (playerRef.isDead)
        {
            Debug.Log("Player is dead.");
            DeathScreen();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    // Pause Menu
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerRef.gameIsPaused = false;
    }
    void Pause()
    {
        playerRef.gameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // can set slow motion if wanted
        GameIsPaused = true;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
    public void RestartGame()
    {
        GameObject player = GameObject.Find("Player");
        player.transform.position.Set(0, .5f, 0);
        playerRef.Reset();
        Application.LoadLevel(Application.loadedLevel);  //This works once the game is running
    }
    // death screen
    public void DeathScreen()
    {
        deathScreenUI.SetActive(true);
    }
    // death screen
    public void StartGame()
    {
        playerRef.gameIsPaused = false;
        playerRef.gameHasStarted = true;
        mainMenuUI.SetActive(false);
		VolBar2.value = VolBar.value;
    }
}