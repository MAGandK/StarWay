using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidMove : MonoBehaviour
{
   [SerializeField] private float _speedMix;
   [SerializeField] private float _speedMax;

   private int _speed;

   private void Start()
   {
      _speed = (int)Random.Range(_speedMix, _speedMax);
      GetComponent<Rigidbody>().velocity = transform.forward * -_speed;
   }
}
