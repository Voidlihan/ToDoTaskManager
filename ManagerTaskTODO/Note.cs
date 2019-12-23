using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerTaskTODO
{
    public class Note : Entity
    {
        public string Text { get; set; }
        public bool Actuality { get; set; }
    }
}
