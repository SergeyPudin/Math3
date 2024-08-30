using UnityEngine;

public class Row : MonoBehaviour
{
    private int _rowNumber;
    public void InstantiateCells(int columns, Cell cell, ColorRandomiser colorRandomiser)
    {
        for (int i = 0; i < columns; i++)
        {
            Cell newCell = Instantiate(colorRandomiser.GetRandomCell(), transform);
            newCell.transform.SetParent(transform, false);
            newCell.GetAddress(i, _rowNumber);                
        }
    }

    public void GetRowNumber(int row)
    {
        _rowNumber = row;
    }
}