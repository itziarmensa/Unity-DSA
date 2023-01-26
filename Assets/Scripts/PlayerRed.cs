using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRed : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool colision;

    public GameObject lineaBlanca;
    public GameObject nivelJuego1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();      

        Camera camera = Camera.main;

        float cameraHalfWidth = camera.orthographicSize * camera.aspect;
        float cameraHalfHeight = camera.orthographicSize;

        float x = camera.transform.position.x - cameraHalfWidth;
        float y = camera.transform.position.y;
        float positionY = y + 0.8f;

        // Asignamos la posición inicial al personaje
        transform.position = new Vector2(x, positionY);



        colision = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!colision)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            animator.SetTrigger("PlayerRedRun");
        }
        else
        {
            animator.ResetTrigger("PlayerRedRun");
        }
        


    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Juego1"))
        {
            colision = true;
            animator.SetTrigger("PlayerRedJump");
            yield return new WaitForSeconds(1);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FirstSceneJuego1");
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }


}
