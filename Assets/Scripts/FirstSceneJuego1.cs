using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneJuego1 : MonoBehaviour
{
    
    public static FirstSceneJuego1 instance;


    private void Awake()
    {
        Debug.Log("empieza el script");
        instance = this;
    }


    private void Start()
    {
        StartCoroutine(ChangeScene());
        //SceneManager.LoadScene("PrincipalSceneJuego1");
    }

    IEnumerator ChangeScene()
    {
        Debug.Log("empieza a contar");
        yield return new WaitForSeconds(5);
        Debug.Log("cambio");
        SceneManager.LoadScene("PrincipalSceneJuego1");
    }

}
