using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class GridScaler : MonoBehaviour
{
    private GridLayoutGroup gridLayoutGroup;
    private RectTransform rectTransform;

    void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        AdjustGrid();
    }

    void Update()
    {
        AdjustGrid();
    }

    void AdjustGrid()
    {
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        int childCount = transform.childCount;
        int rows = Mathf.CeilToInt(Mathf.Sqrt(childCount));
        int columns = Mathf.CeilToInt((float)childCount / rows);

        float cellWidth = (parentWidth - ((columns - 1) * gridLayoutGroup.spacing.x)) / columns;
        float cellHeight = (parentHeight - ((rows - 1) * gridLayoutGroup.spacing.y)) / rows;

        gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
    }
}
