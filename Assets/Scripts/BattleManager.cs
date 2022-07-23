using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Animator PlayerBattlePic;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBattle(Player player, Enemy enemy)
    {
        PlayerBattlePic.SetTrigger("PopUp");
    }
}
