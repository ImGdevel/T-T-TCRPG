using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager
{
    private Character user;
    private List<Character> target;

    public Character User { get; }
    public List<Character> Target { get; }

    public void SetUser(Character user) {
        this.user = user;
    }

    public void SetTarget(List<Character> target) {
        this.target = target;
    }
}
