using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    public GameObject[] screens;
    public GameObject main;

    public AudioSource click;

    public void LoadLevel(string name)
    {
        click.Play();
        SceneManager.LoadScene(name);
    }

    public void Main()
    {
        click.Play();
        foreach (GameObject i in screens)
        {
            i.SetActive(false);
        }
        main.SetActive(true);
    }

    public void Swap(int screen)
    {
        click.Play();
        main.SetActive(false);
        screens[screen].SetActive(true);
    }

    public void OnApplicationQuit()
    {
        click.Play();
        Application.Quit();
    }
}
