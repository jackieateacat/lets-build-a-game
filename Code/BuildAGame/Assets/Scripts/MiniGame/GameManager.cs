using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gridSize;

    public float horizontalPadding;
    public float verticalPadding;

    public float horizontalExtent;
    public float verticalExtent;

    public GridCodeEnum[,] gridArray;

    private void Awake()
    {
        horizontalExtent = Camera.main.orthographicSize * Screen.width / Screen.height - horizontalPadding;
        verticalExtent = Camera.main.orthographicSize - verticalPadding;

        InitializeArray();
    }

    private void InitializeArray()
    {
        float xValue = horizontalExtent * 2 / gridSize;

        float yValue = verticalExtent * 2 / gridSize;

        gridArray = new GridCodeEnum[(int)xValue, (int)yValue];
        Debug.Log("Grid Array Initialized. X Length: " + gridArray.GetLength(0) + " Y Length: " + gridArray.GetLength(1));
    }

    public GridCodeEnum PositionCheck(int xPosition, int yPosition)
    {
        return gridArray[xPosition, yPosition];
    }

    public void NodePositionSet(int xPosition, int yPosition)
    {
        gridArray[xPosition, yPosition] = GridCodeEnum.empty;
    }
}
