using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneWanted : MonoBehaviour
{
    public static FirstSceneWanted instance;

   
    
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
        SceneManager.LoadScene("WantedPrincipal");
    }
}
