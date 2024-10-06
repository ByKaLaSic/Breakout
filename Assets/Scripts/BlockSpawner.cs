using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BlockSpawner : MonoBehaviour
{
    [SerializeField] Block _blockPrefab;
    [SerializeField] BlockColor _blockColor;
    [Range(1, 15)] [SerializeField] private int _horizontalBlocksCount;
    [Range(1, 15)] [SerializeField] private int _verticalBlocksCount;

    private float _xOffset = 1.1f;
    private float _yOffset = 0.4f;
    private float _startY = 8.6f;
    private float _startX;
    private float _totalWidth;

    public float TotalWidth => _totalWidth;
    public float StartX => _startX;
    public float XOffset => _xOffset;
    public int BlockCount => _horizontalBlocksCount * _verticalBlocksCount;

    private void Awake()
    {
        _totalWidth = (_horizontalBlocksCount - 1) * _xOffset;
        _startX = -_totalWidth / 2;

        for (int row = 0; row < _verticalBlocksCount; row++)
        {
            Color currentColor = GetRowColor(row);

            for (int col = 0; col < _horizontalBlocksCount; col++)
            {
                Vector3 position = new Vector3(_startX + col * _xOffset, _startY - row * _yOffset, 0);
                Block block = Instantiate(_blockPrefab, position, Quaternion.identity);
                block.GetComponent<Renderer>().material.color = currentColor;
            }
        }
    }

    private Color GetRowColor(int rowIndex)
    {
        int colorIndex = rowIndex % _blockColor.colors.Length;
        return _blockColor.colors[colorIndex];
    }
}
