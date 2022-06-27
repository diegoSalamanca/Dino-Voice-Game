//Developed By: Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. +57 3508232690
//Bogotá Colombia.

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
        startScreen.ShowScreen("Dino Voice", "Say \"Play Game\" - Di \"Jugar\"");
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
            startScreen.ShowScreen("You Lose", "Say \"Try Again\" - Di \"Volver a Jugar\"");
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
