using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [SerializeField,Header("サウンド関連")] 
    // BGM調節用のスライダー
    private Slider bgmVolumeSetting;
    [SerializeField] 
    // SE調整用のスライダー
    private Slider seVolumeSetting;
    [SerializeField] 
    // 音量調整の実行間隔
    private float updateInterval = 0.25f;
    // 音量調整用のコルーチンを保持
    private IEnumerator SoundSettingCoroutine;
    
    // 「OptionManager」のインスタンス
    public static OptionManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            SoundSettingCoroutine = SoundVolumeUpdate();
            StartCoroutine(SoundSettingCoroutine);
        }
    }

    private IEnumerator SoundVolumeUpdate()
    {
        float count = 0.0f;
        while (true)
        {
            if (updateInterval <= count)
            {
                SoundManager.instance.BGMVolume = bgmVolumeSetting.value;
                SoundManager.instance.SEVolume = seVolumeSetting.value;
                count = 0.0f;
            }

            count += Time.deltaTime;
            yield return null;
        }
    }
}
