﻿namespace Airbnb.Domain.Common.Caching;

public abstract class CacheModel
{
    public abstract string CacheKey { get; }
}