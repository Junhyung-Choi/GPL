using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    public int herolevel = 0;
    public int heroexp = 0;
    public int offenselevel = 0;
    public Dictionary<string, int> offensetree = new Dictionary<string, int>{{"damage", 0}, {"accuracy", 0}, {"rate", 0}};
    public int defenselevel = 0;
    public Dictionary<string, int> defensetree = new Dictionary<string, int>{{"health", 0}, {"armor", 0}, {"healrate", 0}};
    public int utilitylevel = 0;
    public Dictionary<string, int> utilitytree = new Dictionary<string, int>{{"reward", 0}, {"dodge", 0}, {"critical", 0}};
    public int gunshoplevel = 0;
    public int relicshoplevel = 0;

}