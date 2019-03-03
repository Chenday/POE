using UnityEngine;
using System.Collections;

[AddComponentMenu("POE/Enemy")]
public class Enemy : MonoBehaviour {

    // 移动速度
    public float m_speed = 3.0f;

    // 旋转速度
    public float m_rotSpeed = 30f;

    // 获得分数
    public int m_point = 1;

    public int m_flood = 2;

    // 变向间隔时间
    protected float m_timer = 1.5f;

    protected Transform m_transform;
    public Transform m_explosionFx;


	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	
	}
	
	// Update is called once per frame
	void Update () {

        UpdateMove();
	}

    public virtual void UpdateMove()
    {
        m_timer -= Time.deltaTime;
        if(m_timer <= 0)
        {
            m_timer = 3f; ///Random.Range(1.0f, 2.0f);

            m_rotSpeed = -m_rotSpeed;
        }

        m_transform.Rotate(Vector3.up, m_rotSpeed * Time.deltaTime, Space.World);

        //moveh -= m_speed * Time.deltaTime;
        m_transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag.CompareTo("Player") == 0)
        {
            Destroy(this.gameObject);
            return;
        }

        if(other.tag.CompareTo("PlayerRocket") == 0)
        {
            m_flood -= 1;
            if(m_flood <= 0)
            {
                GameManager.instance.AddScore(m_point);

                Instantiate(m_explosionFx, m_transform.position, Quaternion.identity);

                Destroy(this.gameObject);
            }
        }

        if(other.CompareTag("Bound"))
        {
            Destroy(this.gameObject);
            return;
        }
    }
}
