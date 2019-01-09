using Lottery.Data.Interfaces;
using Lottery.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Data
{
    public class DrawRepository : IDrawRepository
    {
        private LotteryContext context = new LotteryContext();

        public DrawRepository(LotteryContext context)
        {
            this.context = context;
        }

        public IList<Draw> Find(int lotteryGameId, DateTime? fromDate, DateTime? untilDate)
        {
            var draws = context.Draws.Where(s => (fromDate.HasValue && untilDate.HasValue) ? s.LotteryGameId == lotteryGameId : (s.LotteryGameId == lotteryGameId) && ((fromDate != null && s.Date >= fromDate || untilDate != null && s.Date <= untilDate))).DefaultIfEmpty().ToList();

            return draws;
        }

        public void Add(Draw draw)
        {
            
            Draw newDraw = draw;
            if (newDraw.DrawNumbers == null || !newDraw.DrawNumbers.Any())
            {
                throw new ArgumentException();
            }
            else
            {
                context.Draws.Add(newDraw);
                context.SaveChanges();
            }
        }
    }
}