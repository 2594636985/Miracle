using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Miracle.Modularization.Aspects.Reflection.Emit
{
    public static class ILGeneratorExtensions
    {
        public static LocalBuilder NewArray(this ILGenerator ilGenerator, Type elementType, int size)
        {
            if (ilGenerator == null)
                throw new ArgumentNullException("ilGenerator");

            if (elementType == null)
                throw new ArgumentNullException("elementType");

            var localBuilder = ilGenerator.DeclareLocal(elementType.MakeArrayType());

            ilGenerator.EmitLoadValue(size);
            ilGenerator.Emit(OpCodes.Newarr, elementType);
            ilGenerator.Emit(OpCodes.Stloc, localBuilder);

            return localBuilder;
        }

        public static void EmitLoadArguments(this ILGenerator ilGenerator, int offset, int count)
        {
            if (ilGenerator == null)
                throw new ArgumentNullException("ilGenerator");

            var end = offset + count;

            for (var index = offset; index < end; index++)
            {
                ilGenerator.EmitLoadArgument(index);
            }
        }

        public static void ThrowException(this ILGenerator ilGenerator, Type exceptionType, string message)
        {
            if (ilGenerator == null)
                throw new ArgumentNullException("ilGenerator");

            if (exceptionType == null)
                throw new ArgumentNullException("exceptionType");

            var constructorInfo = exceptionType.GetConstructor(BindingFlags.Public | BindingFlags.Instance,
                typeof(string));

            ilGenerator.Emit(OpCodes.Ldstr, message);
            ilGenerator.Emit(OpCodes.Newobj, constructorInfo);
            ilGenerator.Emit(OpCodes.Throw);
        }



        public static void EmitLoadValue(this ILGenerator ilGenerator, int value)
        {
            if (ilGenerator == null)
                throw new ArgumentNullException("ilGenerator");

            switch (value)
            {
                case 0:
                    ilGenerator.Emit(OpCodes.Ldc_I4_0);
                    break;
                case 1:
                    ilGenerator.Emit(OpCodes.Ldc_I4_1);
                    break;
                case 2:
                    ilGenerator.Emit(OpCodes.Ldc_I4_2);
                    break;
                case 3:
                    ilGenerator.Emit(OpCodes.Ldc_I4_3);
                    break;
                case 4:
                    ilGenerator.Emit(OpCodes.Ldc_I4_4);
                    break;
                case 5:
                    ilGenerator.Emit(OpCodes.Ldc_I4_5);
                    break;
                case 6:
                    ilGenerator.Emit(OpCodes.Ldc_I4_6);
                    break;
                case 7:
                    ilGenerator.Emit(OpCodes.Ldc_I4_7);
                    break;
                case 8:
                    ilGenerator.Emit(OpCodes.Ldc_I4_8);
                    break;
                default:
                    ilGenerator.Emit(OpCodes.Ldc_I4, value);
                    break;
            }
        }

        public static void EmitCall(this ILGenerator ilGenerator, MethodInfo methodInfo)
        {
            if (ilGenerator == null)
                throw new ArgumentNullException("ilGenerator");

            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            ilGenerator.Emit(methodInfo.IsVirtual ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
        }

        public static void EmitBox(this ILGenerator ilGenerator, Type type)
        {
            if (ilGenerator == null)
                throw new ArgumentNullException("ilGenerator");

            if (type == null)
                throw new ArgumentNullException("type");

            if (type.IsValueType || type.IsGenericParameter)
                ilGenerator.Emit(OpCodes.Box, type);
        }

        public static void EmitLoadArgument(this ILGenerator ilGenerator, int index)
        {
            if (ilGenerator == null)
                throw new ArgumentNullException("ilGenerator");

            switch (index)
            {
                case 0:
                    ilGenerator.Emit(OpCodes.Ldarg_0);
                    break;
                case 1:
                    ilGenerator.Emit(OpCodes.Ldarg_1);
                    break;
                case 2:
                    ilGenerator.Emit(OpCodes.Ldarg_2);
                    break;
                case 3:
                    ilGenerator.Emit(OpCodes.Ldarg_3);
                    break;
                default:
                    ilGenerator.Emit(OpCodes.Ldarg, index);
                    break;
            }
        }

        public static void EmitUnbox(this ILGenerator ilGenerator, Type type)
        {
            if (ilGenerator == null)
                throw new ArgumentNullException("ilGenerator");

            if (type == null)
                throw new ArgumentNullException("type");

            if (type.IsValueType || type.IsGenericParameter)
                ilGenerator.Emit(OpCodes.Unbox_Any, type);
        }

        public static void EmitLoadIndirect(this ILGenerator ilGenerator, Type type)
        {
            if (ilGenerator == null)
                throw new ArgumentNullException("ilGenerator");

            if (type == null)
                throw new ArgumentNullException("type");

            if (!type.IsByRef)
                return;

            var elementType = type.GetElementType();

            if (elementType.IsValueType || elementType.IsGenericParameter)
                ilGenerator.Emit(OpCodes.Ldobj, elementType);
            else
                ilGenerator.Emit(OpCodes.Ldind_Ref);
        }

     
        public static void EmitStoreIndirect(this ILGenerator ilGenerator, Type type)
        {
            if (ilGenerator == null)
                throw new ArgumentNullException("ilGenerator");

            if (type == null)
                throw new ArgumentNullException("type");

            if (!type.IsByRef)
                return;

            var elementType = type.GetElementType();

            if (elementType.IsValueType || elementType.IsGenericParameter)
                ilGenerator.Emit(OpCodes.Stobj, elementType);
            else
                ilGenerator.Emit(OpCodes.Stind_Ref);
        }

    }
}
