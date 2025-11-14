using UnityEngine;

public class Objeto : MonoBehaviour
{
    void OnMouseDown()
    {
        Object.FindAnyObjectByType<GameManager>().Contador();

        Destroy(gameObject);
    }
}