using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReintentarJuego4 : MonoBehaviour
{
    public Button reintentar;
    public GameObject player;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        reintentar.GetComponentInChildren<Text>().text = "REINTENTAR";
        animator = player.GetComponent<Animator>();
        reintentar.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        animator.SetTrigger("PlayerRedJump");
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FirstSceneJuego4");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
