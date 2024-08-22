using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ControleBoat : MonoBehaviour
{
    public float speed = 10f; // Velocidade de movimento do barco
    public float turnSpeed = 5f; // Velocidade de rotação do barco

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical"); // W/S ou seta para cima/baixo para mover para frente/trás
        float turnInput = Input.GetAxis("Horizontal"); // A/D ou seta para esquerda/direita para virar

        Vector3 moveDirection = transform.forward * moveInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);

        Quaternion turnRotation = Quaternion.Euler(0f, turnInput * turnSpeed * Time.deltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}