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

    private IEnumerator coroutine;

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

    //Play single clip
    public void EventPlayClip(int clip, bool isloop)
    {
        if (Eventaudio.clip == audioclips[clip])
        {
            return;
        }
        else if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = ClipLoop(clip, isloop);
        StartCoroutine(coroutine);
    }

    IEnumerator ClipLoop(int clip, bool isloop)
    {
        while (true)
        {
            Eventaudio.clip = audioclips[clip];
            Eventaudio.loop = isloop;
            Eventaudio.Play();
            yield return new WaitForSeconds(audioclips[clip].length + 10);
        }
    }

    void PlayClip(int clip, bool isloop)
    {
        Eventaudio.clip = audioclips[clip];
        Eventaudio.loop = isloop;
        Eventaudio.Play();
    }

    //Play double clip stitch
    public void PlayDelayClip(int clip,int clip2)
    {
        if (Eventaudio.clip == audioclips[clip] || Eventaudio.clip == audioclips[clip2])
        {
            return;
        }
        else if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = DelayClip(clip, clip2);
        StartCoroutine(coroutine);
    }

    IEnumerator DelayClip(int clip,int clip2)
    {
        while (true)
        {
            PlayClip(clip, false);
            yield return new WaitForSeconds(audioclips[clip].length+1);
            PlayClip(clip2, false);
            yield return new WaitForSeconds(audioclips[clip2].length + 10);
        }
    }

    //play triple clip
    public void PlayDoubleDelay(int clip, int clip2,int clip3)
    {
        if (Eventaudio.clip == audioclips[clip] || Eventaudio.clip == audioclips[clip2] || Eventaudio.clip == audioclips[clip3])
        {
            return;
        }
        else if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = DoubleDelay(clip, clip2, clip3);
        StartCoroutine(coroutine);
    }

    IEnumerator DoubleDelay(int clip, int clip2,int clip3)
    {
        PlayClip(clip, false);
        yield return new WaitForSeconds(audioclips[clip].length + 1);
        PlayClip(clip2, false);
        yield return new WaitForSeconds(audioclips[clip2].length + 1);
        PlayClip(clip3, false);
    }


    private void init()
    {
        AudioMain.instance.EventPlayClip(1, false);
        AudioMain.instance.PlayDelayClip(3, 4);
    }

}
