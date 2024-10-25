using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorLogic : MonoBehaviour
{
    public Animator garageAnimation;

    private void Start()
    {
        garageAnimation.Play("GarageDoorOpen",0,0.0f);
    }
}
