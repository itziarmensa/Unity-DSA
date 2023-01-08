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
    public bool game1;

    private int timeToWin = 60; // tiempo en segundos que el jugador debe aguantar para ganar
    private int timeCounter = 0; // contador de tiempo

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Iniciamos el contador de tiempo
        InvokeRepeating("UpdateTime", 0, 1);
        game1 = true;
    }

    public IEnumerator UpdateTime()
    {
        timeCounter++;
        game1 = true;

        // Si el contador de tiempo ha llegado al tiempo máximo, el jugador ha ganado
        if (timeCounter >= timeToWin)
        {
            game1 = false;
            win = true;
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WinSceneJuego1");
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }


    public IEnumerator GameOver()
    {
        game1 = true;
        Debug.Log("He puest game1 = " + game1);
        win = false;
        yield return new WaitForSeconds(0.9f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameOverSceneJuego1");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
