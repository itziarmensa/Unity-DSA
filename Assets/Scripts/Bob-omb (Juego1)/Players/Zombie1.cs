using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie1 : MonoBehaviour
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

        /*float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");*/

        int horizontalMovement = 0;      //Used to store the horizontal move direction.
        int verticalMovement = 0;        //Used to store the vertical move direction.

#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }

            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                float y = touchEnd.y - touchOrigin.y;
                touchOrigin.x = -1;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                    horizontalMovement = x > 0 ? 1 : -1;
                else
                    verticalMovement = y > 0 ? 1 : -1;
            }
            Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + movement.x * speed * Time.deltaTime * 10, minX, maxX),
                                       Mathf.Clamp(transform.position.y + movement.y * speed * Time.deltaTime * 10, minY, maxY),
                                       transform.position.z);
            
        }



#elif UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR

        //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
        horizontalMovement = (int)(Input.GetAxisRaw("Horizontal"));

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
        verticalMovement = (int)(Input.GetAxisRaw("Vertical"));

        //Check if moving horizontally, if so set vertical to zero.
        if (horizontalMovement != 0)
        {
            verticalMovement = 0;
        }
        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + movement.x * speed * Time.deltaTime, minX, maxX),
                                       Mathf.Clamp(transform.position.y + movement.y * speed * Time.deltaTime, minY, maxY),
                                       transform.position.z);


#endif


        if (horizontalMovement != 0 || verticalMovement != 0)
        {
            animator.SetTrigger("ZombieWalk");
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BolaFuego"))
        {

            collisionCount++;

            if (vidasQuedan >= 0)
            {
                vidasQuedan = vidasQuedan - 1;
            }

            vidas.text = "Vidas: " + vidasQuedan;

            if (collisionCount < deathCollisionThreshold)
            {
                animator.SetTrigger("Zombieattack");
            }

            if (collisionCount >= deathCollisionThreshold)
            {
                animator.SetTrigger("ZombieDead");
                StartCoroutine(GameManagerJuego1.instance.GameOver());
            }
        }
    }
}
