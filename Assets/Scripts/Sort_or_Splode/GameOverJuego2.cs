using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverJuego2 : MonoBehaviour
{
    public IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Game2Lose");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
