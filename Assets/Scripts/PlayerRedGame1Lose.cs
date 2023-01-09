using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRedGame1Lose : MonoBehaviour
{

    private Animator animator;
    public GameObject nivelJuego1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Vector3 position1 = nivelJuego1.transform.position;
        float x1 = position1.x;
        float y1 = position1.y;
        transform.position = new Vector2(x1, y1);

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(VolverJuego1());

    }

    public IEnumerator VolverJuego1()
    {
        yield return new WaitForSeconds(5);
        animator.SetTrigger("PlayerRedJump");
        yield return new WaitForSeconds(1);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FirstSceneJuego1");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}