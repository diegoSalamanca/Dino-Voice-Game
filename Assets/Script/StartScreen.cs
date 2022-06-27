//Developed By: Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. +57 3508232690
//Bogotá Colombia.

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
