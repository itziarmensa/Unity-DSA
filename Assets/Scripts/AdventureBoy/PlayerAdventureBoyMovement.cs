using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerAdventureBoyMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Button jugarBoton;
    private Rigidbody2D rb;
    private Animator animator;
    private bool colision;
    private bool playRedJump;

    // Start is called before the first frame update
    void Start()
    {
        colision = false;
        animator = GetComponent<Animator>();

        if (SceneManager.GetActiveScene().name == "PrincipalScene")
        {
            jugarBoton = GameObject.Find("Canvas/BotonJugar1").GetComponent<Button>();
            jugarBoton.onClick.AddListener(OnButtonClick);
        }

        if (SceneManager.GetActiveScene().name == "Game1Win")
        {
            jugarBoton = GameObject.Find("Canvas/BotonJugar2").GetComponent<Button>();
            jugarBoton.onClick.AddListener(OnButtonClick);
        }

        if (SceneManager.GetActiveScene().name == "Game2Win")
        {
            jugarBoton = GameObject.Find("Canvas/BotonJugar3").GetComponent<Button>();
            jugarBoton.onClick.AddListener(OnButtonClick);

        }

        if (SceneManager.GetActiveScene().name == "Game3Win")
        {
            jugarBoton = GameObject.Find("Canvas/BotonJugar4").GetComponent<Button>();
            jugarBoton.onClick.AddListener(OnButtonClick);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!colision)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetTrigger("AdventureBoyRun");
        }
        else
        {
            animator.ResetTrigger("AdventureBoyRun");
        }
        if (playRedJump)
        {
            animator.SetTrigger("AdventureBoyJump");
            playRedJump = false;
        }
    }

    void OnButtonClick()
    {
        playRedJump = true;
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {

        if (SceneManager.GetActiveScene().name == "PrincipalScene" || SceneManager.GetActiveScene().name == "Game1Lose" || SceneManager.GetActiveScene().name == "Game2Lose"
            || SceneManager.GetActiveScene().name == "Game3Lose" || SceneManager.GetActiveScene().name == "Game4Lose")
        {
            if (collision.gameObject.CompareTag("Juego1") || collision.gameObject.CompareTag("Juego2") || collision.gameObject.CompareTag("Juego3") || collision.gameObject.CompareTag("Juego4")
                || collision.gameObject.CompareTag("Juego5"))
            {
                colision = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "Game1Win")
        {
            if (collision.gameObject.CompareTag("Juego2") || collision.gameObject.CompareTag("Juego3") || collision.gameObject.CompareTag("Juego4") || collision.gameObject.CompareTag("Juego5"))
            {
                colision = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "Game2Win")
        {
            if (collision.gameObject.CompareTag("Juego21") || collision.gameObject.CompareTag("Juego3") || collision.gameObject.CompareTag("Juego4") || collision.gameObject.CompareTag("Juego5"))
            {
                colision = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "Game3Win")
        {
            if (collision.gameObject.CompareTag("Juego1") || collision.gameObject.CompareTag("Juego2") || collision.gameObject.CompareTag("Juego4") || collision.gameObject.CompareTag("Juego5"))
            {
                colision = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "Game4Win")
        {
            if (collision.gameObject.CompareTag("Juego1") || collision.gameObject.CompareTag("Juego2") || collision.gameObject.CompareTag("Juego3") || collision.gameObject.CompareTag("Juego5"))
            {
                colision = true;
                animator.SetTrigger("AdventureBoyJump");
                yield return new WaitForSeconds(1);
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("EscenaFinalMapa");
                while (!asyncLoad.isDone)
                {
                    yield return null;
                }
                StopAllCoroutines();
            }
        }

    }
}
