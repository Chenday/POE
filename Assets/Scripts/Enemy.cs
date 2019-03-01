using UnityEngine;
using System.Collections;

[AddComponentMenu("POE/Enemy")]
public class Enemy : MonoBehaviour {

    // 准备时间
    public float m_readyTime = 1.0f;

    // 移动速度
    public float m_speed = 3.0f;

    // 旋转速度
    public float m_rotSpeed = 30f;

    // 变向间隔时间
    protected float m_timer = 2.0f;

    protected Transform m_transform;


	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
        if(m_readyTime >= 0)
        {
            m_readyTime -= Time.deltaTime;
            return;
        }

        UpdateMove();
	}

    public void UpdateMove()
    {
        m_timer -= Time.deltaTime;
        if(m_timer <= 0)
        {
            m_timer = Random.Range(1.0f, 4.0f);

            m_rotSpeed = -m_rotSpeed;
        }

        m_transform.Rotate(Vector3.up, m_rotSpeed * Time.deltaTime, Space.World);

        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }
}
