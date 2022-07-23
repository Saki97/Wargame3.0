using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterBase : MonoBehaviour
{
    [SerializeField] protected int _maxHitPoints;
    [SerializeField] protected int _atk;
    [SerializeField] protected int _def;
    [SerializeField] protected string _displayName;
    [SerializeField] protected Slider _hpBar;
    
    protected int _currentHitPoints;
    public int ATK => _atk;
    public int CurrentHitPoints => _currentHitPoints;
    
    // Start is called before the first frame update
    protected void Start()
    {
        _currentHitPoints = _maxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int attackerAtk)
    {
        var damage = math.max(attackerAtk - _def, 0);
        _currentHitPoints = math.max(_currentHitPoints - damage, 0);

        _hpBar.value = (float)_currentHitPoints / _maxHitPoints;
        
        Debug.Log($"{_displayName} got {damage} damage, {_currentHitPoints} hp left.");
    }
}
