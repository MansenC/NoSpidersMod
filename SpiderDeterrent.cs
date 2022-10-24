using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoSpidersMod
{
    public class SpiderDeterrent : MonoBehaviour
    {
        private List<GameObject> _deactivatedObjects = new List<GameObject>();
        
        private void Awake()
        {
            StartCoroutine(CheckScene());
        }

        private IEnumerator CheckScene()
        {
            var fgSpiders = GameObject.Find("fg_spiders");
            if (fgSpiders != null)
            {
                fgSpiders.SetActive(false);
                _deactivatedObjects.Add(fgSpiders);
            }

            foreach (var childActivator in FindObjectsOfType<ActivateChildrenOnContact>())
            {
                if (!childActivator.name.ToLower().Contains("spider"))
                {
                    continue;
                }

                childActivator.gameObject.SetActive(false);
                _deactivatedObjects.Add(childActivator.gameObject);
            }

            yield break;
        }

        private void OnDisable()
        {
            foreach (var obj in _deactivatedObjects)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }
        }
    }
}