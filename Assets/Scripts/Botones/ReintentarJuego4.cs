using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ReintentarJuego4 : MonoBehaviour
{
    public Button reintentar;
    private TextMeshProUGUI textReintentar;
    // Start is called before the first frame update
    void Start()
    {
        textReintentar = reintentar.GetComponentInChildren<TextMeshProUGUI>();
        textReintentar.text = "REINTENTAR";
        reintentar.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
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
