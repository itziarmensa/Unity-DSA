using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    /*public float speed = 5.0f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool colision;*/

    public GameObject lineaBlanca;
    public GameObject nivelJuego1;

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


    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();      

        Camera camera = Camera.main;

        float cameraHalfWidth = camera.orthographicSize * camera.aspect;
        float cameraHalfHeight = camera.orthographicSize;

        float x = camera.transform.position.x - cameraHalfWidth;
        float y = camera.transform.position.y;
        float positionY = y + 0.8f;

        Vector3 playerPosition = new Vector3(x, positionY, 0);

        Zombie = true;
        

        if(Red == true)
        {
            Instantiate(playerRed, playerPosition, Quaternion.identity);
        }

        if(adBoy == true)
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


}
