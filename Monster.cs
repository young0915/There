using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float monsterspeed = 6.0f;
    private void FixedUpdate()
    {
        transform.Translate(-monsterspeed * Time.deltaTime, 0, 0);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }

}
