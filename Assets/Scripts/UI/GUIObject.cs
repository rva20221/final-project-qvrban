using System;
using UnityEngine;

namespace UI
{
    public class GUIObject : MonoBehaviour
    {
        [SerializeField] private Transform head;
        [SerializeField] private float spawnDistance = 2;

        protected virtual void Update()
        {
            FollowHead();
        }

        private void FollowHead()
        {
            transform.position =
                head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
            
            transform.LookAt(new Vector3(head.position.x, transform.position.y, head.position.z));
            transform.forward *= -1;
        }
        
        
    }
}