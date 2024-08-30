using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Row _rowPrefab;
    [SerializeField] private ColorRandomiser _colorRandomiser;
        
    private Cell[,] _cells;  

    private void Awake()
    {
        InstantiateCells();
        RegisterCells();
    }

    private void InstantiateCells()
    {
        for (int i = 0; i < _rows; i++)
        {
            Row newRow = Instantiate(_rowPrefab, transform);
            newRow.transform.SetParent(transform, false);
            newRow.GetRowNumber(i);
            newRow.InstantiateCells(_columns, _cellPrefab, _colorRandomiser);
        }
    }

    private void RegisterCells()
    {        
        Cell[] cellsChildren = GetComponentsInChildren<Cell>();
        _cells = new Cell[_columns, _rows];

        foreach (Cell cell in cellsChildren)
        {
            _cells[cell.Column, cell.Row] = cell;
        }
    }
}
