using System;
using Oculus.Interaction;
using UnityEngine;

namespace UI
{
    public class GUIObject : MonoBehaviour
    {
        [SerializeField] private Transform head;
        [SerializeField] private float spawnDistance = 2;

        private Cylinder cylinder;

        private void Start()
        {
            cylinder = GetComponent<Cylinder>();
            
            AdjustChildrenPosition();
        }

        private void AdjustChildrenPosition()
        {
            foreach (var child in transform.GetComponentsInChildren<Transform>())
            {
                if (child.parent != transform) continue;
                
                var position = child.position;
                position = new Vector3(position.x, position.y, cylinder.Radius);
                child.position = position;
            }
        }

        protected void Update()
        {
            transform.LookAt(new Vector3(head.position.x, transform.position.y, head.position.z));
        }


    }
}