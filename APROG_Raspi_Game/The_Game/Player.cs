using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game {
    public class Player {
        public Player(string Name, int Points) {
            this.Name = Name;
            this.Points = Points;
            
        }
        public string Name { get; private set; }
        public int Points { get; set; }
    }
}
