using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneJuego1 : MonoBehaviour
{
    
    public static FirstSceneJuego1 instance;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("PrincipalSceneJuego1");
    }

}
