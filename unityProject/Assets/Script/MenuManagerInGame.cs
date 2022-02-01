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
        //Uyun zamanýný durdurma
        Time.timeScale = 0;
        inGameScreen.SetActive(false);//oyun ekraný kapatýr
        pauseScreen.SetActive(true);// PauseScreen ekranýný açar

    }

    public void PlayButton()
    {
        //Uyun zamanýný baþlatýr
        Time.timeScale = 1;
        pauseScreen.SetActive(false);// PauseScreen ekranýný kapar
        inGameScreen.SetActive(true);//oyun ekraný açar
    }

    public void RePlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);//oyun ekraný gelir
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(0);//menu ekraný gelir
    }
}
