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
        //ĳ���� ���� ������Ʈ


        

        DisplayStatus();
    }

    public void DisplayStatus() {
        
    }
}
