using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRedGame3Win : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;

    private Animator animator;
    public GameObject nivelJuego3;
    private bool colision;

    public GameObject lineaBlanca;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Vector3 position1 = nivelJuego3.transform.position;
        float x1 = position1.x;
        float y1 = position1.y;
        float positionY1 = y1 + 0.8f;
        transform.position = new Vector2(x1, positionY1);

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
            //animator.ResetTrigger("PlayerRedRun");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Juego4"))
        {
            colision = true;
            /*animator.SetTrigger("PlayerRedJump");
            yield return new WaitForSeconds(1);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FirstSceneJuego4");
            while (!asyncLoad.isDone)
            {
                yield return null;
            }*/
        }
    }
}
