using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class JugarJuego1 : MonoBehaviour
{

    public Button jugar;
    private TextMeshProUGUI textReintentar;
    // Start is called before the first frame update
    void Start()
    {
        textReintentar = jugar.GetComponentInChildren<TextMeshProUGUI>();
        textReintentar.text = "JUGAR";
        jugar.onClick.AddListener(TaskOnClick);
        
    }

    void TaskOnClick()
    {
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
