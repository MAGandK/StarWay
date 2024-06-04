using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float _speedPlayer;

   private void FixedUpdate()
   {
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");

      Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

      GetComponent<Rigidbody>().velocity = movement * _speedPlayer;
   }
}
