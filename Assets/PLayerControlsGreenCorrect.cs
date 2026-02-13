using UnityEngine;

public class PLayerControlsGreenCorrect : MonoBehaviour
{
    // limites da sua mesa (pelas paredes)
    public float minX = -3.1f;
    public float maxX =  3.03f;
    public float minY = -3.96f;
    public float maxY =  0f;     // meio do campo

    public float radius = 0.35f;

    public float speed = 20f; // ajuste: 15~30 (quanto maior, mais “gruda” no mouse)

    private Rigidbody2D rb;
    private Vector2 targetPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = Mathf.Clamp(mousePos.x, minX + radius, maxX - radius);
        float y = Mathf.Clamp(mousePos.y, minY + radius, maxY - radius);

        targetPos = new Vector2(x, y);
    }

    void FixedUpdate()
    {
        if (!rb) return;

        // move suave sem “teleportar”, respeitando colisão
        Vector2 next = Vector2.MoveTowards(rb.position, targetPos, speed * Time.fixedDeltaTime);
        rb.MovePosition(next);
    }
}
