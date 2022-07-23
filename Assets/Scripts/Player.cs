using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    public BattleManager BattleManager;
    
    private bool _isBattling = false;

    public bool IsBattling => _isBattling;

    public void StartBattle(Enemy enemy)
    {
        BattleManager.StartBattle(this, enemy);
        _isBattling = true;
    }

    public void Recover()
    {
        _isBattling = false;
    }

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
