using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 5.0f;
    //public Button jugarBoton;
    private Rigidbody2D rb;
    private Animator animator;
    private bool colision;
    private bool playRedJump;

    // Start is called before the first frame update
    void Start()
    {
        colision = false;
        animator = GetComponent<Animator>();

        //jugarBoton = GameObject.Find("Canvas/BotonJugar1").GetComponent<Button>();
        //jugarBoton.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (!colision)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetTrigger("ZombieWalk");
        }
        else
        {
            animator.ResetTrigger("ZombieWalk");
        }
        if (playRedJump)
        {
            //animator.SetTrigger("ZombieJump");
            playRedJump = false;
        }
    }

    void OnButtonClick()
    {
        playRedJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Juego1"))
        {
            colision = true;
        }
        if (collision.gameObject.CompareTag("Juego2"))
        {
            colision = true;
        }
        if (collision.gameObject.CompareTag("Juego3"))
        {
            colision = true;
        }
        if (collision.gameObject.CompareTag("Juego4"))
        {
            colision = true;
        }
        if (collision.gameObject.CompareTag("Juego5"))
        {
            colision = true;
        }
        
    }
}
