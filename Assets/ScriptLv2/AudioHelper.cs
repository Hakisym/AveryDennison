using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    public static AudioHelper instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    #region AudioInstance
    public void PlayEventClip(int clip)
    {
        AudioMain.instance.EventPlayClip(clip, false);
    }

    public void PlayDoubleClip(int clip)
    {
        AudioMain.instance.PlayDelayClip(clip, clip + 1);
    }
    #endregion
}
