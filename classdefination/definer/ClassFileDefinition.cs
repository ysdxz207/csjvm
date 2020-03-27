using csjvm.classdefination.common;
using csjvm.classdefination.common.attribute;
using csjvm.classdefination.constantpool;
using csjvm.classdefination.constantpool.impl;

namespace csjvm.classdefination.definer
{
    /// <summary>
    /// 描述：java类定义
    /// 创建者：ysdxz207
    /// 2020年3月3日 20:10:18
    ///
    /// ClassFile {
    ///     u4             magic;
    ///     u2             minor_version;
    ///     u2             major_version;
    ///     u2             constant_pool_count;
    ///     cp_info        constant_pool[constant_pool_count-1];
    ///     u2             access_flags;
    ///     u2             this_class;
    ///     u2             super_class;
    ///     u2             interfaces_count;
    ///     u2             interfaces[interfaces_count];
    ///     u2             fields_count;
    ///     field_info     fields[fields_count];
    ///     u2             methods_count;
    ///     method_info    methods[methods_count];
    ///     u2             attributes_count;
    ///     attribute_info attributes[attributes_count];
    /// }
    /// </summary>
    public class ClassFileDefinition : IDefinition
    {
        // 魔数，4个字节=Int32
        public uint Magic { set; get; }
        // 次版本号，2个字节=Int16
        public ushort MinorVersion { set; get; }
        // 主版本号
        public ushort MajorVersion { set; get; }
        // 常量池长度
        public ushort ConstantsPoolCount { set; get; }
        // 常量池（实则为常量池信息数组，长度为常量池长度-1）
        public ConstantPool ConstantPool { set; get; }
        // 类访问修饰符：public，private等
        public ushort AccessFlag { set; get; }
        // 类名索引地址
        public ushort ThisClass { set; get; }
        // 父类索引地址
        public ushort SuperClass { set; get; }
        // 接口数量
        public ushort InterfacesCount { set; get; }
        // 接口索引地址
        /// <summary>
        /// interfaces[]
        ///    Each value in the interfaces array must be a valid index into the constant_pool table. The constant_pool entry at each value of interfaces[i], where 0 ≤ i < interfaces_count, must be a CONSTANT_Class_info structure representing an interface that is a direct superinterface of this class or interface type, in the left-to-right order given in the source for the type.
        /// </summary>
        public ConstantClassInfo [] Interfaces { set; get; }
        // 字段数量
        public ushort FieldsCount { set; get; }
        // 字段信息
        public CommonInfo [] Fields { set; get; }
        // 方法数量
        public ushort MethodCount { set; get; }
        // 方法信息
        public CommonInfo [] Methods { set; get; }
        // 属性数量
        public ushort AttributesCount { set; get; }
        // 属性信息
        public AttributeInfo[] Attributes { set; get; }

    }
}