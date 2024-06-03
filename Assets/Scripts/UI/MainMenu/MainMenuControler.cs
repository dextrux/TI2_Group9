using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{
    [Header("Store")]
    [SerializeField] private int _punchBuyCost;
    [SerializeField] private int _singleFootPrintBuyCost;
    [SerializeField] private int _tenFootPrintBuyCost;
    [SerializeField] private TextMeshProUGUI _footPrintText;
    [SerializeField] private TextMeshProUGUI _punchText;
    [SerializeField] private TextMeshProUGUI _xpText;
    private void Start()
    {
        GameManager.instance.ResumeGame();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayButtonSFX()
    {
        AudioManager.Instance.TocarSFX(0);
    }
    public void BuyFootPrint(bool single)
    {
        if (single)
        {
            if (EconomyManager.Instance.GetXp() >= _singleFootPrintBuyCost)
            {
                EconomyManager.Instance.UpdateXp(-_singleFootPrintBuyCost);
                EconomyManager.Instance.UpdateFootPrint(1);
            }
        }
        else
        {
            if (EconomyManager.Instance.GetXp() >= _tenFootPrintBuyCost)
            {
                EconomyManager.Instance.UpdateXp(-_tenFootPrintBuyCost);
                EconomyManager.Instance.UpdateFootPrint(10);
            }
        }
        
    }
    public void BuyPunch(int value)
    {
        if (EconomyManager.Instance.GetXp() >= _punchBuyCost)
        {
            EconomyManager.Instance.UpdateXp(-_punchBuyCost);
            EconomyManager.Instance.UpdatePunch(value);
        }
    }
    public void UpdateTextStore()
    {
        _footPrintText.text = EconomyManager.Instance.GetFootPrint().ToString();
        _punchText.text = EconomyManager.Instance.GetPunch().ToString();
        _xpText.text = EconomyManager.Instance.GetXp().ToString();
    }
}
