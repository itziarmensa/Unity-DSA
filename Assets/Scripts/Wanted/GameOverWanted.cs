using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWanted : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Game3Lose");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
