using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class batchSE : MonoBehaviour
{
    public int SECount = 0;
    public int SELimit = 1;
    public int Value;
    void Update()
    {
        for (int i = 1; i < 50; ++i)
        {
            if (SECount == i)
            {
                SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, 5);
                SECount = 0;
            }
        }

    }
}
