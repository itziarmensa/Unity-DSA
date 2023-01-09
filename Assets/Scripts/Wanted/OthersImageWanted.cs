using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OthersImageWanted : MonoBehaviour
{
    // SerializeField allow us to see this value in the inespector
    [SerializeField] private GameObject FaceLuigi;
    [SerializeField] private GameManagerWanted gameManager;

    public void OnMouseDown()
    {

    }

    private int _spriteId;

    public int spriteId
    {
        get { return _spriteId; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void cancelView()
    {
        FaceLuigi.SetActive(false);
    }
}
