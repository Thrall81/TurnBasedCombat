using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private BattleStateMachine m_BSM;

    public Slider m_cooldownBar;
    private float m_currentCooldown = 0f;
    private float m_maxCooldown = 5f;

    private Vector3 m_startPosition;

    public BaseHero m_hero;

    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        DEAD
    }

    public static TurnState currentState;

    // Use this for initialization
    void Start () {
        currentState = TurnState.PROCESSING;
        m_BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        m_startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log(currentState);
        switch (currentState)
        {
            case TurnState.PROCESSING:
                break;
            case TurnState.CHOOSEACTION:
                break;
            case TurnState.WAITING:
                break;
            case TurnState.ACTION:
                break;
            case TurnState.DEAD:
                break;
            default:
                break;
        }

    }

    void UpgradeProgressBar()
    {
        m_currentCooldown = m_currentCooldown + Time.deltaTime;
        float calc_cooldown = m_currentCooldown / m_maxCooldown;
        m_cooldownBar.value = calc_cooldown;
        if (m_currentCooldown >= m_maxCooldown)
        {
            currentState = TurnState.CHOOSEACTION;
        }
    }

    void ChooseAction()
    {
        HandleTurn myAttack = new HandleTurn();
        myAttack.m_attacker = m_hero.name;
        myAttack.m_attacksGameObject = this.gameObject;
        myAttack.AttackersTarget = m_BSM.HeroesInBattle[Random.Range(0, m_BSM.HeroesInBattle.Count)];
        m_BSM.CollectActions(myAttack);
    }

}
