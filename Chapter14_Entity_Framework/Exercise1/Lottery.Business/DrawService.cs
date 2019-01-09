using System;
using System.Collections;
using System.Collections.Generic;
using Lottery.Business.Interfaces;
using Lottery.Data;
using Lottery.Data.Interfaces;
using Lottery.Domain;

namespace Lottery.Business
{
    public class DrawService : IDrawService
    {
        private IDrawRepository drawRepository;

        public DrawService(IDrawRepository drawRepository)
        {
            this.drawRepository = drawRepository;
        }

        public void CreateDrawFor(LotteryGame lotteryGame)
        {
            Draw newDraw = new Draw()
            {
                LotteryGameId = lotteryGame.Id,
                LotteryGame = lotteryGame,
                Date = DateTime.Now
            };
            
            int number;
            ArrayList checkNumbers = new ArrayList();
            IList<DrawNumber> numbers = new List<DrawNumber>();
            for (int i = 1; i <= lotteryGame.NumberOfNumbersInADraw; i++)
            {
                Random rnd = new Random();
                number = rnd.Next(1, lotteryGame.MaximumNumber);
                if (checkNumbers.Contains(number))
                {
                    do
                    {
                        number = rnd.Next(1, lotteryGame.MaximumNumber);
                    } while (checkNumbers.Contains(number));

                    checkNumbers.Add(number);
                }
                else
                {
                    checkNumbers.Add(number);
                }

                var nummer = new DrawNumber(){DrawId = i, Number = number, Position = i};
                numbers.Add(nummer);
            }

            newDraw.DrawNumbers = numbers;

            drawRepository.Add(newDraw);
        }
    }
}
