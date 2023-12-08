using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trumau : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.changeHealth(-1);
        }
    }
}
