using UnityEngine;

class Utils {
    static public Vector2 getMousePositionInUnits(float wideUnits = 0, float heightUnits = 0) =>
        new Vector2(
            (Input.mousePosition.x / Screen.width) * wideUnits,
            (Input.mousePosition.y / Screen.height) * heightUnits
        );

    static public Vector2 getVector2Distance(Vector2 pos1, Vector2 pos2) =>
        pos1 - pos2;
}