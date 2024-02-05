using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Classes
{
    internal class GameManager
    {
        private int _nextPCMove;
        private int _currentPlayerMove;
        private string _nextPCResult;

        string HMAC;
        HMACGenerator hMACGenerator;
        GameRules gameRules;
        Random random;

        public GameManager(string[] values)
        {
            random = new Random(Environment.TickCount);
            gameRules = new GameRules(values);
            _nextPCMove = random.Next(0, gameRules.valuesAmount);
            _nextPCResult = gameRules.gameValues[_nextPCMove];

            hMACGenerator = new HMACGenerator();
            HMAC = hMACGenerator.GenerateHMAC(_nextPCResult);
        }
        public void ShowHMAC()
        {
            Console.WriteLine($"HMAC: {HMAC}");
        }
        public void ShowHMACKey()
        {
            Console.WriteLine($"HMAC Key: {hMACGenerator.GetHMACKey()}");
        }
        public void ShowMenu()
        {
            Console.WriteLine("Available moves:");
            gameRules.ShowGameValues();
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }
        public bool SelectMenu(string move)
        {
            int intMove = 0;
            if (move != "?" && (!int.TryParse(move, out intMove) || intMove > gameRules.valuesAmount || intMove < 0))
            {
                Console.Write("Wrong input value! Try again!\nEnter your move: ");
                return false;
            }
            switch (move)
            {
                case "?":
                    gameRules.DrawHelpTable();
                    break;
                case "0":
                    break;
                default:
                    PlayRound(intMove);
                    ShowHMACKey();
                    break;
            }
            ResetGame();
            return true;
        }
        private void PlayRound(int playerMove)
        {
            _currentPlayerMove = playerMove - 1;
            Console.WriteLine($"Your move: {gameRules.GetGameValue(_currentPlayerMove)}");
            Console.WriteLine($"Computer move: {gameRules.GetGameValue(_nextPCMove)}");
            Console.WriteLine("Game result: " + gameRules.GetGameResult(_currentPlayerMove, _nextPCMove));
        }
        private void ResetGame()
        {
            _nextPCMove = random.Next(0, gameRules.valuesAmount);
            _nextPCResult = gameRules.gameValues[_nextPCMove];
            hMACGenerator = new HMACGenerator();
            HMAC = hMACGenerator.GenerateHMAC(_nextPCResult);
        }

    }
}
