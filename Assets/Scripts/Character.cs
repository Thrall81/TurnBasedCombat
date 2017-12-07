using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour {

    public Character m_enemyCharacter;
    public float m_runningSpeed;
    public NavMeshAgent m_characterAgent;
    private Animator m_characterAnimator;

	// Use this for initialization
	void Start () {
        m_characterAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void RunToEnemy()
    {
        m_characterAgent.speed = 8;
        m_characterAgent.destination = Vector3.zero;
    }

    public void BaseAttack(Character enemy)
    {

    }
}
