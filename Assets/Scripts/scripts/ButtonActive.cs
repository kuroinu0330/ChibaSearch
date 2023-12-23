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
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Badge"))
        {
            other.gameObject.GetComponent<Button>().enabled = false;
        }
    }
}
