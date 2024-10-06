using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class Ball : MonoBehaviour
{
    [SerializeField] private SceneRebooter _sceneRebooter;
    [SerializeField] private float _force;
    [SerializeField] private AudioSource _collisionSource;
    [SerializeField] private AudioClip _collisionClip;
    [SerializeField] private AudioClip _blockDestroyClip;

    private Rigidbody _rigidBody;
    private Vector3 _startPosition = new Vector3(0, 0.5f, 0);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Block block))
        {
            Destroy(block.gameObject);
            _collisionSource.PlayOneShot(_blockDestroyClip);
            _sceneRebooter.CheckReboot();
        } 
        else
        {
            _collisionSource.PlayOneShot(_collisionClip);
        }
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Run()
    {
        transform.SetParent(null);
        _rigidBody.velocity = new Vector3(1, 1, 0) * _force;
    }

    public void Reset(Transform platform)
    {
        _rigidBody.velocity = Vector3.zero;
        transform.SetParent(platform);
        transform.position = platform.position + _startPosition;
    }
}
