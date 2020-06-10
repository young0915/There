using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public float map = 6.0f;
    private void FixedUpdate()
    {
        transform.Translate(-map * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            Destroy(gameObject);
        }
    }
}
