using UnityEngine;

public static class ExtensionMethods
{
    public static Vector3 GetPositionOnScreen(this Vector3 position, Canvas canvas, RectTransform transform, float offset)
    {
        float rightEdgeDistance = Screen.width - (position.x + transform.rect.width * canvas.scaleFactor / 2) - offset;

        if (rightEdgeDistance < 0)
        {
            position.x += rightEdgeDistance;
        }

        float leftEdgeDistance = 0 - (position.x - transform.rect.width * canvas.scaleFactor / 2) + offset;

        if (leftEdgeDistance > 0)
        {
            position.x += leftEdgeDistance;
        }

        float topEdgeDistance = Screen.height - (position.y + transform.rect.height * canvas.scaleFactor / 2) - offset;

        if (topEdgeDistance < 0)
        {
            position.y += topEdgeDistance;
        }

        float bottomEdgeDistance = 0 - (position.y - transform.rect.height * canvas.scaleFactor / 2) + offset;

        if (bottomEdgeDistance > 0)
        {
            position.y += bottomEdgeDistance;
        }

        return position;
    }
}