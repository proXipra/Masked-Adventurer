using UnityEngine;
using System.Collections;

public class SawScript : MonoBehaviour
{
    // Hedef noktalar ve hareket süresi
    public Vector3 pointA;
    public Vector3 pointB;
    public float duration = 2.0f;
    // Başlangıçta Coroutine'i başlatıyoruz
    void Start()
    {
        StartCoroutine(Move());

    }

    private IEnumerator Move()
    {
        while (true)
        {

            yield return StartCoroutine(MoveToPoint(pointA, pointB, duration));
            yield return StartCoroutine(MoveToPoint(pointB, pointA, duration));
        }
    }

    private IEnumerator MoveToPoint(Vector3 startPoint, Vector3 endPoint, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPoint, endPoint, elapsedTime / duration);
            yield return null;
        }
        FlipSprite();
        // Hareketi tam olarak sonlandır (küçük yuvarlama hatalarını gidermek için)
        transform.position = endPoint;
    }

    private void FlipSprite()
    {
        UnityEngine.Vector3 ls = transform.localScale;
        ls.x *= -1;
        transform.localScale = ls;
    }
}
