using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRed2Lose : MonoBehaviour
{
    private Animator animator;
    public GameObject nivelJuego2;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Vector3 position1 = nivelJuego2.transform.position;
        float x1 = position1.x;
        float y1 = position1.y;
        float positionY1 = y1 + 0.8f;
        transform.position = new Vector2(x1, positionY1);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(VolverJuego2());
    }
    public IEnumerator VolverJuego2()
    {
        yield return new WaitForSeconds(5);
        animator.SetTrigger("PlayerRedJump");
        yield return new WaitForSeconds(1);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FirstSceneJuego2");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
