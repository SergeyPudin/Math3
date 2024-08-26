using UnityEngine;
using UnityEngine.UI;

public class CellsHandler : MonoBehaviour
{
    private Cell[,] _cells;
    private Cell _activeCell;

    private int _cellsNumber;
    private int _rowNumber;
    private int _count = 1;

    private void Start()
    {
        Board board = GetComponent<Board>();
        _cellsNumber = board.ColumnNumber;
        _rowNumber = board.RowsNumber;
    }

    public void GetCells(Cell[,] cells)
    {
        _cells = cells;
        _activeCell = null;
    }

    public void OnClicked(Cell cell)
    {
        if (_activeCell == null)
        {
            _activeCell = cell;
        }
        else
        {
            ChangePlace(cell);
            _activeCell = null;
        }
    }

    private void ChangePlace(Cell cell)
    {
        Sprite temporarySprite = _activeCell.GetComponent<Image>().sprite;
        _activeCell.GetComponent<Image>().sprite = cell.GetComponent<Image>().sprite;
        cell.GetComponent<Image>().sprite = temporarySprite;

        CheckForSameColorNeibors(cell);

        _count = 1;
    }

    private int CheckForSameColorNeibors(Cell cell)
    {
        cell.IsVisited = true;

        int x = cell.CellNumber;
        int y = cell.RowNumber;

        Sprite currentSprite = cell.GetComponent<Image>().sprite;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;

                int newX = x + i;
                int newY = y + j;

                if (newX >= 0 && newX < _cellsNumber && newY >= 0 && newY < _rowNumber)
                {
                    if (_cells[newX, newY].GetComponent<Image>().sprite == currentSprite && !_cells[newX, newY].IsVisited)
                    {
                        _count += CheckForSameColorNeibors(_cells[newX, newY]);
                    }
                }
            }
        }

        if (_count >= 3)
        {
            Debug.Log(_count);
        }

        return _count;
    }
}