using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] Sprite frontbackground;  // 카드 앞면 배경
    [SerializeField] Sprite backbackground;   // 카드 뒷면 배경
    [SerializeField] Renderer tcgimage;         // 카드 이미지


    public TextMesh cardname;       // 카드 이름
    public TextMesh description;    // 카드 설명


    // Start is called before the first frame update
    void Start()
    {
        SetOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //레이어 순서 지정
    public void SetOrder() 
    {



    }
}
