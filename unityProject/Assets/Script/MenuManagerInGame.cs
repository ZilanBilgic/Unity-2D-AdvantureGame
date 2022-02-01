using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButton()
    {
        //Uyun zaman�n� durdurma
        Time.timeScale = 0;
        inGameScreen.SetActive(false);//oyun ekran� kapat�r
        pauseScreen.SetActive(true);// PauseScreen ekran�n� a�ar

    }

    public void PlayButton()
    {
        //Uyun zaman�n� ba�lat�r
        Time.timeScale = 1;
        pauseScreen.SetActive(false);// PauseScreen ekran�n� kapar
        inGameScreen.SetActive(true);//oyun ekran� a�ar
    }

    public void RePlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);//oyun ekran� gelir
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(0);//menu ekran� gelir
    }
}
