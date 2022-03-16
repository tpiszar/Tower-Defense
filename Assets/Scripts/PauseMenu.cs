using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject pause;
    public GameObject endScreen;
    public TextMeshProUGUI results;
    public GameObject volume;
    public TextMeshProUGUI wave;
    public TextMeshProUGUI mats;
    bool isPaused = false;
    bool end = true;

    public AudioSource click;

    private void Update()
    {
        if (Manager.wave <= 10)
        {
            //wave.text = "Wave: " + Manager.wave.ToString();
            //mats.text = "Materials: " + Manager.materials.ToString();
            wave.text = Manager.wave.ToString();
            mats.text = ": " + Manager.materials.ToString();
        }
        if (Input.GetButtonDown("Cancel") && end)
        {
            TogglePause();
        }
        if ((Manager.gameOver || Manager.win) && end)
        {
            Invoke("doEnd", 3);
        }
    }

    public void doEnd()
    {
        end = false;
        Time.timeScale = 0.0f;
        this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.34509803921f);
        crosshair.SetActive(false);
        endScreen.SetActive(true);
        if (Manager.win)
        {
            results.text = "Victory";
        }
        else
        {
            results.text = "Game Over";
        }
        Cursor.lockState = CursorLockMode.None;
    }

    public void TogglePause()
    {
        click.Play();
        if (isPaused)
        {
            //unpause
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            isPaused = false;
            Time.timeScale = 1.0f;
            pause.SetActive(false);
            crosshair.SetActive(true);
            volume.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            //pause
            AudioListener.volume = 0;
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.34509803921f);
            isPaused = true;
            Time.timeScale = 0.0f;
            pause.SetActive(true);
            crosshair.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Volume()
    {
        click.Play();
        pause.SetActive(false);
        volume.SetActive(true);
    }

    public void Back()
    {
        click.Play();
        pause.SetActive(true);
        volume.SetActive(false);
    }

    public void OnApplicationQuit()
    {
        click.Play();
        Application.Quit();
    }

    public void LoadLevel(string name)
    {
        Music music = GameObject.FindGameObjectWithTag("Music").GetComponent<Music>();
        music.loss.Stop();
        music.loss.volume = 0;
        music.victory.Stop();
        music.victory.volume = 0;
        music.attack.Stop();
        music.attack.volume = 0;
        music.calm.Play();
        music.calm.volume = music.calmVol;

        click.Play();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }
}
