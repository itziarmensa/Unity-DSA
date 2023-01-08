using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRedJuego1 : MonoBehaviour
{
    public float speed = 5.0f;
    private Animator animator;

    public int collisionCount = 0;
    public int deathCollisionThreshold = 3;

    private Vector2 touchOrigin = -Vector2.one;

    protected void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0);

        transform.position = transform.position + movement * speed * Time.deltaTime;

        if (horizontalMovement != 0 || verticalMovement != 0)
        {
            animator.SetTrigger("PlayerRedRun");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BolaFuego"))
        {
            
            collisionCount++;

            if(collisionCount < deathCollisionThreshold)
            {
                animator.SetTrigger("PlayerRedHurt");
            }

            if (collisionCount >= deathCollisionThreshold)
            {
                animator.SetTrigger("PlayerRedDead");
                StartCoroutine(GameManagerJuego1.instance.GameOver());
            }
        }
    }
}

