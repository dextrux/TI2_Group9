using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance;
    [SerializeField] private int _footPrint;
    [SerializeField] private int _punch;
    [SerializeField] private int _xp;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //Carregar as informações do save
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UpdateFootPrint(int valor)
    {
        _footPrint += valor;
    }
    public void UpdatePunch(int valor)
    {
        _punch += valor;
    }
    public void UpdateXp(int valor)
    {
        _xp += valor;
    }
    public int GetPunch()
    {
        return _punch;
    }
    public int GetXp()
    {
        return _xp;
    }
    public int GetFootPrint()
    {
        return _footPrint;
    }
}
