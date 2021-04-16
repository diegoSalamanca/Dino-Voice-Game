//Codigo Desarrollado por Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. 301 733 7051
//Bogotá Colombia.

/*  Funcionamiento
Clase que administra el flujo del juego y permite un punto de acceso 
mediante el patrón de diseño Singleton. 
 */

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ProceduralTerrain proceduralTerrain;

    public PlayerController playerController;

    public SpeechManager speechManager;

    public SoundManager soundManager;

    public ScoreManager scoreManager;

    public StartScreen startScreen;
   

    bool game;

    public bool Game { get { return game; } set { game = value; } }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);   
        }
        else
        {
            Destroy(this);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        game = false;
        startScreen.ShowScreen("Dino Voice", " Say \"Play Game\"");
    }

    public void GameStart()
    {
        if (!game)
        {
            soundManager.PlaySound(1);
            playerController.StartGame();
            scoreManager.StarScore();
            game = true;
            proceduralTerrain.RestarGround();
            startScreen.HideScreen();
        }        
    }
    

    public void EndGame()
    {
        if (game)
        {
            scoreManager.StopScore();
            soundManager.StopAllSound();
            soundManager.PlayShoot(2);
            game = false;
            startScreen.ShowScreen("You Lose", "Say \"Try Again\"");
        }
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameStart();
        }
    }
}
