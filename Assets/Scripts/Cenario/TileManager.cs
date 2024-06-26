using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Scenario
{
    public class TileManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] _tiles;
        [SerializeField] private float _tileSize;
        [SerializeField] private Transform _player;
        [SerializeField] private sbyte _tileQuantity;
        private List<GameObject> _inactiveTiles;
        private float _actualTilePosition;
        void Start()
        {
            _inactiveTiles = new List<GameObject>();
            _actualTilePosition = 0;
            FindTiles();
            for (int i =  0; i < _tileQuantity; i++)
            {
                SpawnTiles(Random.Range(0, _inactiveTiles.Count));
            }
        }
        private void Update()
        {
            if (_tiles.Length - _inactiveTiles.Count <= _tileQuantity)
            {
                SpawnTiles(Random.Range(0, _inactiveTiles.Count));
            }
        }
        internal void DisableTile(GameObject tile)
        {
            _inactiveTiles.Add(tile);
            tile.SetActive(false);
        }
        private void FindTiles()
        {
            foreach (GameObject tile in _tiles)
            {
                DisableTile(tile);
            }
        }
        private void SpawnTiles(int position)
        {
            _inactiveTiles[position].transform.position = new Vector3(0, 0, (_actualTilePosition));
            _actualTilePosition += _tileSize;
            _inactiveTiles[position].SetActive(true);
            _inactiveTiles.Remove(_inactiveTiles[position]);
        }
    }
}
