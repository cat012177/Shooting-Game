using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //������� �Է��� �޾Ƽ� �̵��ϰ� �ʹ�.
        //1.������� �Է¿� ����
        //-�¿� �Է¹ޱ�,AD
        //����Ű�� ������ -1, ������Ű�� ������ +1
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //2.������ �ʿ�
        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;
    }
}
