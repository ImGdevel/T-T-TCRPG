using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSlotContainerComponent: MonoBehaviour
{
    private List<BuffSlot> buffSlots = new List<BuffSlot>();

    [SerializeField] GameObject buffSlotPrefeb; //슬롯 프리펩
    [SerializeField] float containerWidth;      // 슬롯 컨테이너의 가로 길이
    [SerializeField] float slotCount;           // 슬롯 갯수
    [SerializeField] float slotSize;      // 슬롯의 가로 세로 길이
    [SerializeField] float slotGap;            // 슬롯 간의 간격

    public void Start() {
        AddSlotAndSetSlotPosition();
    }

    public void AddSlotAndSetSlotPosition() {
        int slotsPerRow = Mathf.FloorToInt(containerWidth / (slotSize + slotGap));

        int slotIndex = 0;
        for (int row = 0; row < Mathf.CeilToInt(slotCount / (float)slotsPerRow); row++) {
            for (int col = 0; col < slotsPerRow; col++) {
                if (slotIndex >= slotCount)
                    break;

                GameObject newBuffSlotObj = Instantiate(buffSlotPrefeb, transform);
                float slotXPosition = -(containerWidth + slotGap) / 2f + (col * (slotSize + slotGap));
                float slotYPosition = 0 - (row * (slotSize + slotGap));

                newBuffSlotObj.transform.localScale = newBuffSlotObj.transform.localScale * slotSize;
                newBuffSlotObj.transform.localPosition = new Vector3(slotXPosition, slotYPosition, 0f);
                BuffSlot newBuffSlot = newBuffSlotObj.GetComponent<BuffSlot>();
                buffSlots.Add(newBuffSlot);

                slotIndex++;
            }
        }

        // 슬롯을 가운데 정렬로 변경
        if (buffSlots.Count > 0) {
            float totalWidth = slotsPerRow * (slotSize + slotGap) - slotGap;
            foreach (BuffSlot slot in buffSlots) {
                Vector3 slotPosition = slot.transform.localPosition;
                slotPosition.x += (containerWidth - totalWidth) / 2f;
                slot.transform.localPosition = slotPosition;
            }
        }
    }

    public void UpdateStatus(Character character) {
        //캐릭터 상태 업데이트
        List<Buff> characterBuffs = new List<Buff>(character.BuffList); // 버프 리스트를 복사하여 가져오기

        for (int index = 0; index < buffSlots.Count; index++) {
            if( index < characterBuffs.Count) {
                buffSlots[index].SlotUnactive();
                buffSlots[index].UpdateStatus(characterBuffs[index]);
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
