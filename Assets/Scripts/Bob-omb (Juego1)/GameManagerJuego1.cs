using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerJuego1 : MonoBehaviour
{
    public float startDelay = 1;
    public static GameManagerJuego1 instance;

    private int timeToWin = 60; // tiempo en segundos que el jugador debe aguantar para ganar
    private int timeCounter = 0; // contador de tiempo

    public Text tiempo;

    private int tiempoRestante = 60;

    public GameObject playerRed;
    bool Red = false;

    public GameObject adventureBoy;
    bool adBoy = false;

    public GameObject adventureGirl;
    bool adGirl = false;

    public GameObject playerCat;
    bool Cat = false;

    public GameObject playerCuteGirl;
    bool CuteGirl = false;

    public GameObject playerDino;
    bool Dino = false;

    public GameObject playerDog;
    bool Dog = false;

    public GameObject playerJack;
    bool Jack = false;

    public GameObject playerNinjaBoy;
    bool NinjaBoy = false;

    public GameObject playerNinjaGirl;
    bool NinjaGirl = false;

    public GameObject playerRobotl;
    bool Robot = false;

    public GameObject playerSanta;
    bool Santa = false;

    public GameObject playerBoy;
    bool Boy = false;

    public GameObject playerKnight;
    bool Knight = false;

    public GameObject playerZombie;
    bool Zombie = false;

    private Vector3 playerPosition;

    private string character;

    public void receivedCharacter(string character)
    {
        this.character = character;
    }

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
        StartCoroutine(UpdateTime());

        tiempo = GameObject.Find("Canvas/TextTiempo").GetComponent<Text>();

        tiempo.text = "Tiempo: " + tiempoRestante;

        Camera camera = Camera.main;

        float cameraHalfWidth = camera.orthographicSize * camera.aspect;
        float cameraHalfHeight = camera.orthographicSize;

        float x = camera.transform.position.x;
        float y = camera.transform.position.y;

        playerPosition = new Vector3(x, y, 0);

        if (character == "Red Hat Boy")
        {
            Red = true;
        }
        if (character == "Dog")
        {
            Dog = true;
        }
        if (character == "The Robot")
        {
            Robot = true;
        }
        if (character == "Ninja Boy")
        {
            NinjaBoy = true;
        }
        if (character == "Ninja Girl")
        {
            NinjaGirl = true;
        }
        if (character == "Adventure Girl")
        {
            adGirl = true;
        }
        if (character == "Adventure Boy")
        {
            adBoy = true;
        }
        if (character == "The Boy")
        {
            Boy = true;
        }
        if (character == "Cute Girl")
        {
            CuteGirl = true;
        }
        if (character == "Dino")
        {
            Dino = true;
        }
        if (character == "Santa Claus")
        {
            Santa = true;
        }
        if (character == "The Zombie")
        {
            Zombie = true;
        }
        if (character == "Jack O'Lantern")
        {
            Jack = true;
        }
        if (character == "The Knight")
        {
            Knight = true;
        }
        if (character == "Cat")
        {
            Cat = true;
        }



        if (Red == true)
        {
            Instantiate(playerRed, playerPosition, Quaternion.identity);
        }

        if (adBoy == true)
        {
            Instantiate(adventureBoy, playerPosition, Quaternion.identity);
        }

        if (adGirl == true)
        {
            Instantiate(adventureGirl, playerPosition, Quaternion.identity);
        }

        if (Cat == true)
        {
            Instantiate(playerCat, playerPosition, Quaternion.identity);
        }

        if (CuteGirl == true)
        {
            Instantiate(playerCuteGirl, playerPosition, Quaternion.identity);
        }

        if (Dino == true)
        {
            Instantiate(playerDino, playerPosition, Quaternion.identity);
        }

        if (Dog == true)
        {
            Instantiate(playerDog, playerPosition, Quaternion.identity);
        }

        if (Jack == true)
        {
            Instantiate(playerJack, playerPosition, Quaternion.identity);
        }

        if (NinjaBoy == true)
        {
            Instantiate(playerNinjaBoy, playerPosition, Quaternion.identity);
        }

        if (NinjaGirl == true)
        {
            Instantiate(playerNinjaGirl, playerPosition, Quaternion.identity);
        }

        if (Robot == true)
        {
            Instantiate(playerRobotl, playerPosition, Quaternion.identity);
        }

        if (Santa == true)
        {
            Instantiate(playerSanta, playerPosition, Quaternion.identity);
        }

        if (Boy == true)
        {
            Instantiate(playerBoy, playerPosition, Quaternion.identity);
        }


        if (Knight == true)
        {
            Instantiate(playerKnight, playerPosition, Quaternion.identity);
        }

        if (Zombie == true)
        {
            Instantiate(playerZombie, playerPosition, Quaternion.identity);
        }
    }

    public IEnumerator UpdateTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeCounter++;
            tiempoRestante = tiempoRestante - 1;
            tiempo.text = "Tiempo: " + tiempoRestante;

            // Si el contador de tiempo ha llegado al tiempo máximo, el jugador ha ganado
            if (timeCounter >= timeToWin)
            {
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WinSceneJuego1");
                while (!asyncLoad.isDone)
                {
                    yield return null;
                }
            }
        }
    }


    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.9f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameOverSceneJuego1");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
