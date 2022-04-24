using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    public int herolevel = 0;
    public int offenselevel = 0;
    // public new Dictionary<string, int> offensetree = {{"damage", 0}, {"accuracy", 0}, {"rate", 0}};
    public int defenselevel = 0;
    // public new Dictionary<string, int> defensetree = {{"health", 0}, {"armor", 0}, {"healrate", 0}};
    public int utilitylevel = 0;
    // public new Dictionary<string, int> utilitytree = {{"reward", 0}, {"dodge", 0}, {"critical", 0}};
    public int gunshoplevel = 0;
    public int relicshoplevel = 0;
}
