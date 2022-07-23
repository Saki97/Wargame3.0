using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Animator PlayerBattlePicAnimator;
    public Slider PlayerHpBar;
    public Animator EnemyBattlePicAnimator;
    public Slider EnemyHpBar;
    
    private Animator _playerHpBarAnimator;
    private TMP_Text _playerHpText;
    private Animator _enemyHpBarAnimator;
    private TMP_Text _enemyHpText;
    
    private string _popUpAnimTriggerName = "PopUp";
    
    public void SwitchToBattleUI(Player player, Enemy enemy)
    {
        _playerHpText.text = $"{player.CurrentHitPoints} / {player.MaxHitPoints}";
        _enemyHpText.text = $"{enemy.CurrentHitPoints} / {enemy.MaxHitPoints}";
        
        PlayerHpBar.value = (float) player.CurrentHitPoints / player.MaxHitPoints;
        EnemyHpBar.value = (float) enemy.CurrentHitPoints / enemy.MaxHitPoints;
            
        PlayerBattlePicAnimator.SetTrigger(_popUpAnimTriggerName);
        EnemyBattlePicAnimator.SetTrigger(_popUpAnimTriggerName);
        
        _playerHpBarAnimator.SetTrigger(_popUpAnimTriggerName);
        _enemyHpBarAnimator.SetTrigger(_popUpAnimTriggerName);
    }

    public void SwitchToNormalUI()
    {
        PlayerBattlePicAnimator.SetTrigger("Disappear");
        EnemyBattlePicAnimator.SetTrigger("Die");
            
        _playerHpBarAnimator.SetTrigger("Disappear");
        _enemyHpBarAnimator.SetTrigger("Disappear");
    }

    public void UpdateHPBar(CharacterBase character)
    {
        if (character.CharacterType == ECharacterType.Player)
        {
            _playerHpText.text = $"{character.CurrentHitPoints} / {character.MaxHitPoints}";
            PlayerHpBar.value = (float) character.CurrentHitPoints / character.MaxHitPoints;
        }
        else if (character.CharacterType == ECharacterType.Enemy)
        {
            _enemyHpText.text = $"{character.CurrentHitPoints} / {character.MaxHitPoints}";
            EnemyHpBar.value = (float) character.CurrentHitPoints / character.MaxHitPoints;
        }
    }

    private void Awake()
    {
        _playerHpBarAnimator = PlayerHpBar.GetComponent<Animator>();
        _playerHpText = PlayerHpBar.gameObject.GetComponentInChildren<TMP_Text>();
        
        _enemyHpBarAnimator = EnemyHpBar.GetComponent<Animator>();
        _enemyHpText = EnemyHpBar.gameObject.GetComponentInChildren<TMP_Text>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
