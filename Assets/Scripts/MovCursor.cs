using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCursor : MonoBehaviour
{
    [SerializeField]
    private float speed = 50.0f;
    private Vector2 mousePos;
    private void Update()
    {
         mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, mousePos,
         speed * Time.fixedDeltaTime);
    }
}
