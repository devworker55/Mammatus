﻿using Mammatus.Library.Reflection.Common;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Mammatus.Library.Reflection.Emitter
{
    internal class ArrayGetEmitter : BaseEmitter
    {
        public ArrayGetEmitter(Type targetType)
            : base(new CallInfo(targetType, null, Flags.InstanceAnyVisibility, MemberTypes.Method,
                                     Common.Constants.ArrayGetterName, new[] { typeof(int) }, null, true))
        {
        }

        protected internal override DynamicMethod CreateDynamicMethod()
        {
            return CreateDynamicMethod(Common.Constants.ArrayGetterName, CallInfo.TargetType,
                                        Common.Constants.ObjectType, new[] { Common.Constants.ObjectType, Common.Constants.IntType });
        }

        protected internal override Delegate CreateDelegate()
        {
            Type elementType = CallInfo.TargetType.GetElementType();
            Generator.ldarg_0 // load array
                .castclass(CallInfo.TargetType) // (T[])array
                .ldarg_1 // load index
                .ldelem(elementType) // load array[index]
                .boxIfValueType(elementType) // [box] return
                .ret();
            return Method.CreateDelegate(typeof(ArrayElementGetter));
        }
    }
}