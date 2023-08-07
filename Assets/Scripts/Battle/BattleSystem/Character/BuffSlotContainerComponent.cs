using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSlotContainer: MonoBehaviour
{
    private List<BuffData> buffs;


    [SerializeField] int slotSize;
   


    public void Start() {
        buffs = new List<BuffData>();
    }

    public void UpdateStatus(Character character) {
        //캐릭터 상태 업데이트


        

        DisplayStatus();
    }

    public void DisplayStatus() {
        
    }
}
