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


        // Essas linhas normalizam as coordenadas da �ncora m�nima (posi��o) para o intervalo [0, 1].
        // Dividimos as coordenadas pelo tamanho da tela(largura e altura) para obter valores proporcionais.
        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        Debug.Log("MinAnchor: " + minAnchor);
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;
        Debug.Log("MaxAnchor: " + maxAnchor);


        //Essas linhas definem as �ncoras m�nima e m�xima do RectTransform.
        //As �ncoras controlam como o objeto se ajusta � tela quando a resolu��o muda.
        //Ao definir essas �ncoras com base na �rea segura da tela, o objeto se ajustar� automaticamente para caber na �rea vis�vel.
        rectTransform.anchorMin = minAnchor;
        rectTransform.anchorMax = maxAnchor;
    }

}
