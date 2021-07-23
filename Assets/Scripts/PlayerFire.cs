using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//사용자가 발사버튼을 누르면 총알 발사
//필요속성: 총알공장, 총구

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject firePosition;

   
    public int poolSize = 10;
    [HideInInspector]
    public static List<GameObject> bulletObjectPool=new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<poolSize;i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }
#if UNITY_ANDROID
    GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
       GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {

        //사용자가 발사버튼을 눌렀기 때문
        //->만약 사용자가 버튼을 누르면, 총알이 위로 나감.
#if UNITY_STANDALONE
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif
    }

    public void Fire()
    {
        Debug.Log("count : " + bulletObjectPool.Count);
        if (bulletObjectPool.Count > 0)
        {
            GameObject bullet = bulletObjectPool[0];
            bulletObjectPool.RemoveAt(0);
            bulletObjectPool.Add(bullet);
            bullet.SetActive(true);
            bullet.transform.position = firePosition.transform.position;
        }
    }
}
