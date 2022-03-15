using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    public GameObject[] screens;
    public GameObject main;

    private void Start()
    {
        Main();
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Main()
    {
        foreach (GameObject i in screens)
        {
            i.SetActive(false);
        }
        main.SetActive(true);
    }

    public void Swap(int screen)
    {
        main.SetActive(false);
        screens[screen].SetActive(true);
    }

    public void OnApplicationQuit()
    {
        //click.Play();
        Application.Quit();
    }
}
