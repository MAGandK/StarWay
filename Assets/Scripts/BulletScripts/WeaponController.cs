using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject _shot; 
    [SerializeField] private Transform _shotSpawn; 
    [SerializeField] private float _fireRate;
    [SerializeField] private float _delay; 

    private void Start()
    {
        Debug.Log("Fire метод работает");
        InvokeRepeating("Fire", _delay, _fireRate);
    }

    private void Fire()
    {
        Instantiate(_shot, _shotSpawn.position, _shotSpawn.rotation);
    }
}
