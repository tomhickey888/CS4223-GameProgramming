using UnityEngine;

public class EndAnimation : MonoBehaviour
{

    void finalScene()
    {
        Animator anim;
        anim = FindObjectOfType<Canvas>().GetComponent<Animator>();
        anim.SetTrigger("ExitScene");
    }
}
