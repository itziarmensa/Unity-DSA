using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManager_Empareja;

    void Awake()
    {
        if (GameManager_Empareja.instance == null)
            Instantiate(gameManager_Empareja);
    }
}
