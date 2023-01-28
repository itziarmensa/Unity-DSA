using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugarJuego1 : MonoBehaviour
{

    public Button jugar;
    public GameObject player;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        jugar.GetComponentInChildren<Text>().text = "JUGAR";
        animator = player.GetComponent<Animator>();
        jugar.onClick.AddListener(TaskOnClick);
        
    }

    void TaskOnClick()
    {
        animator.SetTrigger("PlayerRedJump");
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FirstSceneJuego1");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
