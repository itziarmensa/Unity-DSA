using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    /*public float speed = 5.0f;
    private Rigidbody2D rb;
    private Animator animator;
    private bool colision;*/

    public GameObject lineaBlanca;
    public GameObject nivelJuego1;

    public GameObject playerRed;
    bool Red = false;

    public GameObject adventureBoy;
    bool adBoy = false;

    public GameObject adventureGirl;
    bool adGirl = false;


    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();      

        Camera camera = Camera.main;

        float cameraHalfWidth = camera.orthographicSize * camera.aspect;
        float cameraHalfHeight = camera.orthographicSize;

        float x = camera.transform.position.x - cameraHalfWidth;
        float y = camera.transform.position.y;
        float positionY = y + 0.8f;

        Vector3 playerPosition = new Vector3(x, positionY, 0);

        adGirl = true;

        if(Red == true)
        {
            Instantiate(playerRed, playerPosition, Quaternion.identity);
        }

        if(adBoy == true)
        {
            Instantiate(adventureBoy, playerPosition, Quaternion.identity);
        }

        if (adGirl == true)
        {
            Instantiate(adventureGirl, playerPosition, Quaternion.identity);
        }


    }

    // Update is called once per frame
    /*void Update()
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
        


    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
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
    }*/


}
