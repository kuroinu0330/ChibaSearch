using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActive : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Badge"))
        {
            other.gameObject.GetComponent<Button>().enabled = true;
            other.gameObject.GetComponent<Image>().raycastPadding = new Vector4(-50, -50, -50, -50);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Badge"))
        {
            other.gameObject.GetComponent<Button>().enabled = false;
            other.gameObject.GetComponent<Image>().raycastPadding = new Vector4(0, 0, 0, 0);
        }
    }
}
