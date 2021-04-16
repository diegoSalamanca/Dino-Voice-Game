//Codigo Desarrollado por Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. 301 733 7051
//Bogotá Colombia.

/*  Funcionamiento
Esta clase reconoce la voz y si coincide con la palabra esperada con un key
segun una estructura de datos tipo diccionario ejecuta una acción
almacenada en el value. Utiliza un patron de diseño observador para suscribirse 
a los eventos de OnPhraseRecognized. 
 */

using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;



public class SpeechManager : MonoBehaviour
{
    

    KeywordRecognizer keywordRecognizer;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    GameManager gameManager;

    PlayerController playerController;

    

    void Start()
    {
        gameManager = GameManager.instance;

        playerController = gameManager.playerController;
       

        actions.Add("please jump", Up);
             
        actions.Add("please down", Down);
        
        actions.Add("play game", Go);

        actions.Add("try again", Go);


        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        
        keywordRecognizer.OnPhraseRecognized += WordFinded;        
        
        keywordRecognizer.Start();
    }

    

    void WordFinded(PhraseRecognizedEventArgs argumentos)
    {
        print("Palabra : " + argumentos.text);
        FindObjectOfType<Message>().ShowMessage(argumentos.text);

        actions[argumentos.text].Invoke();       
    }

    void Up()
    {
        if(gameManager.Game)        
            playerController.Jump();
    }

    void Down()
    {        
        if (gameManager.Game)
            playerController.Crouch();
    }

    void Go()
    {        
        gameManager.GameStart();
    }

}
