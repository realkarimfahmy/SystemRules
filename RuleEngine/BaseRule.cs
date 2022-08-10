﻿using System;
using System.Collections.Generic;
using System.Linq;
using SystemRules.RulesEngine.Interfaces;

namespace SystemRules.RulesEngine
{
    public abstract class BaseRule<T> : IRule<T>
    {
        protected BaseRule()
        {
            Conditions = new List<ICondition>();
        }

        public IList<ICondition> Conditions { get; set; }

        public void ClearConditions()
        {
            Conditions.Clear();
        }

        public bool IsValid()
        {
            return Conditions.All(x => x.IsSatisfied());
        }

        public virtual void Initialize(T obj)
        {
            throw new NotImplementedException();
        }

        public virtual T Apply(T obj)
        {
            throw new NotImplementedException();
        }

        public virtual void OnRuleViolated(T obj)
        {
            throw new NotImplementedException();
        }
    }
}