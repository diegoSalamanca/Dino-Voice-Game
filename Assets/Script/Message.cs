//Developed By: Diego Salamanca
//Email: Diegocolmayor@gmail.com
//Tel. +57 3508232690
//Bogotá Colombia.

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
