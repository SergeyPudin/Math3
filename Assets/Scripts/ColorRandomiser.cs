using UnityEngine;

public class ColorRandomiser : MonoBehaviour
{
    [SerializeField] private Cell[] _cells;
    [SerializeField] private Cell _emptyCellPrefab;

    public Cell GetRandomCell()
    {
        int maxValue = _cells.Length;
        int randomIndex = Random.Range(0, maxValue);

        Cell randomCell;

        randomCell = _cells[randomIndex];

        return randomCell;
    }
}