using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ��� �̵�
//�ʿ�Ӽ�: �ӵ�
public class Bullet : MonoBehaviour
{
    //�ʿ�Ӽ�: �ӵ�
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���� ��� �̵�
        //p=p0+vt
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
