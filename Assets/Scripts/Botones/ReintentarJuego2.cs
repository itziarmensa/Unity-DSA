using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ReintentarJuego2 : MonoBehaviour
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
        StartCoroutine(LoadScene());
    }
}
