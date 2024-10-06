using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneRebooter : MonoBehaviour
{
    [SerializeField] BlockSpawner _blockSpawner;

    private int _blocksCount;

    private void Start()
    {
        _blocksCount = _blockSpawner.BlockCount;
    }

    public void CheckReboot()
    {
        _blocksCount--;

        if (_blocksCount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
