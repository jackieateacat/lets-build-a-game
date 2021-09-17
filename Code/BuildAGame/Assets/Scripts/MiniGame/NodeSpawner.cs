using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    public List<Color> nodeColors = new List<Color>();
    public int minNodesPerType;
    public int maxNodesPerType;

    public GameObject nodePrefab;
    public GameManager gameManagerRef;

    private void Start()
    {
        foreach(Color item in nodeColors)
        {
            // Random draw for node count
            int nodeCount =  Random.Range(minNodesPerType, maxNodesPerType);

            for(int i = 0; i < nodeCount; i++)
            {
                bool goodSolution = false;
                int xPosition;
                int yPosition;

                do 
                {
                    // Draw a random x and y position
                    xPosition = Random.Range(0, gameManagerRef.gridArray.GetLength(0));
                    yPosition = Random.Range(0, gameManagerRef.gridArray.GetLength(1));

                    // Check if position is already occupied
                    if (gameManagerRef.PositionCheck(xPosition, yPosition) == GridCodeEnum.empty)
                    {
                        goodSolution = true;
                    }

                } while (!goodSolution);

                // Instantiate new gameobject
                GameObject newNode = Instantiate(nodePrefab, transform);

                // Update grid array
                gameManagerRef.gridArray[xPosition, yPosition] = GridCodeEnum.node;

                // Convert array position to grid coordinates
                float newXPosition = (xPosition - gameManagerRef.gridArray.GetLength(0) / 2) * gameManagerRef.gridSize;
                float newYPosition = (yPosition - gameManagerRef.gridArray.GetLength(1) / 2) * gameManagerRef.gridSize;

                // Inject color and position dependencies
                newNode.GetComponent<NodeManager>().SetDependencies(item, new Vector2(newXPosition, newYPosition), gameManagerRef);
            }
        }
    }

}
