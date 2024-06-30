using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public static PlayerCharacter Instance;
    [SerializeField] private GameObject[] _characters;
    [SerializeField] private sbyte _active;

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
        _active = 0; // Trocar para puxar por personagem escolhido
        foreach (GameObject character in _characters)
        {
            character.SetActive(false);
        }
        _characters[_active].SetActive(true);
    }
    public void NextChar()
    {
        _characters[_active].SetActive(false);
        _active++;
        if (_active >= _characters.Length) _active = 0;
        _characters[_active].SetActive(true);
    }
    public void PreviousChar()
    {
        _characters[_active].SetActive(false);
        if (_active == 0) _active = (sbyte)(_characters.Length - 1);
        else _active--;
        _characters[_active].SetActive(true);
    }
    public int GetActive()
    {
        return _active;
    }
}
