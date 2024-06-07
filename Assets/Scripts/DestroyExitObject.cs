using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExitObject : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        PlayerShoots.ReturnObjectToPool(gameObject);
    }
}
