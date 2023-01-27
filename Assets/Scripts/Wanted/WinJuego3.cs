using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinJuego3 : MonoBehaviour
{
    public IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Game3Win");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
