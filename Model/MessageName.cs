using UnityEngine;

namespace Geekbrains
{
    public class MessageName : BaseObjectScene, ISelectedObj
    {
        public string GetMessage()
        {
            return Name;
        }
    }
}
