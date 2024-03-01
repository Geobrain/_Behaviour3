using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public static partial class DataBase
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void SetupPlayerDataBase()
    {
        Role.LoadGunner();
        Role.LoadEngineer();
    }

    internal static class Role
    {
        public static Data Gunner;
        public static Data Engineer;

        public static void LoadGunner()
        {
            var data = Gunner = new Data();
            
            var dataMotion = data.Add<DataMotion>();
            dataMotion.speedWalk = 10;
            dataMotion.speedRun  = 20;
            dataMotion.speedRush = 30;
            
            var dataBehaviors = data.Add<PlayerDataBehaviors>();
            dataBehaviors.behaviors.Add(new Player_inputQ());
            dataBehaviors.behaviors.Add(new Player_inputW());
        }
        
        public static void LoadEngineer()
        {
            var data = Engineer = new Data();
            
            var dataMotion = data.Add<DataMotion>();
            dataMotion.speedWalk = 35;
            dataMotion.speedRun  = 80;
            dataMotion.speedRush = 100;
            
            var dataBehaviors = data.Add<PlayerDataBehaviors>();
            dataBehaviors.behaviors.Add(new Player_inputQ());
            dataBehaviors.behaviors.Add(new Player_inputW());
        }
    }

}
