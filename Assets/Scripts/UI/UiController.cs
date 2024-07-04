using Manager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController Instance;
    [Header("Main Menu - Store")]
    [SerializeField] private int _punchBuyCost;
    [SerializeField] private int _singleFootPrintBuyCost;
    [SerializeField] private int _tenFootPrintBuyCost;
    [SerializeField] private TextMeshProUGUI _footPrintText;
    [SerializeField] private TextMeshProUGUI _punchText;
    [SerializeField] private TextMeshProUGUI _xpText;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _textCreature;
    [SerializeField] private TextMeshProUGUI _footPrintInGameText;
    [SerializeField] private TextMeshProUGUI _punchIngameText;
    [SerializeField] private TextMeshProUGUI _xpIngameText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
    public void NexChar()
    {
        PlayerCharacter.Instance.NextChar();
    }
    public void PrevChar()
    {
        PlayerCharacter.Instance.PreviousChar();
    }
    public void LoadGameScene(int sceneToLoad)
    {
        switch (sceneToLoad)
        {
            case 0:
                SceneManager.LoadScene("MainMenu");
                _menuPanel.SetActive(true);
                _gamePanel.SetActive(false);
                break;
            case 1:
                SceneManager.LoadScene("GameScene");
                _menuPanel.SetActive(false);
                _gamePanel.SetActive(true);
                break;
        }
    }
    public void GameOver()
    {
        GameManager.instance.PauseGame();
        EconomyManager.Instance.SaveEconomyData();
        _gameOverPanel.SetActive(true);
        _gamePanel.SetActive(false);
    }
    public void UpdateTextCreature()
    {
        if (PlayerCharacter.Instance.GetActive() == 0)
        {
            _textCreature.text = "Skunk Ape";
        }
        else if (PlayerCharacter.Instance.GetActive() == 1)
        {
            _textCreature.text = "The Sasquatch";
        }
    }
    public void UpdateTextInGame()
    {
        _footPrintInGameText.text = EconomyManager.Instance.GetFootPrint().ToString();
        _punchIngameText.text = EconomyManager.Instance.GetPunch().ToString();
        _xpIngameText.text = EconomyManager.Instance.GetXp().ToString();
    }
    public void UpdatePlayerPosition()
    {
        PlayerCharacter.Instance.transform.position = new Vector3(0, 0, -45);
    }
}