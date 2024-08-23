using UnityEngine;
using Zenject;

public class Row : MonoBehaviour
{
    [SerializeField] private Cell _cell;

    private int _cellQuantity;
    private int _rowNumber;

    private Board _board;

    private void Start()
    {
        _board = GetComponentInParent<Board>();

        InstantiateCell();
    }

    public void GetCellNumber(int rowNumber, int cellQuantity)
    {
        _cellQuantity = cellQuantity;
        _rowNumber = rowNumber;
    }

    private void InstantiateCell()
    {
        for (int i = 0; i < _cellQuantity; i++)
        {
            Cell cell = Instantiate(_cell);
            cell.transform.SetParent(this.transform, false);
            cell.GetAddress(_rowNumber, i);

            _board.GetNewCell(cell);
        }
    }
}