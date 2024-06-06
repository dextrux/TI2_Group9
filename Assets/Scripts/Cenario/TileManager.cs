using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Scenario
{
    public class TileManager : MonoBehaviour
    {
        [SerializeField] private TileControl[] _tilesArea1;
        [SerializeField] private TileControl[] _tilesArea2;
        [SerializeField] private TileControl[] _tilesArea3;
        [SerializeField] private TileControl[] _transitionTile;
        [SerializeField] private TileControl _startTile;
        [SerializeField] private float _tileSize;
        [SerializeField] private sbyte _tileQuantity;
        [SerializeField] private sbyte _chanceArea1;
        [SerializeField] private sbyte _chanceArea2;
        [SerializeField] private sbyte _easyQuantity;
        [SerializeField] private sbyte _mediumQuantity;
        private float _actualTilePosition;
        private sbyte _actualArea;
        private sbyte _actualDifficulty;
        private sbyte _newDifficulty;
        private sbyte _minRange;
        private sbyte _maxRange;
        private int random;
        internal int TileCount;
        private void Start()
        {
            TileCount = 0;
            _actualTilePosition = 0;
            _actualArea = 0;
            _actualDifficulty = 0;
            _newDifficulty = 0;
            _minRange = 0;
            _maxRange = _easyQuantity;
            _startTile.transform.position = new Vector3(0, 0, _actualTilePosition);
            _startTile.gameObject.SetActive(true);
            _actualTilePosition += _tileSize;
            for (int i = 0; i < _tileQuantity; i++)
            {
                SpawnTiles();
            }
        }
        private void Update()
        {
            CheckDifficulty();
            if (_tileQuantity < TileCount) SpawnTiles();
        }
        public void SpawnTiles()
        {
            random = Random.Range(_minRange, _maxRange);
            while (_tilesArea1[random].Active)
            {
                random++;
                if (random >= _maxRange) random = _minRange;
            }
            switch (_actualArea)
            {
                case 0:
                    _tilesArea1[random].transform.position = new Vector3(0, 0, _actualTilePosition);
                    _tilesArea1[random].gameObject.SetActive(true);
                    break;
                case 1:
                    _tilesArea2[random].transform.position = new Vector3(0, 0, _actualTilePosition);
                    _tilesArea2[random].gameObject.SetActive(true);
                    break;
                case 2:
                    _tilesArea3[random].transform.position = new Vector3(0, 0, _actualTilePosition);
                    _tilesArea3[random].gameObject.SetActive(true);
                    break;
            }
            _actualTilePosition += _tileSize;
        }
        private void CheckDifficulty()
        {
            if (_newDifficulty != _actualDifficulty)
            {
                switch (_newDifficulty)
                {
                    case 1:
                        _minRange = _easyQuantity;
                        _maxRange = _mediumQuantity;
                        break;
                    case 2:
                        _minRange = _mediumQuantity;
                        _maxRange = (sbyte)_tilesArea1.Length;
                        break;
                }
            }
        }
    }
}
