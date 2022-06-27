//Developed By: Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. +57 3508232690
//Bogotá Colombia.

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
       

        actions.Add("jump", Up);
        actions.Add("saltar", Up);  
        actions.Add("arriba", Up);             
        actions.Add("down", Down);
        actions.Add("agacharse", Down); 
        actions.Add("abajo", Down); 
        actions.Add("play game", Go);
        actions.Add("jugar", Go);
        actions.Add("try again", Go);
        actions.Add("volver a jugar", Go);


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
