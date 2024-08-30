using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Cell : MonoBehaviour
{
    private int _column;
    private int _row;

    public int Column => _column;
    public int Row => _row;
   
    public void GetAddress(int column, int row)
    {
        _column = column;
        _row = row;
    }
}