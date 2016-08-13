﻿using System;
using System.ServiceModel.Configuration;
using Mammatus.ServiceModel.Web.Behaviors.Endpoint;

namespace Mammatus.ServiceModel.Web.Behaviors.ExtensionElements
{
    public class NewtonsoftJsonBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(NewtonsoftJsonBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new NewtonsoftJsonBehavior();
        }
    }
}
