using UnityEngine;

namespace MaskDudeFruitCollecter.Droppables
{
    public interface IDroppable
    {
        public void Drop(Vector3 position, float dropForce, Vector2 dropDirection);
    
        public int GetTotalPrice();
    }
}
