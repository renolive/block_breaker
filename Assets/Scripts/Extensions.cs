using UnityEngine;

static class Extensions {
    public static Rigidbody2D GetRigidbody2D(this GameObject gameObject) =>
        gameObject.GetComponent<Rigidbody2D>();

    public static T GetRandomItem<T>(this T[] array) {
        return array[Random.Range(0, array.Length)];
    }
}