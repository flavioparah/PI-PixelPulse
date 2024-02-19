using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public Transform handPosition; // Referência à posição da mão do personagem
    public float maxAngle = 90f; // Ângulo máximo que a mira pode virar em relação ao personagem

    void Update()
    {
        // Calcula a direção do mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 aimDirection = (mousePosition - transform.position).normalized;

        // Limita o ângulo de rotação da mira
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -maxAngle, maxAngle);

        // Aplica a rotação da mira
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Posiciona a arma na posição da mão do personagem
        transform.position = handPosition.position;
    }
}


