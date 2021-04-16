//Codigo Desarrollado por Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. 301 733 7051
//Bogotá Colombia.

/*  Funcionamiento
Administra el puntaje
 */

using System.Collections;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{

    int scoreValue = 0;

    int highScore = 0;

    IEnumerator countScore;

    public TMPro.TextMeshProUGUI textScore, textHighScore;

    bool active;

    private void Start()
    {        
        active = false;
    }
    public void StarScore()
    {
        var countScore = CountScore();
        scoreValue = 0;
        textScore.text = scoreValue.ToString();
        active = true;
        StartCoroutine(countScore);
    }

    void ResetScore()
    {

    }

    public void StopScore()
    {
        active = false;
    }
   

    IEnumerator CountScore()
    {       

        while (active)
        {
            scoreValue += 1;
            textScore.text = scoreValue.ToString();
            yield return new WaitForSeconds(0.5f);
        }

        if (scoreValue > highScore)
        {
            highScore = scoreValue;
            textHighScore.text = "High: "+highScore.ToString();
        }
        

    }
}
