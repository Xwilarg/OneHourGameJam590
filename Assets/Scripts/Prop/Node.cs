using UnityEngine;

namespace OneHourGameJam.Prop
{
    public class Node : MonoBehaviour
    {
        public Node NextNode;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            if (NextNode != null) Gizmos.DrawLine(transform.position, NextNode.transform.position);
        }
    }
}
