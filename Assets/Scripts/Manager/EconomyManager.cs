using System.IO;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance;
    [SerializeField] private int _footPrint;
    [SerializeField] private int _punch;
    [SerializeField] private int _xp;
    private string _filePath;
    [System.Serializable]
    public class EconomyData
    {
        public int FootPrint;
        public int Punch;
        public int Xp;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _filePath = Path.Combine(Application.persistentDataPath, "economyData.json");
            LoadEconomyData();
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
    [ContextMenu("Salvar Jogo")]
    public void SaveEconomyData()
    {
        EconomyData data = new EconomyData()
        {
            FootPrint = _footPrint,
            Punch = _punch,
            Xp = _xp
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(_filePath, json);
    }
    private void LoadEconomyData()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            EconomyData data = JsonUtility.FromJson<EconomyData>(json);
            _footPrint = data.FootPrint;
            _punch = data.Punch;
            _xp = data.Xp;
        }
    }
}
