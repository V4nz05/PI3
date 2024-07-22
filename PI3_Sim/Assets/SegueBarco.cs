using UnityEngine;

public class SegueBarco : MonoBehaviour
{
    public Transform boat; // Refer�ncia ao barco
    public Vector3 offset; // Offset da c�mera em rela��o ao barco

    void Start()
    {
        // Defina um offset inicial, se necess�rio
        offset = transform.position - boat.position;
    }

    void LateUpdate()
    {
        // Atualize a posi��o da c�mera para seguir o barco
        transform.position = boat.position + offset;
    }
}
