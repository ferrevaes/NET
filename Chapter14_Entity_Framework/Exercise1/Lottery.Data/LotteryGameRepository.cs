using System.Collections.Generic;
using System.Linq;
using Lottery.Data.Interfaces;
using Lottery.Domain;

namespace Lottery.Data
{
    public class LotteryGameRepository : ILotteryGameRepository
    {
        private LotteryContext context = new LotteryContext();

        public LotteryGameRepository(LotteryContext context)
        {
            this.context = context;
        }

        public IList<LotteryGame> GetAll()
        {
            var lotterygames = context.LotteryGames.ToList();
            return lotterygames;
        }
    }
}