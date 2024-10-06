using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BallReturner : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private AudioSource _lossSource;
    [SerializeField] private AudioClip _lossClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            _platform.ResetBall();
            _lossSource.PlayOneShot(_lossClip);
        }
    }
}
