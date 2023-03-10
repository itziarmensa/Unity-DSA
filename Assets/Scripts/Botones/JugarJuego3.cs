using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JugarJuego3 : MonoBehaviour
{
    public Button jugar;
    //public GameObject player;
    private TextMeshProUGUI textReintentar;
    // Start is called before the first frame update
    void Start()
    {
        textReintentar = jugar.GetComponentInChildren<TextMeshProUGUI>();
        textReintentar.text = "JUGAR";
        //animator = player.GetComponent<Animator>();
        jugar.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //animator.SetTrigger("PlayerRedJump");
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FirstSceneWanted");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
