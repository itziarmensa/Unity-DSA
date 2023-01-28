using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRedGame4Lose : MonoBehaviour
{
    private Animator animator;
    public GameObject nivelJuego4;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Vector3 position1 = nivelJuego4.transform.position;
        float x1 = position1.x;
        float y1 = position1.y;
        float positionY1 = y1 + 0.8f;
        transform.position = new Vector2(x1, positionY1);

    }

    // Update is called once per frame
    /*void Update()
    {
        StartCoroutine(VolverJuego4());

    }

    public IEnumerator VolverJuego4()
    {
        yield return new WaitForSeconds(5);
        animator.SetTrigger("PlayerRedJump");
        yield return new WaitForSeconds(1);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SceneEmpareja");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }*/
}
