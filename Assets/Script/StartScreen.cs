//Codigo Desarrollado por Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. 301 733 7051
//Bogotá Colombia.

/*  Funcionamiento
Permite mostrar la pantalla de inicio con las instrucciones del juego
 */

using UnityEngine;
public class StartScreen : MonoBehaviour
{
    CanvasGroup canvasGroup;

    public TMPro.TextMeshProUGUI title;

    public TMPro.TextMeshProUGUI lastText;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }    

    public void ShowScreen(string textTitle, string textPlay)
    {
        title.text = textTitle;
        lastText.text = textPlay;
        canvasGroup.alpha = 1;
    }

    public void HideScreen()
    {
        canvasGroup.alpha = 0;
    }
}
