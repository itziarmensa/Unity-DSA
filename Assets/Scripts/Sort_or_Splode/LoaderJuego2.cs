using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderJuego2 : MonoBehaviour
{
    public GameObject gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        if (GameManagerJuego1.instance == null)

            Instantiate(gameManager);

    }
}
