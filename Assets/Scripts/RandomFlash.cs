using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFlash : MonoBehaviour
{
    float frame = 0.0f;
    [SerializeField]
    [Range(0.1f, 10f)]
    float flashTime = 0.5f;

    RawImage image = null;

    // Start is called before the first frame update
    void Start()
    {
        frame = Random.Range(0f, 1f);
        image = this.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        frame += Time.deltaTime / flashTime;
        if (frame > 1f) frame -= 1f;

        Color c = image.color;

        c.a = Mathf.Cos(frame * 2f * Mathf.PI) * 0.5f + 0.5f;

        image.color = c;
    }

    public void SetActiveThis()
    {
        this.gameObject.SetActive(false);
    }
}
