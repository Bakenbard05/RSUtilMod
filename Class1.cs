using UnityEngine;
// MOD
namespace RSM
{
    public class Loader
    {
        public GameObject Load;
        public Loader Init()
        {
            Loader ret = new Loader();
            ret.Load = new GameObject();
            ret.Load.AddComponent<RSUtilMod>();
            GameObject.DontDestroyOnLoad(ret.Load);
            return ret;
        }
    }
    public class RSUtilMod : RSMod
    {
        public RSMod[] mods;
        public void Start()
        {
            name = "RSUtilMod";
        }
        public void OnGUI()
        {
            if (this == null) return;
            float buttonWidth = 200;
            float buttonHeight = 50;
            float buttonX = (Screen.width / 2) - (buttonWidth / 2);
            float buttonY = (Screen.height / 2) - (buttonHeight / 2);
            mods = GameObject.FindObjectsByType<RSMod>(FindObjectsSortMode.InstanceID);
            if (GUI.Button(new Rect(buttonX + 200f, buttonY, buttonWidth, buttonHeight), "Kill"))
            {
                Cleanup();
            }
            if(mods.Length != 0)
            {
                for (int i = 0; i < mods.Length; i++)
                {
                    if(GUI.Button(new Rect(buttonX + 400f, buttonY + i * 60, buttonWidth, buttonHeight), $"KILL {mods[i].GetComponent<RSMod>().name}"))
                    {
                        mods[i].GetComponent<RSMod>().Cleanup();
                    }
                }
            }
            Services.Console.Write(mods.Length.ToString());
        }

    }

}
