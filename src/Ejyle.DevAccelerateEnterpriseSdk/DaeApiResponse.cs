﻿namespace Ejyle.DevAccelerate.Enterprise
{
    public class DaeApiResponse<T>
    {
        public T Data { get; set; }
    }

    public class DaeApiResponseArray<T>
    {
        public int TotalCount { get; set; }
        public T[] Data { get; set; }
    }
}