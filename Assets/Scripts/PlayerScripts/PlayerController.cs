using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
   public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float _speedPlayer;
   [SerializeField] private float _bank;

   [SerializeField] private Boundary _boundary;

   private Rigidbody _rbPlayer;

   private void Start()
   {
      _rbPlayer = GetComponent<Rigidbody>();
   }

   private void FixedUpdate()
   {
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");

      Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

      _rbPlayer.velocity = movement * _speedPlayer;

     _rbPlayer.position = new Vector3
      (
         Math.Clamp(_rbPlayer.position.x, _boundary.xMin, _boundary.xMax),
         0.0f,
         Math.Clamp(_rbPlayer.position.z, _boundary.zMin, _boundary.zMax)
      );
     
      _rbPlayer.rotation = Quaternion.Euler( 0,0, _rbPlayer.velocity.x * -_bank);
   }
}
