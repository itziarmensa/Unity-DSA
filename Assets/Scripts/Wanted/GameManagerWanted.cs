using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerWanted : MonoBehaviour
{
    [SerializeField] private FaceImageWanted FaceStartObject;
    [SerializeField] private WantedImageWanted WantedStartObject;
    [SerializeField] private OthersImageWanted OtherStartObject;

    [SerializeField] private GameObject fondo;
    [SerializeField] private GameObject SuccesBackground;
    [SerializeField] private GameObject GameOverBackGround;

    [SerializeField] private Sprite[] imagesFace;
    [SerializeField] private Sprite[] imagesWanted;


    int numOtros = 20;

    private int score = 0;
    [SerializeField] private TextMesh scoreText;

    [SerializeField] private TimerScriptWanted myTimer;

    int level;

    Vector3 fondoPosition;

    private void Start()
    {

        level = 0;

        fondoPosition = fondo.transform.position;

        gameLevel(level);

    }

    Vector3 wantedStartPosition;
    Vector3 otherStartPosition;

    WantedImageWanted wantedImage;
    FaceImageWanted faceImage;
    OthersImageWanted othersImage;

    float positionZOthers;

    public void gameLevel(int i)
    {
        int id = level;

        wantedStartPosition = WantedStartObject.transform.position;
        otherStartPosition = OtherStartObject.transform.position;

        wantedImage = WantedStartObject;
        faceImage = FaceStartObject;

        if (level > 3)
        {
            Succes();
        }

        if (id != 0)
        {
            wantedImage.ChangeSprite(id, imagesWanted[id]);
            faceImage.ChangeSprite(id, imagesFace[id]);
        }
        else
        {
            positionZOthers = otherStartPosition.z;
        }

        wantedImage.transform.position = wantedStartPosition;

        float positionX = Random.Range(-8, -1);
        float positionY = Random.Range(-4, 4);

        if (positionX == wantedImage.transform.position.x && positionY == wantedImage.transform.position.y)
        {
            positionX = Random.Range(-8, -1);
            positionY = Random.Range(-4, 4);
        }

        faceImage.transform.position = new Vector3(positionX, positionY, -2);


        Sprite[] otrosFaces = new Sprite[imagesFace.Length - 1];
        int pos = 0;

        for (int j = 0; j < imagesFace.Length; j++)
        {
            if (id != j)
            {
                otrosFaces[pos] = imagesFace[j];
                pos++;
            }
        }

        positionZOthers = positionZOthers - 2;

        for (int f = 0; f < numOtros; f++)
        {
            int idOtros = Random.Range(0, 3);

            othersImage = Instantiate(OtherStartObject) as OthersImageWanted;

            othersImage.ChangeSprite(idOtros, otrosFaces[idOtros]);

            float positionXOthers = Random.Range(-8, -1);
            float positionYOthers = Random.Range(-4, 4);


            othersImage.transform.position = new Vector3(positionXOthers, positionYOthers, positionZOthers);

        }

        if (id == 1)
        {
            OtherStartObject.transform.position = new Vector3(otherStartPosition.x, otherStartPosition.y, 100);
        }

    }

    private void Update()
    {
        if (myTimer.getTimer() == 0)
        {
            GameOver();
        }
        else if (score == 40)
        {
            Succes();
        }
    }

    int spriteIdEncontrado = 10;
    public void checkIdFaceClick(int respuesta)
    {
        this.spriteIdEncontrado = respuesta;
        foundWantedImageFace();
    }

    float fondoPositionZ;
    public void foundWantedImageFace()
    {
        if (spriteIdEncontrado == wantedImage.spriteId)
        {
            score = score + 10;
            scoreText.text = "Score:" + score;
            Final();
        }
    }

    public void Final()
    {
        if (score == 40)  // Hemos superado todos los niveles
        {
            Succes();
        }
        else if (score < 40 && myTimer.getTimer() == 0)   //Hemos perdido
        {
            GameOver();
        }
        else
        {
            numOtros = numOtros + 5;
            if (level == 0)
            {
                fondoPositionZ = fondoPosition.z - 2;
            }
            else
            {
                fondoPositionZ = fondoPositionZ - 2;
            }
            fondo.transform.position = new Vector3(fondoPosition.x, fondoPosition.y, fondoPositionZ);
            gameLevel(level++);
        }
    }

    public void Succes()
    {
        SuccesBackground.transform.position = new Vector3(0, 0, 0);
    }

    public void GameOver()
    {
        GameOverBackGround.transform.position = new Vector3(0, 0, 0);
    }
}
