using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSlotContainerComponent: MonoBehaviour
{
    private List<BuffSlot> buffSlots;

    [SerializeField] GameObject buffSlotPrefeb; //슬롯 프리펩
    [SerializeField] float containerWidth;      // 슬롯 컨테이너의 가로 길이
    [SerializeField] float slotCount;           // 슬롯 갯수
    [SerializeField] float slotSize;      // 슬롯의 가로 세로 길이
    [SerializeField] float slotGap;            // 슬롯 간의 간격
    

    public void Start() {
        buffSlots = new List<BuffSlot>();
        AddSlotAndSetSlotPosition();
    }

    public void AddSlotAndSetSlotPosition() {
        // 슬롯의 가로 개수 계산
        int slotsPerRow = Mathf.FloorToInt(containerWidth / (slotSize + slotGap));

        // 버프 슬롯을 생성하고 위치 설정
        int slotIndex = 0;
        for (int row = 0; row < Mathf.CeilToInt(slotCount / (float)slotsPerRow); row++) {
            for (int col = 0; col < slotsPerRow; col++) {
                if (slotIndex >= slotCount)
                    break;

                GameObject newBuffSlotObj = Instantiate(buffSlotPrefeb, transform);
                float slotXPosition = -containerWidth / 2f + (col * (slotSize + slotGap));
                float slotYPosition = containerWidth / 2f - (row * (slotSize + slotGap));
                newBuffSlotObj.transform.localPosition = new Vector3(slotXPosition, slotYPosition, 0f);
                BuffSlot newBuffSlot = newBuffSlotObj.GetComponent<BuffSlot>();
                buffSlots.Add(newBuffSlot);

                slotIndex++;
            }
        }
    }

    public void UpdateStatus(Character character) {
        //캐릭터 상태 업데이트
        List<Buff> characterbuffs = character.buffs;
        
        for (int index = 0; index < buffSlots.Count; index++) {

            if( index >= characterbuffs.Count) {
                buffSlots[index].SlotUnactive();
                buffSlots[index].UpdateStatus(characterbuffs[index]);
            }
            else {
                buffSlots[index].SlotUnactive();
            }
        }
    }

    public void DisplayStatus() {
        foreach (BuffSlot item in buffSlots) {
            item.DisplayStatus();
        }
    }
}
