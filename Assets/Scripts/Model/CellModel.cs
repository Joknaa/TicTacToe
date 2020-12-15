using UnityEngine;

namespace Model
{
    public class CellModel : MonoBehaviour
    {
        public bool CellIsEmpty = true;


        public void SetCellFull()
        {
            CellIsEmpty = false;
        }

        public bool GetCellIsEmpty()
        {
            return CellIsEmpty;
        }
    }
}