using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CellsHandler))] 
public class Board : MonoBehaviour
{
    [SerializeField] private int _rowsNumber;
    [SerializeField] private int _columnsNumber;

    [SerializeField] private Row _rowPrefab;

    public int RowsNumber => _rowsNumber;
    public int ColumnNumber => _columnsNumber;

    private CellsHandler _cellsHandler;
    private Cell[,] _cells;

    private void Awake()
    {
        _cellsHandler = GetComponent<CellsHandler>();
        _cells = new Cell[_columnsNumber, _rowsNumber];

        InitializeCells();
        _cellsHandler.GetCells(_cells);
    }
    private void Start()
    {
        StartCoroutine(ChangeSameColorDeleyed());
    }

    public void GetNewCell(Cell cell)
    {
        _cells[cell.CellNumber, cell.RowNumber] = cell;

        Button button = cell.GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(() => OnCellClicked(cell));
        }
    }

    public IEnumerator ChangeSameColorDeleyed()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        yield return waitForSeconds;

        ChangeColor();
    }

    private void OnCellClicked(Cell cell)
    {
        _cellsHandler.OnClicked(cell);
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

    private void ChangeColor()
    {
        bool[,] checkedCells = new bool[_columnsNumber, _rowsNumber];

        for (int i = 0; i < _columnsNumber; i++)
        {
            for (int j = 0; j < _rowsNumber; j++)
            {
                if (!checkedCells[i, j])
                {
                    int verticalMatchCount = 1;
                    int horizontalMatchCount = 1;

                    for (int k = j + 1; k < _rowsNumber && _cells[i, k].GetComponent<Image>().sprite.name == _cells[i, j].GetComponent<Image>().sprite.name; k++)
                    {
                        verticalMatchCount++;
                    }

                    for (int k = i + 1; k < _columnsNumber && _cells[k, j].GetComponent<Image>().sprite.name == _cells[i, j].GetComponent<Image>().sprite.name; k++)
                    {
                        horizontalMatchCount++;
                    }

                    if (verticalMatchCount >= 3 || horizontalMatchCount >= 3)
                    {
                        string spriteName = _cells[i, j].GetComponent<Image>().sprite.name;

                        for (int k = j; k < j + verticalMatchCount; k++)
                        {
                            _cells[i, k].SetRandomSprite(_cells[i, k].GetComponent<Image>());
                            checkedCells[i, k] = true;
                        }

                        for (int k = i; k < i + horizontalMatchCount; k++)
                        {
                            _cells[k, j].SetRandomSprite(_cells[k, j].GetComponent<Image>());
                            checkedCells[k, j] = true;
                        }
                    }
                }
            }
        }

        Array.Clear(checkedCells, 0, checkedCells.Length);
    }
}
