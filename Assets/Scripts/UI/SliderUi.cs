using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUi : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private bool _isSFX = false;



    private void OnEnable()
    {
        InicializarSliders();
    }

    public void InicializarSliders()
    {
        if (_isSFX == false)
        {
            float volume = AudioManager.Instance.PegarVolumeBGSalvo();
            AtualizaSliderVolumeBG(volume);
        }
        else
        {
            float volume = AudioManager.Instance.PegarVolumeSFXSalvo();
            AtualizaSliderVolumeSFX(volume);
        }
    }

    public void AtualizaSliderVolumeBG(float valor)
    {
        slider.value = valor;
        AudioManager.Instance.AtualizarVolumeBG(valor);
    }

    public void AtualizaSliderVolumeSFX(float valor)
    {
        slider.value = valor;
        AudioManager.Instance.AtualizarVolumeSFX(valor);

    }
}
