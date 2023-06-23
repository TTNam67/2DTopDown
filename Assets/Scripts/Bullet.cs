// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Bullet : MonoBehaviour
// {
//     [SerializeField] private AudioClip[] _fireSounds;
//     AudioSource _audioSource;
//     Player _player;
//     float _speed = 20f, _damage = 6f;
//     float _soundScale = 0.35f;
//     Vector2 _direction;
//     void Start()
//     {
//         _audioSource = GetComponent<AudioSource>();
//         if (_audioSource == null)
//             Debug.LogWarning("Bullet.cs: _audioSource is null!");

//         _player = GameObject.FindWithTag("Player").GetComponent<Player>();
//         if (_player == null)
//             Debug.LogWarning("Bullet.cs: _player is null!");
        
//         _audioSource.volume = _soundScale;
//         _audioSource.PlayOneShot(_fireSounds[0]);
//         _direction = new Vector2(_player.GetDirection().x, 0f);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         float dt = Time.deltaTime;
//         Movement(dt);

//     }

//     private void Movement(float dt)
//     {
        
//         transform.Translate(_direction * dt * _speed);
//         Vector2 disToPlayer = new Vector2(_player.transform.position.x - transform.position.x,
//                                         _player.transform.position.y - transform.position.y);
//         if (disToPlayer.x > 9.5f || disToPlayer.x < -9.5f)
//             Destroy(this.gameObject);
//     }
// }
