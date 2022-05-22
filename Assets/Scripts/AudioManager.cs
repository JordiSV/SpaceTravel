using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [HideInInspector]
    public static AudioManager instance;
    public AudioSource[] source;

    void Start()
    {
        instance = this;
    }

    public void playSound(int i)
    {
        source[i].Play();
    }
}
