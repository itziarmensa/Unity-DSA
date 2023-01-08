using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instancia única del GameManager
    public static GameManager instance;

    [SerializeField] private List<GameObject> bombas;

    // Referencia al panel de game over
    [SerializeField] private TMPro.TextMeshProUGUI textoGameOver;

    // Referencia al texto de puntuación
    [SerializeField] private TMPro.TextMeshProUGUI textoPuntuacion;

    // Puntuación actual del jugador
    private int puntuacion;

    // Frecuencia de aparición de bombas (en segundos)
    public float frecuenciaBombas = 1f;

    // GameObject de la puerta de la bomba roja
    public GameObject puertaBombaRoja;

    // GameObject de la puerta de la bomba azul
    public GameObject puertaBombaAzul;

    // Prefab de la bomba roja
    public GameObject prefabBombaRoja;

    // Prefab de la bomba azul
    public GameObject prefabBombaAzul;

    private bool playing = false;

    private int bombasRojas;

    //Número de bombas generadas, equivalente a puntos ganados. Con 100 puntos ganas.
    private int generadas;

    public int maximoGeneradas;

    private int generadasRojas;
    private int generadasAzules;

    private void Awake()
    {
        // Establecemos la instancia única del GameManager
        instance = this;
    }

    public void Start()
    {
        
        // Iniciamos el juego generando bombas cada frecuenciaBombas segundos
        bombas.Clear();
        playing = true;
        
        InvokeRepeating("GenerarBomba", 5f, frecuenciaBombas);
        
        
        /*while (Time.deltaTime < 5f)
        {
            foreach(GameObject bomba in bombas)
            {
                bomba.SetActive(false);
            }
        }*/
        textoPuntuacion.text = "0";
    }

    // Método que genera una bomba roja o azul aleatoriamente
    private void GenerarBomba()
    {
        
        if (playing && generadas <=maximoGeneradas)
        {
            
            // Generamos un número aleatorio entre 0 y 1
            float aleatorio = Random.Range(0f, 1f);

            // Si el número aleatorio es menor que 0.5, generamos una bomba roja
            if (aleatorio < 0.5f && generadasRojas<=75)
            {
                //prefabBombaRoja.SetActive(true);
                // Creamos una bomba roja a partir del prefab
                GameObject bombaRoja = Instantiate(prefabBombaRoja, puertaBombaRoja.transform.position, Quaternion.identity);
                
                // Establecemos la etiqueta de la bomba roja
                bombaRoja.tag = "BombaRoja";
                generadas += 1;
                bombasRojas += 1;
                bombas.Add(bombaRoja);
            }
            // Si no, generamos una bomba azul
            else
            {
                // Creamos una bomba azul a partir del prefab
                GameObject bombaAzul = Instantiate(prefabBombaAzul, puertaBombaAzul.transform.position, Quaternion.identity);

                // Establecemos la etiqueta de la bomba azul
                bombaAzul.tag = "BombaAzul";
                generadas += 1;
                generadasAzules+= 1;
                bombas.Add(bombaAzul);
            }
        }
        
        /*else
        {
            
            GameOver();
        }*/
    }

    // Método que aumenta la puntuación actual
    public void AumentarPuntuacion(int amount)
    {
        if (puntuacion == 100)
        {
            Win();
        }
        else
        {
            // Aumentamos la puntuación actual
            puntuacion += amount;

            // Actualizamos el texto de puntuación
            textoPuntuacion.text = puntuacion.ToString();
        }
    }
    public int ContadorBombasRojas()
    {

        return bombasRojas;
    }

    // Método que muestra el panel de game over y detiene el juego
    public void GameOver()
    {
        // Activamos el panel de game over
        textoGameOver.text = "Game Over";
        
        // Detenemos el juego
        Time.timeScale = 0f;
        
        foreach (GameObject bomba in bombas)
        {
            Destroy(bomba);
        }
        
        StopAllCoroutines();
        playing = false;
    }
    public void Win()
    {
        textoGameOver.text = "Victory!";
        // Detenemos el juego
        Time.timeScale = 0f;
        foreach (GameObject bomba in bombas)
        {
            Destroy(bomba);
        }

        StopAllCoroutines();
        playing = false;

    }
    public int ContadorBombas()
    {
        return bombas.Count;
    }
    
}
