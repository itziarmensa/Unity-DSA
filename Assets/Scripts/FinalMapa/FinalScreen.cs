using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreen : MonoBehaviour
{
    public static FinalScreen instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
        StopAllCoroutines();
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(5);
        //SceneManager.LoadScene("PrincipalSceneJuego1");
    }
}
