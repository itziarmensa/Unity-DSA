using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRedJuego1 : MonoBehaviour
{
    public float speed = 5.0f;
    private Animator animator;

    public int collisionCount = 0;
    public int deathCollisionThreshold = 3;

    private Vector2 touchOrigin = -Vector2.one;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Text vidas;

    public int vidasQuedan = 3;

    protected void Start()
    {
        animator = GetComponent<Animator>();

        Camera camera = Camera.main;
        float cameraHalfWidth = camera.orthographicSize * camera.aspect;
        float cameraHalfHeight = camera.orthographicSize;
        minX = camera.transform.position.x - cameraHalfWidth;
        maxX = camera.transform.position.x + cameraHalfWidth;
        minY = camera.transform.position.y - cameraHalfHeight;
        maxY = camera.transform.position.y + cameraHalfHeight;

        vidas = GameObject.Find("Canvas/TextVidas").GetComponent<Text>();

        vidas.text = "Vidas: " + vidasQuedan;


    }

    // Update is called once per frame
    void Update()
    {


        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x + movement.x * speed * Time.deltaTime, minX, maxX),
                                        Mathf.Clamp(transform.position.y + movement.y * speed * Time.deltaTime, minY, maxY),
                                        transform.position.z);

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

            if(vidasQuedan >= 0)
            {
                vidasQuedan = vidasQuedan - 1;
            }
            
            vidas.text = "Vidas: " + vidasQuedan;

            if (collisionCount < deathCollisionThreshold)
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

