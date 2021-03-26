using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace AsyncHttpContext
{
    public static class MyStaticSessionWrapper
    {
        private const string CounterKey = "MyCounter";
        private static HttpSessionState Session => HttpContext.Current.Session;

        public static int Counter
        {
            get => (int)(Session[CounterKey] ?? 0);
            set => Session[CounterKey] = value;
        }
    }

    public class MySessionWrapper
    {
        private const string CounterKey = "MyCounter";
        private readonly HttpSessionStateBase session;

        public MySessionWrapper(HttpSessionStateBase session)
        {
            this.session = session;
        }

        public int Counter
        {
            get => (int)(session[CounterKey] ?? 0);
            set => session[CounterKey] = value;
        }
    }

    public static class MySessionExtensions
    {
        private const string CounterKey = "MyCounter";

        public static int GetCounter(this HttpSessionStateBase session)
            => (int)(session[CounterKey] ?? 0);

        public static void SetCounter(this HttpSessionStateBase session, int count)
            => session[CounterKey] = count;
    }
}