//Codigo Desarrollado por Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. 301 733 7051
//Bogotá Colombia.

/*  Funcionamiento
Actualiza un texto en pantalla que muestra las coincidencias de voz del speech 
 */

using UnityEngine;

public class Message : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;    

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void ShowMessage(string text)
    {
        animator.SetTrigger("fade");
        this.text.text = text;

    }

   

     
   
}
