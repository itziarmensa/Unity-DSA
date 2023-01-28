using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightMovement : MonoBehaviour
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

        jugarBoton = GameObject.Find("Canvas/BotonJugar1").GetComponent<Button>();
        jugarBoton.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (!colision)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetTrigger("KnightRun");
        }
        else
        {
            animator.ResetTrigger("KnightRun");
        }
        if (playRedJump)
        {
            animator.SetTrigger("KnightJump");
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
    }
}
