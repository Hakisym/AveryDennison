using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMain : MonoBehaviour
{
    public static AudioMain instance;

    //[Header("Background music")]
    public AudioClip[] CNClips;
    public AudioClip[] ENClips;
    [Space(60)]

   // [Header("Event music")]
    public AudioSource Eventaudio;
    public AudioClip[] audioclips;
    

    void Awake()
    {
        instance = this;
        if (PlayerPrefs.GetInt("UseEnglish") == 1)
        {
            audioclips = ENClips;
        }else
        {
            audioclips = CNClips;
        }
    }

    public void EventPlayClip(int clip, bool isloop)
    {
        if(Eventaudio.clip == audioclips[clip])
        {
            return;
        }
        Eventaudio.clip = audioclips[clip];
        Eventaudio.loop = isloop;
        Eventaudio.Play();
    }

    public void PlayDelayClip(int clip,int clip2)
    {
        StartCoroutine(DelayClip(clip,clip2));

    }

    IEnumerator DelayClip(int clip,int clip2)
    {
        if(Eventaudio.clip == audioclips[clip]|| Eventaudio.clip == audioclips[clip2])
        {
            yield break;
        }
        EventPlayClip(clip, false);
        yield return new WaitForSeconds(audioclips[clip].length+1);
        if (Eventaudio.isPlaying)
        {
            yield break;
        }
        EventPlayClip(clip2, false);
    }


    public void PlayDoubleDelay(int clip, int clip2,int clip3)
    {
        StartCoroutine(DoubleDelay(clip, clip2,clip3));

    }

    IEnumerator DoubleDelay(int clip, int clip2,int clip3)
    {
        if (Eventaudio.clip == audioclips[clip] || Eventaudio.clip == audioclips[clip2] || Eventaudio.clip == audioclips[clip3])
        {
            yield break;
        }
        EventPlayClip(clip, false);
        yield return new WaitForSeconds(audioclips[clip].length + 1);
        if (Eventaudio.isPlaying)
        {
            yield break;
        }
        EventPlayClip(clip2, false);
        yield return new WaitForSeconds(audioclips[clip2].length + 1);
        if (Eventaudio.isPlaying)
        {
            yield break;
        }
        EventPlayClip(clip3, false);
    }


    private void init()
    {
        AudioMain.instance.EventPlayClip(1, false);
        AudioMain.instance.PlayDelayClip(3, 4);
    }

}
