using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static SoundManager;

public class badgeGetDAZE : MonoBehaviour
{
    [SerializeField, Header("�`�����l��")]
    private int _Channel;
    [SerializeField]
    public Sprite newSprite;
    [SerializeField]
    public Sprite nowSprite;
    private Image image;
    [SerializeField]
    private GameObject _GetPrefab;
    [SerializeField]
    [Tooltip("����������G�t�F�N�g(�p�[�e�B�N��)")]
    private ParticleSystem particle;
    [SerializeField]
    private GameObject _getobjprefab;
    [SerializeField]
    private GameObject _Thisobj;
    [SerializeField]
    private int Count;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        image = GetComponent<Image>();
        //image.sprite = nowSprite;
    }
    public void GetPrefab()
    {
        Count++;
        if (Count == 1)
        {
            // �摜��؂�ւ��܂�
            image.sprite = newSprite;
            SoundManager.instance.PlayAudioSorce(AudioOfType.SYSTEMSE, _Channel);
            _GetPrefab.SetActive(true);
            Invoke(nameof(EffectStart), 2.0f);
            Invoke(nameof(ImageChange), 3.0f);
            //image.sprite = nowSprite;
        }
        else if(Count > 1)
        {
            
        }
    }
    private void EffectStart()
    {
        Count = 0;
        _getobjprefab.SetActive(true);
        ParticleSystem newParticle = Instantiate(particle);
        newParticle.Play();
        Destroy(newParticle.gameObject, 5.0f);
    }
    private void ImageChange()
    {
        // �摜��؂�ւ��܂�
        image.sprite = nowSprite;
        _Thisobj.SetActive(false);
    }

}
