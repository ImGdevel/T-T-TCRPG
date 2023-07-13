using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacterManager : MonoBehaviour
{
    [SerializeField] List<Character> original_player;
    [SerializeField] List<Character> original_enemy;


    [SerializeField] List<Character> player;
    [SerializeField] List<Character> enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        //Test Code

        //

        foreach (Character p in original_player) {
            player.Add(p.Clone());
        }

        foreach (Character e in original_enemy) {
            enemy.Add(e.Clone());
        }
    }

    

    
}
