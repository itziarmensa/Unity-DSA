using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ReintentarJuego2 : MonoBehaviour
{
    public Button reintentar;
    public GameObject player;
    private Animator animator;
    private TextMeshProUGUI textReintentar;
    // Start is called before the first frame update
    void Start()
    {
        textReintentar = reintentar.GetComponentInChildren<TextMeshProUGUI>();
        textReintentar.text = "REINTENTAR";
        animator = player.GetComponent<Animator>();
        reintentar.onClick.AddListener(TaskOnClick);
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FirstSceneJuego2");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    void TaskOnClick()
    {
        animator.SetTrigger("PlayerRedJump");
        StartCoroutine(LoadScene());
    }
}
