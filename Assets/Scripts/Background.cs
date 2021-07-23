using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�ʿ� �Ӽ�: ��ũ�� �ӵ�, ���͸���
public class Background : MonoBehaviour
{
    public float scrollSpeed = 0.2f;
    public Material bgMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��� ��ũ���� �ǵ��� �ϰ�ʹ�
        //1.������ �ʿ�.
        Vector2 direction = Vector2.up;
        //2.��ũ���� �ǰ� �ϰ� �ʹ�.
        //P=P0+vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
       
    }
}
