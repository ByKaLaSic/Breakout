using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class WallSpawner : MonoBehaviour
{
    [SerializeField] private BlockSpawner _blockSpawner;
    [SerializeField] private GameObject _wallPrefab;

    private void Start()
    {
        float leftWallPositionX = _blockSpawner.StartX - _blockSpawner.XOffset;
        float rightWallPositionX = _blockSpawner.StartX + _blockSpawner.TotalWidth + _blockSpawner.XOffset;

        Instantiate(_wallPrefab, new Vector3(leftWallPositionX, 0, 0), Quaternion.identity);
        Instantiate(_wallPrefab, new Vector3(rightWallPositionX, 0, 0), Quaternion.identity);
    }
}
