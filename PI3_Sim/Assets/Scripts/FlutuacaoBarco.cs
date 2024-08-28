using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlutuaBarco : MonoBehaviour
{
    public float waterLevel = 0f; // Nível da água
    public float floatHeight = 2f; // Altura que o objeto deve flutuar
    public float bounceDamp = 0.05f; // Amortecimento da flutuação
    public float forwardForce = 0f; // Força para mover o barco para frente
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desativar a gravidade para o Rigidbody para evitar que o barco afunde
    }

    void FixedUpdate()
    {
        Vector3 actionPoint = transform.position;
        float forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);

        if (forceFactor > 0f)
        {
            Vector3 uplift = -Physics.gravity * (forceFactor - rb.velocity.y * bounceDamp);
            rb.AddForceAtPosition(uplift, actionPoint);
        }

        // Adicionar controle para mover o barco para frente
        Vector3 forward = transform.forward * forwardForce;
        rb.AddForce(forward, ForceMode.Force);

        // Manter o barco no eixo Z (evitar afundar)
        if (transform.position.y < waterLevel)
        {
            transform.position = new Vector3(transform.position.x, waterLevel, transform.position.z);
        }
    }
}
