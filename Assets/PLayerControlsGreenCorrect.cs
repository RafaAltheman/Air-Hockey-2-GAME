using UnityEngine;

public class PLayerControlsGreenCorrect : MonoBehaviour
{
    // limites da sua mesa (pelas paredes)
    public float minX = -3.1f;
    public float maxX =  3.03f;
    public float minY = -3.96f;  // parede de baixo
    public float maxY =  0f;     // meio do campo (não pode passar)

    // margem pra palheta não encostar/sair pela parede (raio)
    public float radius = 0.35f;

    void Start()
    {
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var pos = transform.position;

        // trava dentro do retângulo permitido
        pos.x = Mathf.Clamp(mousePos.x, minX + radius, maxX - radius);
        pos.y = Mathf.Clamp(mousePos.y, minY + radius, maxY - radius);

        transform.position = pos;
    }
}
