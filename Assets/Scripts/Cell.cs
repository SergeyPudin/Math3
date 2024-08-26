using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    private Board _board;

    private int _cellNumber;
    private int _rowNumber;

    public bool IsVisited; 

    public int CellNumber => _cellNumber;
    public int RowNumber => _rowNumber;

    private void Start()
    {
        IsVisited = false;
        _board = GetComponentInParent<Board>();

        Image image = GetComponent<Image>();

        SetRandomSprite(image);
    }

    public void GetAddress(int rowNumber, int cellNumber)
    {
        _cellNumber = cellNumber;
        _rowNumber = rowNumber;
    }

    public void SetRandomSprite(Image image)
    {
        int randomIndex = Random.Range(0, _sprites.Length);

        image.sprite = _sprites[randomIndex];
    }
}