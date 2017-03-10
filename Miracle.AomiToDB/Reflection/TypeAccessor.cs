using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;

namespace Miracle.AomiToDB.Reflection
{
    using Common;
    /// <summary>
    /// 类型访问者
    /// </summary>
    public abstract class TypeAccessor
    {
        #region 私有成员
        private readonly ConcurrentDictionary<string, MemberAccessor> _membersByName = new ConcurrentDictionary<string, MemberAccessor>();
        #endregion
        #region 公有属性
        public IObjectFactory ObjectFactory { get; set; }
        public abstract Type Type { get; }
        public List<MemberAccessor> Members { private set; get; }
        public MemberAccessor this[string memberName]
        {
            get
            {
                return _membersByName.GetOrAdd(memberName, name =>
                {
                    var ma = new MemberAccessor(this, name);
                    Members.Add(ma);
                    return ma;
                });
            }
        }
        public MemberAccessor this[int index]
        {
            get { return this.Members[index]; }
        }
        #endregion

        #region 构造函数
        public TypeAccessor()
        {
            this.Members = new List<MemberAccessor>();
        }
        #endregion

        #region 保护方法
        protected void AddMember(MemberAccessor member)
        {
            if (member == null) throw new ArgumentNullException("member");

            this.Members.Add(member);
            _membersByName[member.MemberInfo.Name] = member;
        }

        #endregion

        #region 公有方法
        /// <summary>
        /// 实例化当前类型
        /// </summary>
        /// <returns></returns>
        public virtual object CreateInstance()
        {
            throw new AomiToDBException("The '{0}' type must have public default or init constructor.".Args(Type.Name));
        }

        /// <summary>
        /// 通过对象工厂实例化对象
        /// </summary>
        /// <returns></returns>
        public object CreateInstanceEx()
        {
            return ObjectFactory != null ? ObjectFactory.CreateInstance(this) : CreateInstance();
        }

        #endregion


        #region Static Members

        static readonly ConcurrentDictionary<Type, TypeAccessor> _accessors = new ConcurrentDictionary<Type, TypeAccessor>();

        public static TypeAccessor GetAccessor(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");

            TypeAccessor accessor;

            if (_accessors.TryGetValue(type, out accessor))
                return accessor;

            var accessorType = typeof(TypeAccessor<>).MakeGenericType(type);

            accessor = (TypeAccessor)Activator.CreateInstance(accessorType);

            _accessors[type] = accessor;

            return accessor;
        }

        public static TypeAccessor<T> GetAccessor<T>()
        {
            TypeAccessor accessor;

            if (_accessors.TryGetValue(typeof(T), out accessor))
                return (TypeAccessor<T>)accessor;

            return (TypeAccessor<T>)(_accessors[typeof(T)] = new TypeAccessor<T>());
        }

        #endregion
    }
}
