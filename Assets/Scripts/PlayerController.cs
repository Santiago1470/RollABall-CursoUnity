using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int puntaje;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI puntajeGUI;
    public GameObject mensajeGanar;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        puntaje = 0;
        SetCountText();
        mensajeGanar.SetActive(false);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        puntajeGUI.text = "Puntaje: " + puntaje.ToString();
        if (puntaje >= 25)
        {
            mensajeGanar.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            puntaje += 1;
            SetCountText();
            other.gameObject.SetActive(false);
        }
    }
}