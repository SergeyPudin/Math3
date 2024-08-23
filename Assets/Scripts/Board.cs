using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] private int _rowsNumber;
    [SerializeField] private int _columnsNumber;

    [SerializeField] private Row _rowPrefab;

    public int ColumnNumber => _columnsNumber;

    private Cell[,] _cells;

    private void Awake()
    {
        _cells = new Cell[_columnsNumber, _rowsNumber];

        InitializeCells();
    }
    private void Start()
    {
        StartCoroutine(ChangeSameColor());
    }

    public void GetNewCell(Cell cell)
    {
        _cells[cell.CellNumber, cell.RowNumber] = cell;

        // Debug.Log(_cells[cell.CellNumber, cell.RowNumber]);

        Button button = cell.GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(() => OnCellClicked(cell));
        }
    }

    private void OnCellClicked(Cell cell)
    {
        Debug.Log(cell.GetComponent<Image>().sprite.name);
    }

    private void InitializeCells()
    {
        for (int i = 0; i < _rowsNumber; i++)
        {
            Row row = Instantiate(_rowPrefab);
            row.transform.SetParent(this.transform, false);
            row.GetCellNumber(i, _columnsNumber);
        }
    }

    private IEnumerator ChangeSameColor()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        yield return waitForSeconds;

        for (int i = 2; i < _columnsNumber; i++)
        {
            for (int j = 0; j < _rowsNumber; j++)
            {
                if (_cells[i, j].GetComponent<Image>().sprite.name == _cells[i - 1, j].GetComponent<Image>().sprite.name &&
                   (_cells[i, j].GetComponent<Image>().sprite.name == _cells[i - 2, j].GetComponent<Image>().sprite.name))
                {
                    string name = _cells[i, j].GetComponent<Image>().sprite.name;

                    while (_cells[i, j].GetComponent<Image>().sprite.name == name)
                    {
                        _cells[i, j].SetRandomSprite(_cells[i, j].GetComponent<Image>());
                    }
                }

            }
        }

        for (int i = 0; i < _columnsNumber; i++)
        {
            for (int j = 2; j < _rowsNumber; j++)
            {
                if (_cells[i, j].GetComponent<Image>().sprite.name == _cells[i, j - 1].GetComponent<Image>().sprite.name &&
                   (_cells[i, j].GetComponent<Image>().sprite.name == _cells[i, j - 2].GetComponent<Image>().sprite.name))
                {
                    string name = _cells[i, j].GetComponent<Image>().sprite.name;

                    while (_cells[i, j].GetComponent<Image>().sprite.name == name)
                    {
                        _cells[i, j].SetRandomSprite(_cells[i, j].GetComponent<Image>());
                    }
                }

            }
        }
    }
}
