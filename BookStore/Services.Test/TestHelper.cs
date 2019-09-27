using System;

namespace Services.Test
{
    public static class TestHelper
    {
        public static int GetRandomNumber()
        {
            return new Random().Next(1, 99999);
        }
    }
}