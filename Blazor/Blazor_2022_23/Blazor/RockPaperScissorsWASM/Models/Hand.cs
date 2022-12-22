using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissorsWASM.Models
{
    public class Hand
{
        //ono što je igrač odabrao
        public OptionRPS Selection { get; set; }
        //koga pobjeđuje s odabranim
        public OptionRPS WinsAgainst  { get; set; }
        //od čega gubi s odabranim
        public OptionRPS LosesAgainst { get; set; }
        public string Image;

        //izračunavanje rezultata
        public GameStatus PlayAgainst(Hand opponentHand)
        {
            if (Selection == opponentHand.Selection) return GameStatus.Draw;
            if (LosesAgainst == opponentHand.Selection) return GameStatus.Loss;
            return GameStatus.Victory;
        }
    }
}
