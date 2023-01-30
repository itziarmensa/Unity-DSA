using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderJuego : MonoBehaviour
{
    public GameObject gameManager;

    void Awake()
    {
        if (GameManager1.instance == null)

            Instantiate(gameManager);

    }
}
