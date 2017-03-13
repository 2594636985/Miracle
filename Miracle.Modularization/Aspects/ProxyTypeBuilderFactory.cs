using Miracle.Modularization.Aspects.Caching;
using Miracle.Modularization.Aspects.Reflection;
using Miracle.Modularization.Aspects.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;

namespace Miracle.Modularization.Aspects
{

    /// <summary>
    /// 代理类生成器工厂
    /// </summary>
    public sealed class ProxyTypeBuilderFactory : ITypeBuilderFactory, ITypeRepository
    {
        private const string DynamicAssemblyName = "Miracle.Modularization.Dynamic";
        private const string DynamicModuleName = DynamicAssemblyName + ".dll";
        private const string DynamicDefaultNamespace = DynamicAssemblyName;

        private readonly AssemblyBuilder _assemblyBuilder;
        private readonly ModuleBuilder _moduleBuilder;
        private readonly ITypeFactory _methodInfoTypeFactory;
        private readonly ICache<MemberToken, Type> _methodInfoTypeCache;//用于缓存
        private int _nextTypeId;

        public ProxyTypeBuilderFactory(bool canSaveAssembly)
        {
            _assemblyBuilder = DefineDynamicAssembly(DynamicAssemblyName, canSaveAssembly);
            _moduleBuilder = _assemblyBuilder.DefineDynamicModule(DynamicModuleName);

            _methodInfoTypeFactory = new MethodInfoTypeFactory(this);
            _methodInfoTypeCache = new Cache<MemberToken, Type>();

            _nextTypeId = -1;
        }

        /// <summary>
        /// 定义一个动前的程序集
        /// </summary>
        /// <param name="name"></param>
        /// <param name="canSaveAssembly"></param>
        /// <returns></returns>
        private static AssemblyBuilder DefineDynamicAssembly(string name, bool canSaveAssembly)
        {
            var assemblyBuilderAccess = canSaveAssembly ? AssemblyBuilderAccess.RunAndSave : AssemblyBuilderAccess.Run;
            var assemblyName = GetDynamicAssemblyName(name);

            return AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, assemblyBuilderAccess);
        }

        /// <summary>
        /// 获得动态程序集的程序集名称类
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private static AssemblyName GetDynamicAssemblyName(string assemblyName)
        {
            var executingAssemblyName = GetExecutingAssemblyName();

            return new AssemblyName(assemblyName)
            {
                Version = executingAssemblyName.Version
            };
        }

        /// <summary>
        /// 获得当前执行的程序集名称类
        /// </summary>
        /// <returns></returns>
        private static AssemblyName GetExecutingAssemblyName()
        {
            var assembly = Assembly.GetExecutingAssembly();

            return assembly.GetName();
        }

        /// <summary>
        /// 保存动态生成的程序集
        /// </summary>
        /// <param name="path"></param>
        public void SaveAssembly(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            _assemblyBuilder.Save(path);
        }

        /// <summary>
        /// 定义一个动态类型生成类
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="parentType"></param>
        /// <returns></returns>
        public TypeBuilder DefineType(string typeName, Type parentType)
        {
            if (typeName == null)
                throw new ArgumentNullException("typeName");

            if (parentType == null)
                throw new ArgumentNullException("parentType");

            var typeId = Interlocked.Increment(ref _nextTypeId);
            var uniqueTypeName = String.Format("{0}{1}<{2}>z__{3:x}", DynamicDefaultNamespace, Type.Delimiter, typeName, typeId);

            return _moduleBuilder.DefineType(uniqueTypeName, TypeAttributes.Class | TypeAttributes.NotPublic | TypeAttributes.Sealed | TypeAttributes.Serializable | TypeAttributes.BeforeFieldInit, parentType);
        }

        public Type GetType(MethodInfo methodInfo)
        {
            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            var memberToken = new MemberToken(methodInfo);

            return _methodInfoTypeCache.GetOrAdd(memberToken, _ => _methodInfoTypeFactory.CreateType(methodInfo));
        }

        /// <summary>
        /// 新建一个类型生成器
        /// </summary>
        /// <param name="parentType"></param>
        /// <returns></returns>
        public ITypeBuilder CreateBuilder(Type parentType)
        {
            if (parentType == null)
                throw new ArgumentNullException("parentType");

            return new ProxyTypeBuilder(this, parentType);
        }

    }

}
