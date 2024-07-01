using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;

    [SerializeField] private Cell _prefab;
    [SerializeField] private Cell[,] _tiles;

    private void Start()
    {
        _tiles = new Cell[_width, _height];

        SetUp();
    }

    private void SetUp()
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                Vector2 position = new Vector2(i, j);

                Cell newCell = Instantiate(_prefab, transform);
                newCell.transform.parent = this.transform;
                newCell.name = new($"Cell {i}, {j}");

                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = position * rectTransform.sizeDelta;
                _tiles[i, j] = newCell;
            }
        }
    }
}