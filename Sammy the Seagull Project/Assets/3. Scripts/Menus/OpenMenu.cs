using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;

    public void MenuOpen()
    {
        //sets the boolean in the attached animator to true to trigger open animation
        animator.SetBool("IsOpen", true);
    }
    public void MenuClose()
    {
        //sets the boolean in the animator to false to trigger close animation
        animator.SetBool("IsOpen", false);
    }
}
