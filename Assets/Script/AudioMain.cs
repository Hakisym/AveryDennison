using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMain : MonoBehaviour
{
    public static AudioMain instance;

    //[Header("Background music")]
    public AudioSource Bgmusic;
    public AudioClip[] BGaudioclips;
    [Space(60)]

   // [Header("Event music")]
    public AudioSource Eventaudio;
    public AudioClip[] audioclips;
    

    void Start()
    {
        instance = this;


    }
    public void EventPlayClip(int clip, bool isloop)
    {
        Eventaudio.clip = audioclips[clip];
        Eventaudio.loop = isloop;
        Eventaudio.Play();
        
        
    }

    public void BgPlayClip(int clip, bool isloop)
    {
        Bgmusic.clip = BGaudioclips[clip];
        Bgmusic.loop = isloop;
        Bgmusic.Play();


    }





}
