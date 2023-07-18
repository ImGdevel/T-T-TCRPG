using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    protected string name;
    protected int maxHealth;
    protected int currentHealth;
    protected int maxEnergy;
    protected int currentEnergy;
    protected int attackPower;
    protected BuffManager buffManager;
    

    public string Name { get { return name; } }
    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get { return currentHealth; } }
    public int MaxEnergy { get { return maxEnergy; } }
    public int CurrentEnergy { get { return currentEnergy; } }
    public int AttackPower { get { return attackPower; } }
    public BuffManager BuffManager { get { return buffManager; } }

    public abstract void Attack();
    public abstract void Defend();
    public abstract void TakeDamage(int damage);
    public abstract void TakeBuff(Buff buff);
    public abstract void Die();
    public abstract Character Clone();
}