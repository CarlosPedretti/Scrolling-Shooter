using UnityEngine;

public class Texture : MonoBehaviour
{
    public float speed = 5f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Mueve el sprite hacia abajo
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
