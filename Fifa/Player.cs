using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifa
{
    class Player
    {
        public Int16 num;
        public String name, position;
        public Int16 teamId;

        public Player(Int16 num, String name, String position, Int16 teamId) {
            this.num = num;
            this.name = name;
            this.position = position;
            this.teamId = teamId;
        }
    }
}
