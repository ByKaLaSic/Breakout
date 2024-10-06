using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(BlockColor), menuName = "ScriptableObjects/BlockColors")]
public sealed class BlockColor : ScriptableObject
{
    [SerializeField] public Color[] colors;
}
