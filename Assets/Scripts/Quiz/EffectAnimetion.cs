using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnimetion : MonoBehaviour
{
    [SerializeField]
    [Tooltip("発生させるエフェクト(パーティクル)")]
    private ParticleSystem particle;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        // パーティクルシステムのインスタンスを生成する。
        //ParticleSystem newParticle = Instantiate(particle);
        if (Input.GetKeyDown(KeyCode.K))
        {
            ParticleSystem newParticle = Instantiate(particle);
            newParticle.Play();
            Destroy(newParticle.gameObject, 5.0f);
        }
    }
}
