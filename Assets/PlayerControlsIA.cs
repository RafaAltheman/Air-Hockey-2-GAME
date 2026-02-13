using UnityEngine;

public class PlayerControlsIA : MonoBehaviour
{
    public string puckName = "puck_0";
    private Transform puck;

    // limites (os seus)
    public float minX = -3.1f;
    public float maxX =  3.03f;
    public float minY =  0f;
    public float maxY =  4.2f;

    public float radius = 0.35f;

    // defesa/ataque
    public float defendY = 3.6f;
    public float attackY = 2.2f;
    public float attackWhenPuckAboveY = 0.2f;

    // movimento
    public float speed = 7f; // deixa 6~9

    private Rigidbody2D rb;
    private Vector2 targetPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject obj = GameObject.Find(puckName);
        if (obj != null) puck = obj.transform;

        // começa defendendo
        targetPos = new Vector2(transform.position.x, defendY);
    }

    void Update()
    {
        if (!puck) return;

        // X sempre segue o puck
        float tx = Mathf.Clamp(puck.position.x, minX + radius, maxX - radius);

        float ty;

        // Se o puck está na metade de cima, persegue o Y do puck (ATACA de verdade)
        if (puck.position.y > attackWhenPuckAboveY)
        {
            // segue o puck no Y, mas com um offset pra “bater” nele (opcional)
            ty = puck.position.y - 0.25f;
        }
        else
        {
            // se o puck está embaixo, volta pra posição de defesa
            ty = defendY;
        }

        // limita no campo da IA
        ty = Mathf.Clamp(ty, minY + radius, maxY - radius);

        targetPos = new Vector2(tx, ty);
    }


    void FixedUpdate()
    {
        if (rb == null) return;

        Vector2 current = rb.position;

        // move suave “físico”
        Vector2 next = Vector2.MoveTowards(current, targetPos, speed * Time.fixedDeltaTime);

        // clamp final
        next.x = Mathf.Clamp(next.x, minX + radius, maxX - radius);
        next.y = Mathf.Clamp(next.y, minY + radius, maxY - radius);

        rb.MovePosition(next);
    }
}
    