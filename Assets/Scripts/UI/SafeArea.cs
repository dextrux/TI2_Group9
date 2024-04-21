using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private RectTransform rectTransform;
    private Rect safeAreaRect;
    Vector2 minAnchor;
    Vector2 maxAnchor;

    private void Awake()
    {
        FitInSafeArea();
    }
    void OnRectTransformDimensionsChange()
    {
        FitInSafeArea();
    }

    [ContextMenu("FitInSafeArea")]
    private void FitInSafeArea()
    {
        if (Application.isPlaying == false) return;
        rectTransform = GetComponent<RectTransform>();

        safeAreaRect = Screen.safeArea;
        minAnchor = safeAreaRect.position;
        maxAnchor = minAnchor + safeAreaRect.size;


        // Essas linhas normalizam as coordenadas da âncora mínima (posição) para o intervalo [0, 1].
        // Dividimos as coordenadas pelo tamanho da tela(largura e altura) para obter valores proporcionais.
        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        Debug.Log("MinAnchor: " + minAnchor);
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;
        Debug.Log("MaxAnchor: " + maxAnchor);


        //Essas linhas definem as âncoras mínima e máxima do RectTransform.
        //As âncoras controlam como o objeto se ajusta à tela quando a resolução muda.
        //Ao definir essas âncoras com base na área segura da tela, o objeto se ajustará automaticamente para caber na área visível.
        rectTransform.anchorMin = minAnchor;
        rectTransform.anchorMax = maxAnchor;
    }

}
