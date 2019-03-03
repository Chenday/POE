using UnityEngine;
using System.Collections;

[AddComponentMenu("POE/Player")]
public class Player : MonoBehaviour {

    //
    public float m_speed = 1;

    public float m_rocketRate = 0.5f;
    protected float m_rRate;

    // 声音
    public AudioClip m_shootClip;

    // 声音源
    protected AudioSource m_audio;

    // 爆炸特效
    public Transform m_explosionFx;

    public int m_life;

    public Transform m_rocket;

    protected Transform m_transform;
    // Use this for initialization
    void Start () {
        m_transform = this.transform;
        m_rRate = m_rocketRate;

        m_audio = this.audio;
	}

    // Update is called once per frame
    void Update() {

        //纵向移动距离
        float movev = 0;

        // 横向移动距离
        float moveh = 0;

        // 按上键
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if(this.transform.position.z <= 10)
            {
                movev -= m_speed * Time.deltaTime;
            }
            
        }

        // 按下键
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if(this.transform.position.z >= -19)
            {
                movev += m_speed * Time.deltaTime;
            }
            
            Debug.Log("----------->>" + movev);
        }

        // 按左键
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveh += m_speed * Time.deltaTime;
        }

        // 按右键
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveh -= m_speed * Time.deltaTime;
        }

        // 移动
        this.transform.Translate(new Vector3(moveh, 0, movev));

        m_rRate -= Time.deltaTime;
        if(m_rRate <= 0)
        {
            m_rRate = m_rocketRate;

            // 创建子弹
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                Instantiate(m_rocket, m_transform.position, m_transform.rotation);

                // 播放射击声音
                m_audio.PlayOneShot(m_shootClip);
            }

        }
        
	}

    void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Enemy"))
         {
            Instantiate(m_explosionFx, m_transform.position, m_transform.rotation);
             Destroy(this.gameObject);
         }

        if (other.CompareTag("EnemyRocket"))
        {
            Instantiate(m_explosionFx, m_transform.position, m_transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
