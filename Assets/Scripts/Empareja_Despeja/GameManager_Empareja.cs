using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Empareja : MonoBehaviour
{
    public static GameManager_Empareja instance = null;
    public BoardManager boardScript;

    private SpriteRenderer card1;
    private SpriteRenderer card2;
    private Vector3 position1;
    private Vector3 position2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void InitGame()
    {
        boardScript.SetupScene();
    }

    public void SelectCard(SpriteRenderer card, Vector3 mousePos)
    {
        int x = Convert.ToInt32(mousePos[0]);
        int y = Convert.ToInt32(mousePos[1]);
        if (card1 == null)
        {
            card1 = card;
            position1 = new Vector3(x, y, 0);
        }
        else if (card2 == null)
        {
            card2 = card;
            position2 = new Vector3(x, y, 0);
            if (card1.sprite == card2.sprite && boardScript.Near(position1, position2))
            {
                boardScript.BoardUpdate(position1, position2);
            }
            else
            {
                card1.color = Color.white;
                card2.color = Color.white;
            }
            card1 = null;
            card2 = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
