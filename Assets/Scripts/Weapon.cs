using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    AudioSource _audioSource;
    GameObject _bulletContainer;
    [SerializeField] GameObject _bulletPrefab;
    Player _player;
    float _playerDirection;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("Weapon.cs: AudioSource is not found");

        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (_player == null)
            Debug.LogWarning("Weapon.cs: _player is null!");

        _bulletContainer = GameObject.Find("BulletContainer");
        if (_bulletContainer == null)
            Debug.LogWarning("Weapon.cs: _bulletContainer is null!");

        _audioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerDirection = _player.GetDirection().x;

        if (Input.GetKeyDown(KeyCode.O))
        {
            Vector2 posi = new Vector2(0.661f*_playerDirection + transform.position.x, 0.093f + transform.position.y);
            
            GameObject tmp = Instantiate(_bulletPrefab, posi, Quaternion.identity);
            tmp.transform.parent = _bulletContainer.transform;
        }
    }
}
