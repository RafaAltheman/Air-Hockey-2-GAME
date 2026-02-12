using UnityEngine;

public class PlayerControlsIA : MonoBehaviour
{
    public string puckName = "puck_0";
    private Transform puck;

    public float speed = 8f;

    // limites
    public float minX = -3.1f;
    public float maxX =  3.03f;
    public float minY =  0f;
    public float maxY =  4.2f;

    public float radius = 0.35f;

    // comportamento
    public float defendY = 3.7f;  // posição de defesa (perto do gol)
    public float attackY = 2.2f;  // posição de ataque (mais pra frente)
    public float attackWhenPuckAboveY = 0.2f; // se puck passar disso, IA ataca

    void Start()
    {
        GameObject obj = GameObject.Find(puckName);
        if (obj != null) puck = obj.transform;

        // começa defendendo
        Vector3 p = transform.position;
        p.y = defendY;
        transform.position = p;
    }

    void Update()
    {
        if (!puck) return;

        // alvo X: sempre seguir o puck
        float targetX = Mathf.Clamp(puck.position.x, minX + radius, maxX - radius);

        // alvo Y: defende ou ataca
        float targetY = (puck.position.y > attackWhenPuckAboveY) ? attackY : defendY;
        targetY = Mathf.Clamp(targetY, minY + radius, maxY - radius);

        Vector3 pos = transform.position;

        // move suave nos dois eixos
        pos.x = Mathf.MoveTowards(pos.x, targetX, speed * Time.deltaTime);
        pos.y = Mathf.MoveTowards(pos.y, targetY, speed * Time.deltaTime);

        // clamp final
        pos.x = Mathf.Clamp(pos.x, minX + radius, maxX - radius);
        pos.y = Mathf.Clamp(pos.y, minY + radius, maxY - radius);

        transform.position = pos;
    }
}
