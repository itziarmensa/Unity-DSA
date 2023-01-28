using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour
{
    public int columns = 6;
    public int rows = 8;
    public GameObject[] cards;

    private TMP_Text totalCardsText;
    private TMP_Text remainingCardsText;
    private TMP_Text card1Text;
    private int remainingCards1;
    private TMP_Text card2Text;
    private int remainingCards2;
    private TMP_Text card3Text;
    private int remainingCards3;
    private TMP_Text card4Text;
    private int remainingCards4;
    private TMP_Text card5Text;
    private int remainingCards5;
    private TMP_Text card6Text;
    private int remainingCards6;
    private List<Sprite> displayedCards = new List<Sprite>();
    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();
    private List<Vector3> gridPositionsAuxiliar = new List<Vector3>();

    void InitialiseList()
    {
        gridPositions.Clear();
        gridPositionsAuxiliar.Clear();

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
                gridPositionsAuxiliar.Add(new Vector3(x, y, 0f));
            }
        }
    }

    void DisplayedCardsInit()
    {
        displayedCards.Clear();
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                displayedCards.Add(null);
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        int cardsCount = Convert.ToInt32(rows * columns);

        for (int i = 0; i < cards.Length; i++)
        {
            for (int x = 0; x < (cardsCount / cards.Length); x++)
            {
                int index = Random.Range(0, gridPositionsAuxiliar.Count);
                Vector3 randomPosition = gridPositionsAuxiliar[index];
                gridPositionsAuxiliar.RemoveAt(index);
                int indexDisplayed = gridPositions.IndexOf(randomPosition);
                displayedCards[indexDisplayed] = cards[i].GetComponent<SpriteRenderer>().sprite;
                GameObject toInstantiate = cards[i];
                GameObject instance = Instantiate(toInstantiate, randomPosition, Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
        totalCardsText = GameObject.Find("TotalCards").GetComponent<TextMeshProUGUI>();
        totalCardsText.text = "Total cards: " + cardsCount;
        remainingCardsText = GameObject.Find("RemainingCards").GetComponent<TextMeshProUGUI>();
        remainingCardsText.text = "Remaining cards: " + displayedCards.Count;
        remainingCards1 = (cardsCount / cards.Length);
        remainingCards2 = (cardsCount / cards.Length);
        remainingCards3 = (cardsCount / cards.Length);
        remainingCards4 = (cardsCount / cards.Length);
        remainingCards5 = (cardsCount / cards.Length);
        remainingCards6 = (cardsCount / cards.Length);
        card1Text = GameObject.Find("RemainingCards1").GetComponent<TextMeshProUGUI>();
        card1Text.text = "Remaining cards of type 1: " + remainingCards1;
        card2Text = GameObject.Find("RemainingCards2").GetComponent<TextMeshProUGUI>();
        card2Text.text = "Remaining cards of type 2: " + remainingCards2;
        card3Text = GameObject.Find("RemainingCards3").GetComponent<TextMeshProUGUI>();
        card3Text.text = "Remaining cards of type 3: " + remainingCards3;
        card4Text = GameObject.Find("RemainingCards4").GetComponent<TextMeshProUGUI>();
        card4Text.text = "Remaining cards of type 4: " + remainingCards4;
        card5Text = GameObject.Find("RemainingCards5").GetComponent<TextMeshProUGUI>();
        card5Text.text = "Remaining cards of type 5: " + remainingCards5;
        card6Text = GameObject.Find("RemainingCards6").GetComponent<TextMeshProUGUI>();
        card6Text.text = "Remaining cards of type 6: " + remainingCards6;
    }

    public void SetupScene()
    {
        InitialiseList();
        DisplayedCardsInit();
        BoardSetup();
    }

    public bool Near(Vector3 position1, Vector3 position2)
    {
        double distance = Math.Pow((position2[0] - position1[0]), 2) + Math.Pow((position2[1] - position1[1]), 2);
        if (distance <= 2 && distance != 0)
        {
            return true;
        }
        else
            return false;
    }

    public bool Solution()
    {
        int i = 0;
        bool found = false;
        while (i < displayedCards.Count && !found)
        {
            int k = 1;
            while (k < displayedCards.Count && !found)
            {
                if (displayedCards[i] == displayedCards[k])
                {
                    if (Near(gridPositions[i], gridPositions[k]))
                        found = true;
                }
                k++;
            }
            i++;
        }
        return found;
    }

    public void BoardUpdate(Vector3 position1, Vector3 position2)
    {
        int index1 = gridPositions.IndexOf(position1);
        int index2 = gridPositions.IndexOf(position2);
        Sprite card = displayedCards[index1];
        int k = 0;
        bool found = false;
        while (k < cards.Length && !found)
        {
            if (card == cards[k].GetComponent<SpriteRenderer>().sprite)
                found = true;
            else
                k++;
        }
        switch (k)
        {
            case 0:
                remainingCards1 = remainingCards1 - 2;
                card1Text.text = "Remaining cards of type 1: " + remainingCards1;
                break;
            case 1:
                remainingCards2 = remainingCards2 - 2;
                card2Text.text = "Remaining cards of type 2: " + remainingCards2;
                break;
            case 2:
                remainingCards3 = remainingCards3 - 2;
                card3Text.text = "Remaining cards of type 3: " + remainingCards3;
                break;
            case 3:
                remainingCards4 = remainingCards4 - 2;
                card4Text.text = "Remaining cards of type 4: " + remainingCards4;
                break;
            case 4:
                remainingCards5 = remainingCards5 - 2;
                card5Text.text = "Remaining cards of type 5: " + remainingCards5;
                break;
            case 5:
                remainingCards6 = remainingCards6 - 2;
                card6Text.text = "Remaining cards of type 6: " + remainingCards6;
                break;
        }
        if (index1 > index2)
        {
            displayedCards.RemoveAt(index1);
            displayedCards.RemoveAt(index2);
        }
        if (index1 < index2)
        {
            displayedCards.RemoveAt(index2);
            displayedCards.RemoveAt(index1);
        }
        gridPositions.RemoveAt(gridPositions.Count-1);
        gridPositions.RemoveAt(gridPositions.Count-1);
        Destroy(boardHolder.gameObject);
        boardHolder = new GameObject("Board").transform;
        for (int i = 0; i < gridPositions.Count; i++)
        {
            int x = 0;
            found = false;
            while (x < cards.Length && !found)
            {
                if (cards[x].GetComponent<SpriteRenderer>().sprite == displayedCards[i])
                {
                    GameObject toInstantiate = cards[x];
                    GameObject instance = Instantiate(toInstantiate, gridPositions[i], Quaternion.identity) as GameObject;
                    instance.transform.SetParent(boardHolder);
                    found = true;
                }
                x++;
            }
        }
        totalCardsText.text = "Total cards: " + (rows*columns);
        remainingCardsText.text = "Remaining cards: " + displayedCards.Count;
        if (displayedCards.Count == 0)
        {
            StartCoroutine(GameWon());
        }
        else if (!Solution())
        {
            StartCoroutine(GameOver());
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GameWon()
    {

        yield return new WaitForSeconds(1);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WinSceneJuego4");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }


    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.9f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameOverSceneJuego4");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
