using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerJuego1 : MonoBehaviour
{
    public float startDelay = 1;
    public static GameManagerJuego1 instance;

    public bool win;

    private int timeToWin = 60; // tiempo en segundos que el jugador debe aguantar para ganar
    private int timeCounter = 0; // contador de tiempo

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Iniciamos el contador de tiempo
        InvokeRepeating("UpdateTime", 0, 1);
    }

    void UpdateTime()
    {
        timeCounter++;

        // Si el contador de tiempo ha llegado al tiempo máximo, el jugador ha ganado
        if (timeCounter >= timeToWin)
        {
            win = true;
            Time.timeScale = 0f;
            SceneManager.LoadScene("WinScene");
        }
    }


    public IEnumerator GameOver()
    {
        win = false;
        yield return new WaitForSeconds(0.9f);
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOverScene");
    }

}
