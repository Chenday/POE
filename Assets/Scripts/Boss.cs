using UnityEngine;
using System.Collections;

[AddComponentMenu("POE/Boss")]
public class Boss : Enemy {

    public Transform m_rocket;

    protected float m_fTimer = 1.0f;

    protected Transform m_player;

    void Awake()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if(obj != null)
        {
            m_player = obj.transform;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void UpdateMove()
    {
        m_fTimer -= Time.deltaTime;
        if(m_fTimer <= 0)
        {
            m_fTimer = 1.0f;

            if(m_player != null)
            {
                Vector3 relativePos = m_transform.position - m_player.position;
                Instantiate(m_rocket, m_transform.position, Quaternion.LookRotation(relativePos));
            }
        }

        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }
}
