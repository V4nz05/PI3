
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlutuacaoBarco : MonoBehaviour
{
    public float waterLevel = 0f; // Nível da água
    public float floatHeight = 2f; // Altura que o objeto deve flutuar
    public float bounceDamp = 0.05f; // Amortecimento da flutuação
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
    }
}
