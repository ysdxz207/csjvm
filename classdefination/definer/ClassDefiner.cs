using System;
using csjvm.classdefination.common;
using csjvm.classdefination.common.reader;
using csjvm.classdefination.constantpool;
using csjvm.classdefination.constantpool.impl;
using csjvm.classdefination.constants;
using csjvm.error;
using csjvm.exception;

namespace csjvm.classdefination.definer
{
    /// <summary>
    /// ClassFile {
    ///    u4             magic;
    ///    u2             minor_version;
    ///    u2             major_version;
    ///    u2             constant_pool_count;
    ///    cp_info        constant_pool[constant_pool_count-1];
    ///    u2             access_flags;
    ///    u2             this_class;
    ///    u2             super_class;
    ///    u2             interfaces_count;
    ///    u2             interfaces[interfaces_count];
    ///    u2             fields_count;
    ///    field_info     fields[fields_count];
    ///    u2             methods_count;
    ///    method_info    methods[methods_count];
    ///    u2             attributes_count;
    ///    attribute_info attributes[attributes_count];
    /// }
    /// </summary>
    public class ClassDefiner : IDefiner
    {
        private ClassFileDefinition _classFileDefinition;
        public ClassData ClassData { set; get; }


        public ClassDefiner(ClassData classData)
        {
            this.ClassData = classData;
        }


        public IDefinition Define()
        {
            _classFileDefinition = new ClassFileDefinition();

            // 读取并检查魔数
            ReadAndCheckMagic();

            // 读取并检查版本号
            ReadAndCheckVersion();

            // 读取常量池
            ReadConstantPool();

            // 读取类访问标识符
            this._classFileDefinition.AccessFlag = this.ClassData.ReadUint16();

            // 读取当前类名索引地址
            this._classFileDefinition.ThisClass = this.ClassData.ReadUint16();

            // 读取父类类名索引地址
            this._classFileDefinition.SuperClass = this.ClassData.ReadUint16();

            // 读取接口数量
            this._classFileDefinition.InterfacesCount = this.ClassData.ReadUint16();

            // 读取接口索引地址
            this._classFileDefinition.Interfaces = ReadInterfaces(this._classFileDefinition.InterfacesCount);
            
            // 读取字段数量
            this._classFileDefinition.FieldsCount = this.ClassData.ReadUint16();

            // 读取字段信息
            this._classFileDefinition.Fields = ReadCommonInfos(this._classFileDefinition.FieldsCount);

            // 读取方法数量
            this._classFileDefinition.MethodCount = this.ClassData.ReadUint16();

            // 读取方法信息
            this._classFileDefinition.Methods = ReadCommonInfos(this._classFileDefinition.MethodCount);

            // 读取属性数量
            this._classFileDefinition.AttributesCount = this.ClassData.ReadUint16();

            // 读取属性信息
            this._classFileDefinition.Attributes =
                new CommonAttributeReader(this.ClassData, this._classFileDefinition.ConstantPool)
                    .ReadAttributeInfos(this._classFileDefinition.AttributesCount);

            return _classFileDefinition;
        }

        private ConstantClassInfo [] ReadInterfaces(in ushort interfacesCount)
        {
            var interfaces = new ConstantClassInfo[interfacesCount];
            for (var i = 0; i < interfacesCount; i++)
            {
                var startIndex = this.ClassData.ReadUint16();
                interfaces[i] = (ConstantClassInfo) this._classFileDefinition.ConstantPool.GetConstantInfo(startIndex);
            }

            return interfaces;
        }


        /// <summary>
        /// 读取字段/方法信息
        /// </summary>
        private CommonInfo[] ReadCommonInfos(ushort count)
        {
            // 创建数组
            var arr = new CommonInfo [count];

            // 循环数组赋值
            for (var i = 0; i < count; i++)
            {
                arr[i] = ReadCommonInfo();
            }

            return arr;
        }

        private CommonInfo ReadCommonInfo()
        {
            var commonInfo = new CommonInfo();
            commonInfo.ReadWithExtends(this.ClassData, this._classFileDefinition.ConstantPool);

            return commonInfo;
        }


        /// <summary>
        /// 读取常量池
        /// </summary>
        private void ReadConstantPool()
        {
            // 读取常量池长度
            _classFileDefinition.ConstantsPoolCount = this.ClassData.ReadUint16();

            // 读取常量池
            this._classFileDefinition.ConstantPool = new ConstantPool
            {
                ConstantPoolInfos = new ConstantPoolInfo [_classFileDefinition.ConstantsPoolCount]
            };
            // 从索引1开始
            for (var i = 1; i < _classFileDefinition.ConstantsPoolCount; i++)
            {
                this._classFileDefinition.ConstantPool.ConstantPoolInfos[i] = ReadConstantPoolInfo();

                // Double和Long有高位和低位，所以占用两个位置
                if (this._classFileDefinition.ConstantPool.ConstantPoolInfos[i] is ConstantLongInfo
                    || this._classFileDefinition.ConstantPool.ConstantPoolInfos[i] is ConstantDoubleInfo)
                {
                    i++;
                }
            }
        }

        /// <summary>
        /// 读取常量池信息
        /// </summary>
        /// <returns></returns>
        private ConstantPoolInfo ReadConstantPoolInfo()
        {
            // 读取tag(U1)信息，用以判断是什么类型
            var tag = this.ClassData.ReadUint8WithoutSub();

            ConstantPoolInfo constantInfo = tag switch
            {
                Constants.CONST_Utf8 => new ConstantUtf8Info(),
                Constants.CONST_Integer => new ConstantIntegerInfo(),
                Constants.CONST_Float => new ConstantFloatInfo(),
                Constants.CONST_Long => new ConstantLongInfo(),
                Constants.CONST_Double => new ConstantDoubleInfo(),
                Constants.CONST_Class => new ConstantClassInfo(),
                Constants.CONST_String => new ConstantStringInfo(),
                Constants.CONST_Fieldref => new ConstantFieldRefInfo(),
                Constants.CONST_Methodref => new ConstantMethodRefInfo(),
                Constants.CONST_InterfaceMethodref => new ConstantInterfaceMethodRefInfo(),
                Constants.CONST_NameAndType => new ConstantNameAndTypeInfo(),
                Constants.CONST_MethodHandle => new ConstantMethodHandleInfo(),
                Constants.CONST_MethodType => new ConstantMethodTypeInfo(),
                Constants.CONST_InvokeDynamic => new ConstantInvokeDynamicInfo(),
                _ => throw new ClassFormatError("Can not find tag:" + tag)
            };

            constantInfo.Read(this.ClassData, this._classFileDefinition.ConstantPool);
            return constantInfo;
        }

        /// <summary>
        /// 读取并检查版本号
        /// </summary>
        private void ReadAndCheckVersion()
        {
            var minorVersion = this.ClassData.ReadUint16();

            var majorVersion = this.ClassData.ReadUint16();
            this._classFileDefinition.MinorVersion = minorVersion;
            this._classFileDefinition.MajorVersion = majorVersion;
            if (majorVersion == 45)
            {
                return;
            }

            if (majorVersion < 45 || majorVersion > 52)
            {
                throw new UnsupportedClassVersionError("Unsupported major version:" + majorVersion);
            }
        }

        /// <summary>
        /// 读取并检查魔数
        /// </summary>
        /// <exception cref="NotClassFileException"></exception>
        private void ReadAndCheckMagic()
        {
            var magic = this.ClassData.ReadUint32();
            if (magic != 0xCAFEBABE)
            {
                throw new NotClassFileException("Specified file is not a java class.");
            }
        }
    }
}