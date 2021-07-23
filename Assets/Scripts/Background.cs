using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//필요 속성: 스크롤 속도, 매터리얼
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
        //배경 스크롤이 되도록 하고싶다
        //1.방향이 필요.
        Vector2 direction = Vector2.up;
        //2.스크롤이 되게 하고 싶다.
        //P=P0+vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
       
    }
}
