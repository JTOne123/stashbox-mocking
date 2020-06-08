﻿using Rocks;
using Stashbox.Resolution;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Stashbox.Mocking.Rocks
{
    internal class RocksResolver : ResolverBase
    {
        private static readonly MethodInfo MakeMethodInfo = typeof(Rock).GetMethod(nameof(Rock.Make), Type.EmptyTypes);

        public RocksResolver(ISet<Type> requestedTypes)
            : base(requestedTypes)
        { }

        protected override Expression GetExpressionInternal(TypeInformation typeInfo, ResolutionContext resolutionInfo)
        {
            var method = MakeMethodInfo.MakeGenericMethod(typeInfo.Type);
            return Expression.Call(method);
        }
    }
}
