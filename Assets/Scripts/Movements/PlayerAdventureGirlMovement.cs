using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdventureGirlMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool colision;

    // Start is called before the first frame update
    void Start()
    {
        colision = false;
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!colision)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            animator.SetTrigger("AdventureGirlRun");
        }
        else
        {
            animator.ResetTrigger("AdventureGirlRun");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Juego1"))
        {
            colision = true;
            
        }
    }
}
