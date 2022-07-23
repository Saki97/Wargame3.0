using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Animator PlayerBattlePic;
    public Animator PlayerHPBar;
    public Animator EnemyBattlePic;
    public Animator EnemyrHPBar;
    
    [SerializeField] private float AttackInterval = 0.25f;

    private string _popUpAnimTriggerName = "PopUp";
    
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
        performUI();

        StartCoroutine(performBattle(player, enemy));
    }

    private void performUI()
    {
        PlayerBattlePic.SetTrigger(_popUpAnimTriggerName);
        EnemyBattlePic.SetTrigger(_popUpAnimTriggerName);
        
        PlayerHPBar.SetTrigger(_popUpAnimTriggerName);
        EnemyrHPBar.SetTrigger(_popUpAnimTriggerName);
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
            PlayerBattlePic.SetTrigger("Disappear");
            EnemyBattlePic.SetTrigger("Die");
            
            PlayerHPBar.SetTrigger("Disappear");
            EnemyrHPBar.SetTrigger("Disappear");
            
            enemy.Die();
            player.Recover();
        }
    }


}
