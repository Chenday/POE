using UnityEngine;
using System.Collections;

[AddComponentMenu("POE/Player")]
public class Player : MonoBehaviour {

    //
    public float m_speed = 1;

    public float m_rocketRate = 0.5f;

    public Transform m_rocket;

    protected Transform m_transform;
    // Use this for initialization
    void Start () {
        m_transform = this.transform;
	}

    // Update is called once per frame
    void Update() {

        //纵向移动距离
        float movev = 0;

        // 横向移动距离
        float moveh = 0;

        // 按上键
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movev -= m_speed * Time.deltaTime;
        }

        // 按下键
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movev += m_speed * Time.deltaTime;
            Debug.Log("----------->>" + movev);
        }

        // 按左键
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveh += m_speed * Time.deltaTime;
        }

        // 按右键
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveh -= m_speed * Time.deltaTime;
        }

        // 移动
        this.transform.Translate(new Vector3(moveh, 0, movev));

        m_rocketRate -= Time.deltaTime;
        if(m_rocketRate <= 0)
        {
            m_rocketRate = 0.5f;

            // 创建子弹
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                Instantiate(m_rocket, m_transform.position, m_transform.rotation);
            }

        }
        
	}
}
