using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Referência para o jogador
    public Transform player;

    // Distância da câmera em relação ao jogador
    public Vector3 offset;

    // A velocidade de movimentação da câmera
    private float followSpeed = 5f;

    void Start()
    {
        // Defina o offset inicial se não for atribuído
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void Update()
    {
        // A posição da câmera segue a posição do jogador, com o offset e suavização
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
