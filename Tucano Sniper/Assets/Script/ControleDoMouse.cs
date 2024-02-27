using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoMouse : MonoBehaviour
{
    public Transform boneDoBraco; // Referência ao bone do braço
    public float velocidade = 5.0f; // Velocidade de movimento do braço

    void Update()
    {
        // Verificar se o bone do braço foi atribuído
        if (boneDoBraco == null)
        {
            Debug.LogError("O bone do braço não foi atribuído!");
            return;
        }

        // Obter a posição do mouse no eixo X e Y
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calcular a rotação do braço
        Vector3 rotacao = boneDoBraco.localEulerAngles;

        // Girar o braço para esquerda/direita (rotação em torno do eixo Y)
        rotacao.y += mouseX * velocidade * Time.deltaTime;

        // Girar o braço para cima/baixo (rotação em torno do eixo X)
        rotacao.x -= mouseY * velocidade * Time.deltaTime;

        // Limitar a rotação do braço para não girar em excesso
        rotacao.x = Mathf.Clamp(rotacao.x, -90f, 90f); // Limitando entre -90 e 90 graus para evitar rotação excessiva

        // Aplicar a rotação ao braço
        boneDoBraco.localEulerAngles = rotacao;
    }
}

