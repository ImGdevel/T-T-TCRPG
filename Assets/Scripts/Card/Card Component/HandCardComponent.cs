using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandCardComponent : CardComponent
{
    private HandManager handManager; // 핸드 메니저
    private PRS originPosition; // 원래 Transform 위치
    private int originSortingLayer; // 원래 카드 번호

    protected bool activeHandOverAni = true; // 카드 애니메이션 작동 여부
    protected bool isSelected = false; // 카드 선택 여부
    protected bool isUseable = false;

    public bool IsSelected { get { return isSelected; } }
    public bool IsUsable { get { return isUseable; } }

    public bool IsCardEnabled {
        set { isMouseClick = value; }
        get { return isMouseClick; }
    } // 카드 활성화 여부

    private void Start() {
        isMouseOver = true;
        IsCardEnabled = true;
        isSelected = false;
    }

    private void Update() {
        if (!isSelected) return;
        
        // 카드 선택 동작 처리
        if (Input.GetMouseButton(1)) {
            // 카드를 놓음
            UnselectCard();
        }
        else {
            // 마우스 위치에 카드 이동
            this.transform.position = Utills.MousePointer;
        }

    }

    /// <summary>
    /// HandManager에 속한 카드로 설정합니다.
    /// </summary>
    /// <param name="parent">속할 HandManager</param>
    public void SetParent(HandManager parent) {
        if (this.handManager == null)
            this.handManager = parent;
    }

    /// <summary>
    /// 원래 위치를 설정합니다.
    /// </summary>
    /// <param name="origin">원래 위치 정보</param>
    public void SetOriginPosition(PRS origin) {
        this.originPosition = origin;
    }

    /// <summary>
    /// 원래 Sorting Layer를 설정합니다.
    /// </summary>
    /// <param name="origin">원래 Sorting Layer 값</param>
    public void SetOriginSortingLayer(int origin) {
        this.originSortingLayer = origin;
    }

    /// <summary>
    /// 마우스가 카드에 들어갈 때 호출되는 메서드
    /// </summary>
    protected override void OnMouseEnter() {
        if (!isMouseOver || !activeHandOverAni || isSelected) return;

        ZoomCard();
    }

    /// <summary>
    /// 마우스가 카드에서 벗어날 때 호출되는 메서드
    /// </summary>
    protected override void OnMouseExit() {
        if (!isMouseOver || !activeHandOverAni || isSelected) return;

        MoveTransform(originPosition, true, 0.1f);
        SortingCardLayers(originSortingLayer);
    }

    /// <summary>
    /// 마우스로 카드를 클릭했을 때 호출되는 메서드
    /// </summary>
    protected override void OnMouseDown() {
        if (!isMouseClick) return;

        if (!isSelected && !handManager.isCardSelected) {
            // 핸드에서 선택
            isSelected = true;
            this.transform.localScale = Vector3.one;
            handManager.SelectCard(this.gameObject);
        } else if(isUseable) {
            // 카드사용
            UseCard();
        }
        else {
            //카드 미사용
            UnselectCard();
        }
    }

    /// <summary>
    /// 카드를 확대합니다.
    /// </summary>
    protected void ZoomCard() {
        Vector3 pos = new Vector3(transform.position.x, transform.parent.position.y + 1, -5);
        PRS prs = new PRS(pos, Quaternion.identity, Vector3.one * 1.3f);
        MoveTransform(prs, true, 0.1f);
        SortingCardLayers(100);
    }

    


    /// <summary>
    /// 카드 선택 해제
    /// </summary>
    protected virtual void UnselectCard() {
        isSelected = false;
        handManager.isCardSelected = false;
        MoveTransform(originPosition, true, 0.1f);
        SortingCardLayers(originSortingLayer);
    }

    /// <summary>
    /// 카드 사용
    /// </summary>
    protected virtual void UseCard() {
        // 지정된 타겟에게 효과를 부여한다.
        isSelected = false;
        handManager.isCardSelected = false;
        handManager.UseCardRemove(this.gameObject);
    }

    /// <summary>
    /// 카드 사용 활성화
    /// </summary>
    public void EnableCard() {
        IsCardEnabled = true;
        // 카드 사용 활성화 애니메이션
    }

    /// <summary>
    /// 카드 사용 비활성화
    /// </summary>
    public void DisableCard() {
        IsCardEnabled = false;
        // 카드 사용 비 활성화 애니메이션

        Vector3 pos = new Vector3(transform.position.x, transform.parent.position.y - -0.5f, transform.position.z);
        PRS prs = new PRS(pos, transform.rotation, transform.localScale);
        MoveTransform(prs, true, 0.1f);
        SortingCardLayers(100);
    }

}