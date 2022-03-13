using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject resume;
    public GameObject quit;
    public GameObject newGame;
    public TextMeshProUGUI wave;
    public TextMeshProUGUI mats;
    bool isPaused = false;
    bool end = false;

    public AudioSource click;
    public AudioSource music;

    private void Start()
    {
        resume.SetActive(false);
        quit.SetActive(false);
        newGame.SetActive(false);
    }

    private void Update()
    {
        wave.text = "Wave: " + Manager.wave.ToString();
        mats.text = "Materials: " + Manager.materials.ToString();
        if (Input.GetButtonDown("Cancel") && !end)
        {
            //TogglePause();
        }
        if (Manager.gameOver)
        {
            end = false;
            Time.timeScale = 0.0f;
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.34509803921f);
            newGame.SetActive(true);
            quit.SetActive(true);
            music.Stop();
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void TogglePause()
    {
        click.Play();
        if (isPaused)
        {
            //unpause
            music.UnPause();
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            isPaused = false;
            Time.timeScale = 1.0f;
            resume.SetActive(false);
            quit.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            //pause
            music.Pause();
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.34509803921f);
            isPaused = true;
            Time.timeScale = 0.0f;
            resume.SetActive(true);
            quit.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void OnApplicationQuit()
    {
        click.Play();
        Application.Quit();
    }

    public void Restart(string name)
    {
        click.Play();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }
}
