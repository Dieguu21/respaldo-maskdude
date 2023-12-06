using UnityEngine;

namespace MaskDudeFruitCollecter.Menus.LevelMenus
{
    public interface MenuMediator
    {
        public void NotifyButtonPressed(GameObject menuWhereButtonWasPressed, string actionToDo);
    }
}