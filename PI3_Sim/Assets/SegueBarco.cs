using UnityEngine;

public class SegueBarco : MonoBehaviour
{
    public Transform boat; // Referência ao barco
    public Vector3 offset; // Offset da câmera em relação ao barco

    void Start()
    {
        // Defina um offset inicial, se necessário
        offset = transform.position - boat.position;
    }

    void LateUpdate()
    {
        // Atualize a posição da câmera para seguir o barco
        transform.position = boat.position + offset;
    }
}
