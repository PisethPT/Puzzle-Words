using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music : MonoBehaviour
{
    public AudioSource[] sources;
    public Sprite[] sprites;
    public Image image;
    public Animator animator;
    bool isMusic = true,  isSetting = true;

    public void setting()
    {
        isSetting = !isSetting;
        if(isSetting )
        {
            animator.Play("off");
        }else if(!isSetting )
        {
            animator.Play("on");
        }
    }

    public void music_on()
    {
        isMusic = !isMusic;
        if(isMusic)
        {
            sources[0].Play();
            image.sprite = sprites[1];
            sources[0].mute = true;
            animator.Play("off");
            isSetting = true;
        }
        else if(!isMusic)
        {
            image.sprite = sprites[0];
            sources[0].mute = false;
            animator.Play("off");
            isSetting = true;
        }
    }    
    public void win()
    {
        sources[1].Play();
    }
}
