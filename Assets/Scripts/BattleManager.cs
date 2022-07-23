using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameUIManager GameUIManager;
    [SerializeField] private float AttackInterval = 0.25f;
    
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
        GameUIManager.SwitchToBattleUI(player, enemy);
        StartCoroutine(performBattle(player, enemy));
    }
    
    private IEnumerator performBattle(Player player, Enemy enemy)
    {
        yield return new WaitForSeconds(0.2f);
        while (player.CurrentHitPoints != 0 && enemy.CurrentHitPoints != 0)
        {
            yield return new WaitForSeconds(AttackInterval);
            enemy.Damage(player.ATK);
            yield return new WaitForSeconds(AttackInterval);
            player.Damage(enemy.ATK);
        }

        if (enemy.CurrentHitPoints == 0)
        {
            GameUIManager.SwitchToNormalUI();
            enemy.Die();
            player.Recover();
        }
    }


}
