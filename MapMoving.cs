using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMoving : MonoBehaviour
{
    public float map = 6.0f;

    private void FixedUpdate()
    {
        transform.Translate(-map * Time.deltaTime, 0, 0);
    }

}
