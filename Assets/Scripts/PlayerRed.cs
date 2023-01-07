using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRed : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Animator animator;

    public GameObject lineaBlanca;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Camera camera = Camera.main;

        float cameraHalfWidth = camera.orthographicSize * camera.aspect;
        float cameraHalfHeight = camera.orthographicSize;

        float x = camera.transform.position.x - cameraHalfWidth;
        float y = camera.transform.position.y;
        //float positionY = y + 0.8f;

        // Asignamos la posición inicial al personaje
        transform.position = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {

        /*// Obtenemos la posición de la línea blanca en el eje y
        float yLimit = lineaBlanca.transform.position.y;

        // Restringimos el movimiento del personaje en el eje y para que no se salga de la línea blanca
        Vector2 newPosition = transform.position;
        newPosition.y = Mathf.Clamp(newPosition.y, yLimit - 0.5f, yLimit + 0.5f);
        transform.position = newPosition;

        // Mover al personaje*/
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        animator.SetTrigger("PlayerRedRun");


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Juego1"))
        {
            animator.ResetTrigger("PlayerRedRun");
            animator.SetTrigger("PlayerRedJump");
            Time.timeScale = 0f;
            StopAllCoroutines();
        }
    }


}
