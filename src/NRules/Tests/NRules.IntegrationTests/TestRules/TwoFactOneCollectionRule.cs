﻿using System.Collections.Generic;
using NRules.Fluent.Dsl;
using NRules.IntegrationTests.TestAssets;

namespace NRules.IntegrationTests.TestRules
{
    public class TwoFactOneCollectionRule : BaseRule
    {
        public override void Define()
        {
            FactType1 fact1 = null;
            IEnumerable<FactType2> collection2 = null;

            When()
                .Match<FactType1>(() => fact1, f => f.TestProperty.StartsWith("Valid"))
                .Query(() => collection2, x => x
                    .Match<FactType2>(
                        f => f.TestProperty.StartsWith("Valid"),
                        f => f.JoinProperty == fact1.TestProperty)
                    .Collect());
            Then()
                .Do(ctx => CallAction(fact1, collection2));
        }

        private void CallAction(FactType1 fact1, IEnumerable<FactType2> collection2)
        {
            Action();
        }
    }
}
