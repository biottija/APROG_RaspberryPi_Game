using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Game {
    public class PlayerHandler {
        //reads the players form the file and returns a list of players
        public static List<Player> LoadPlayer(string filePath) {
            var list = new List<Player>();
            if (!File.Exists(filePath)) {
                return list; //if the file doesnt exist return empty list
            }
            FileStream FsGet = new FileStream(filePath, FileMode.Open);
            StreamReader ScoreStreamRead = new StreamReader(FsGet);
            string line = ".";
            string[] parts = new string[2];
            line = ScoreStreamRead.ReadLine();
            while (line != null) {
                parts = line.Split(';');
                int.TryParse(parts[1], out int points);
                Player p = new Player(parts[0], points);
                list.Add(p);
                line = ScoreStreamRead.ReadLine();
            }
            ScoreStreamRead.Close();
            return list;
        }
        //writes a list of players in a file
        //!!Overwrites existing file!!
        private static void SavePlayer(string filePath, List<Player> lst) {
            FileStream FsOut = new FileStream(filePath, FileMode.Create);
            StreamWriter ScoreStreamWrite = new StreamWriter(FsOut);
            foreach (Player p in lst) {
                ScoreStreamWrite.WriteLine($"{p.Name};{p.Points}");
            }
            ScoreStreamWrite.Close();
        }
        //Adds player or changes his points if he already exists
        public static void Handle(Player player, string filePath) {
            var list = new List<Player>();
            list = LoadPlayer(filePath);
            bool exists = false;
            foreach (Player p in list) {
                if (p.Name == player.Name) {
                    exists = true;
                    if (p.Points > player.Points) {
                        p.Points = player.Points;
                    }
                }
            }
            if (!exists) {
                list.Add(player);
            }
            SavePlayer(filePath, list);

        }
    }
}
