using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Controller : MonoBehaviour
{
    public Tilemap WallTilemap;
    // public BattleManager BattleManager;
    
    private Player _player;
    
    private void Awake()
    {
        _player = this.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void TryMove(float x, float y, float z)
    {
        var pos = transform.position;
        
        var tpos = WallTilemap.WorldToCell(pos + new Vector3(x, y, z));

        var hit = Physics2D.Raycast(pos, new Vector2(x, y));

        if (hit.collider != null && hit.distance < 1f)
        {
            Debug.Log("Battle");
            var enemy = hit.collider.GetComponent<Enemy>();
            _player.StartBattle(enemy);
            return;
        }
        
        if (WallTilemap.HasTile(tpos))
        {
            return;
        }
        
        transform.Translate(x, y, z);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!_player.IsBattling)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                TryMove(0, 1f, 0);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                TryMove(0, -1f, 0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TryMove(-1f, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                TryMove(1f, 0, 0);
            }
        }
    }
}
