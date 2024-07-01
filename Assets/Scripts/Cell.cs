using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image[] _cells;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        int randomCell = Random.Range(0, _cells.Length);

        Image cell = Instantiate(_cells[randomCell], transform);
        RectTransform cellRectTransform = cell.GetComponent<RectTransform>();

        SetupRectTransform(cellRectTransform);

        cell.name = this.name;
    }

    private void SetupRectTransform(RectTransform rectTransform)
    {
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.offsetMax = new Vector2(0, 0);
        rectTransform.localPosition = Vector3.zero;
        rectTransform.localScale = Vector3.one;
    }
}