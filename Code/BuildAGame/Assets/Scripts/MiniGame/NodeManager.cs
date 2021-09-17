using UnityEngine;

public class NodeManager : MonoBehaviour
{  
    private GameManager gameManagerRef;
    
    public void SetDependencies(Color newColor, Vector2 newPosition, GameManager newReference)
    {
        GetComponent<SpriteRenderer>().color = newColor;

        // Multiply time grid size
        transform.position = newPosition;
        gameManagerRef = newReference;
    }
}
