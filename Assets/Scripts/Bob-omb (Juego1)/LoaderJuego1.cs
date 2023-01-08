using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderJuego1 : MonoBehaviour
{
    public GameObject gameManager;

    void Awake()
    {
        if (GameManagerJuego1.instance == null)

            Instantiate(gameManager);

    }
}
