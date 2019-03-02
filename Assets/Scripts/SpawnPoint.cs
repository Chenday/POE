﻿using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

    public Transform m_spawnObject;

    public float m_minSpawnTime = 1.0f;

    public float m_maxSpawnTime = 5.0f;

    protected Transform m_traceform;

    protected float m_limitTime = 0f;



	// Use this for initialization
	void Start () {
        m_limitTime = Random.Range(m_minSpawnTime,m_maxSpawnTime);

        m_traceform = this.transform;
	
	}
	
	// Update is called once per frame
	void Update () {

        m_limitTime -= Time.deltaTime;
        if(m_limitTime <= 0)
        {
            m_limitTime = Random.Range(m_minSpawnTime, m_maxSpawnTime);
            Instantiate(m_spawnObject, m_traceform.position, m_traceform.rotation);
        }
	}
}
