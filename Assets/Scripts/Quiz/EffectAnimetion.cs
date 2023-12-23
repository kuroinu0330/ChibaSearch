using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnimetion : MonoBehaviour
{
    [SerializeField]
    [Tooltip("����������G�t�F�N�g(�p�[�e�B�N��)")]
    private ParticleSystem particle;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        // �p�[�e�B�N���V�X�e���̃C���X�^���X�𐶐�����B
        //ParticleSystem newParticle = Instantiate(particle);
        if (Input.GetKeyDown(KeyCode.K))
        {
            ParticleSystem newParticle = Instantiate(particle);
            newParticle.Play();
            Destroy(newParticle.gameObject, 5.0f);
        }
    }
}
