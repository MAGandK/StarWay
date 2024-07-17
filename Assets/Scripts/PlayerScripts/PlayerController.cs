using System;
using UnityEngine;

[System.Serializable]
public class Boundary
{
   public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
   public static PlayerController Instanse;
   
   [SerializeField] private float _speedPlayer;
   [SerializeField] private float _bankPlayer;
   [SerializeField] private int _healthPlayer;
   
   [SerializeField] private Boundary _boundary;

   private Rigidbody _rbPlayer;
   
   private Vector2 _moveInput;

   public Vector2 MoveInput
   {
      get => _moveInput;
      set => _moveInput = value;
   }
   
   public delegate void TakeDamage();
   public static TakeDamage OnTakeDamage;
   public delegate void DiedPlayer();
   public static DiedPlayer OnDiedPlayer;
   
   private void Awake()
   {
      if (Instanse == null)
      {
         Instanse = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }
   private void Start()
   {
      _rbPlayer = GetComponent<Rigidbody>();
   }

   private void FixedUpdate()
   {
      // float moveHorizontal = Input.GetAxis("Horizontal");
      // float moveVertical = Input.GetAxis("Vertical");

      //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
      Vector3 movement = new Vector3(_moveInput.x, 0.0f, _moveInput.y);

      _rbPlayer.velocity = movement * _speedPlayer;

     _rbPlayer.position = new Vector3
      (
         Math.Clamp(_rbPlayer.position.x, _boundary.xMin, _boundary.xMax),
         0.0f,
         Math.Clamp(_rbPlayer.position.z, _boundary.zMin, _boundary.zMax)
      );
     
      _rbPlayer.rotation = Quaternion.Euler( 0,0, _rbPlayer.velocity.x * -_bankPlayer);
   }

   public void TakedDamage()
   {
      if (_healthPlayer > 0)
      {
         _healthPlayer--;
         OnTakeDamage?.Invoke();
      }
      else if (_healthPlayer <= 0)
      {
         DiePlayer();
      }
   }
   
   private void DiePlayer()
   {
      OnDiedPlayer?.Invoke();
      gameObject.SetActive(false);
   }
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Asteroid" || other.tag == "BulletEnemy")
      {
         TakedDamage();
         Destroy(other.gameObject); 
      }

      if (other.tag == "Enemy" )
      {
         DiePlayer();
      }
   }
}
