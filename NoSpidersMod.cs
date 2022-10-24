using System.Collections.Generic;
using Modding;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NoSpidersMod
{
    public class NoSpidersMod : Mod, ITogglableMod, IMod, Modding.ILogger
    {
        public static NoSpidersMod Instance { get; private set; }

        private GameObject _currentSpiderDeterrent;

        public NoSpidersMod()
            : base(null)
        {
            Instance = this;
        }

        public override string GetVersion()
        {
            return "1.0.0";
        }

        public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
        {
            UnityEngine.SceneManagement.SceneManager.activeSceneChanged += (Scene old, Scene @new) =>
            {
                if (!@new.name.StartsWith("Deepnest"))
                {
                    return;
                }

                _currentSpiderDeterrent = new GameObject("SpiderDeterrent");
                _currentSpiderDeterrent.AddComponent<SpiderDeterrent>();
            };
        }

        public void Unload()
        {
            if (_currentSpiderDeterrent != null)
            {
                GameObject.Destroy(_currentSpiderDeterrent);
            }
        }
    }
}
