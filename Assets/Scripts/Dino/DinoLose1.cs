using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DinoLose1 : MonoBehaviour
{
    private Button jugarBoton;
    private bool playRedJump;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (SceneManager.GetActiveScene().name == "Game1Lose")
        {
            jugarBoton = GameObject.Find("Canvas/Reintentar1").GetComponent<Button>();
            jugarBoton.onClick.AddListener(OnButtonClick);
        }

        if (SceneManager.GetActiveScene().name == "Game2Lose")
        {
            jugarBoton = GameObject.Find("Canvas/Reintentar2").GetComponent<Button>();
            jugarBoton.onClick.AddListener(OnButtonClick);
        }

        if (SceneManager.GetActiveScene().name == "Game3Lose")
        {
            jugarBoton = GameObject.Find("Canvas/Reintentar3").GetComponent<Button>();
            jugarBoton.onClick.AddListener(OnButtonClick);

        }

        if (SceneManager.GetActiveScene().name == "Game4Lose")
        {
            jugarBoton = GameObject.Find("Canvas/Reintentar4").GetComponent<Button>();
            jugarBoton.onClick.AddListener(OnButtonClick);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playRedJump)
        {
            animator.SetTrigger("DinoJump");
            playRedJump = false;
        }
    }

    void OnButtonClick()
    {
        playRedJump = true;
    }
}
