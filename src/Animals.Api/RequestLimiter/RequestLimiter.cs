using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Animals.Api.RequestLimiterSpace
{
    public class RequestLimiter
    {
        private static RequestLimiter _instance;
        private  long requestCount = 0;
        private  DateTime latestRequestTime = DateTime.Now;
        private  int timeLimit = 5000;
        private  int requestLimit = 2;

        public RequestLimiter(int time, int count)
        {
            latestRequestTime = DateTime.Now;
            timeLimit = time;
            requestLimit = count;
        }

        public bool Count() {

            var diffTime = DateTime.Now - latestRequestTime;
            var diffTimeNum = (int)diffTime.TotalMilliseconds;

            if (diffTimeNum > timeLimit)
            {
                latestRequestTime = DateTime.Now;
                requestCount = 0;
            }

            requestCount++;

            if (requestLimit < requestCount && diffTimeNum < timeLimit)
            {
                return true;
            }

            return false;
        }

        public static RequestLimiter GetInstance(int time, int count)
        {
            if (_instance == null)
            {
                _instance = new RequestLimiter(time, count);
            }

            return _instance;
        }
    }
}
